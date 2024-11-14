using AlbumMaker.Classes.Items;
using AlbumMaker.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SQLite;

namespace AlbumMaker.Classes.Db
{
    // This class control and handle queries to the app's database.
    internal static class AppDataBase
    {
        // this is where the location of the db file
        private static readonly string dataSource = $@"{Properties.AppSettings.Default.AppDataFolder}\\{Properties.AppSettings.Default.AppName}\\{Properties.AppSettings.Default.AppDatabaseFolderName}";
        // this is the database file name
        private static readonly string dataBaseFileName = $"{Properties.AppSettings.Default.AppDatabaseFileName}";
        // aand this one is the connection string combining both strings above (this made to be easy to change in the future without editing too much code)
        private static readonly string connectionString = @$"Data Source={dataSource}\{dataBaseFileName};Version=3";

        #region generic database queries

        // This function creates the database file, it runs 3 queries: 1. Users, 2. Albums(holds related id of user), 3. Images (holds related id of album)
        // in this way we store the data and connect each image to its album and each album to the user by using IDs.
        public static async void CreateDataBase()
        {
            try
            {
                Directory.CreateDirectory($@"{Properties.AppSettings.Default.AppDataFolder}\\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppDatabaseFolderName}");
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string[] createTableSql = {
                        @"
                        CREATE TABLE IF NOT EXISTS Users (
                        USER_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        user_Name NVARCHAR(100) NOT NULL UNIQUE,
                        user_Password NVARCHAR(100) NOT NULL,
                        isAdmin BIT DEFAULT 0,
                        userSecret NVARCHAR(100) NOT NULL,
                        userSecretAnswer NVARCHAR(100) NOT NULL);",
                        @"
                        CREATE TABLE IF NOT EXISTS Albums (
                        ALBUM_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        USER_ID INT NOT NULL,
                        Album_Name NVARCHAR(100) NOT NULL,
                        Album_Description NVARCHAR(255) NOT NULL,
                        Album_Template NVARCHAR(100) NOT NULL,
                        FOREIGN KEY (USER_ID) REFERENCES Users(USER_ID));",
                        @"
                        CREATE TABLE IF NOT EXISTS Images (
                        IMAGE_ID INTEGER PRIMARY KEY AUTOINCREMENT,
                        ALBUM_ID INT NOT NULL,
                        Image_path NVARCHAR(255) NOT NULL,
                        Image_Description NVARCHAR(255),
                        FOREIGN KEY (ALBUM_ID) REFERENCES Albums(ALBUM_ID));"};

                    foreach (string sql in createTableSql)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }
                    await connection.CloseAsync();
                }
            }
            catch { throw; }
        }
        
        // This function runs queries to drop all tables (not really in used, it was made for testing along the developing).
        // also dont tell anyone there is a hidden button in the app that runs it (its hidden so dw about client pressing it hehe)
        public static async void DropTables()
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string[] dropTableSql = {
                        "DROP TABLE IF EXISTS Users;",
                        "DROP TABLE IF EXISTS Albums;",
                        "DROP TABLE IF EXISTS Images;"
                };

                    foreach (string sql in dropTableSql)
                    {
                        using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                        {
                            await command.ExecuteNonQueryAsync();
                        }
                    }

                    await connection.CloseAsync();
                }
            }
            catch  {  throw; }
        }
        #endregion generic

        #region user queries

        // This function gets user name and a password and connects to database and checks if there is a user by that name and if so the password given is matched.
        public static async Task<bool> VerifyUser(string userName, string password)
        {
            try
            {
                int userID = -1;
                string storedPassword = "";
                int isAdmin = -1;
                string question = "";
                string answer = "";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM Users WHERE user_Name = @UserName";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (await reader.ReadAsync()) // User exists
                            {
                                userID = reader.GetInt32(reader.GetOrdinal("USER_ID"));
                                storedPassword = reader.GetString(reader.GetOrdinal("user_Password"));
                                isAdmin = reader.GetInt32(reader.GetOrdinal("isAdmin"));
                                question = reader.GetString(reader.GetOrdinal("userSecret"));
                                answer = reader.GetString(reader.GetOrdinal("userSecretAnswer"));

                                if (password == storedPassword)
                                {

                                    UserItem user = new UserItem(userID, userName, storedPassword, question, answer, isAdmin == 1);
                                    await connection.CloseAsync();
                                    int loadUser = await GetAllAlbumsOfUser(user);
                                    if (loadUser>=0)
                                    {
                                        SettingsManager.userItem = user;
                                        return true;
                                    }
                                    else if(loadUser==-2)
                                    {
                                        MessageBox.Show("-2");
                                        return false;
                                    }
                                    else
                                    {
                                        MessageBox.Show("Failed to load user data", "Failed");
                                        return false ;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    await connection.CloseAsync();
                                    return false;
                                }
                            }
                            else
                            {
                                // User doesn't exist
                                MessageBox.Show("User doesn't exist", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                await connection.CloseAsync();
                                return false;
                            }
                        }
                    }
                }
            }
            catch  { throw; }
        }
        
        // This function checks if there are any rows inside the users table (it was made so that upon creating the first user it makes it admin by default aka root user)
        // Also not related to this function the root user (whoever user id is equal to 1 cannot remove its admin role)
        private static async Task<bool> AreThereAnyUsers() 
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT COUNT(*) FROM Users";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int userCount = Convert.ToInt32(await command.ExecuteScalarAsync());
                        await connection.CloseAsync();
                        return userCount > 0;
                    }
                }
            }
            catch
            { return false; throw; }
        }

        // This function is made to recover password of a user whom forgot their password
        // more on that later
        public static async Task<bool> RecoverPassword(string userName)
        {
            try
            {
                int userID = -1;
                string storedPassword = "";
                int isAdmin = -1;
                string question = "";
                string answer = "";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = "SELECT * FROM Users WHERE user_Name = @UserName";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (await reader.ReadAsync()) // User exists
                            {
                                userID = reader.GetInt32(reader.GetOrdinal("USER_ID"));
                                storedPassword = reader.GetString(reader.GetOrdinal("user_Password"));
                                isAdmin = reader.GetInt32(reader.GetOrdinal("isAdmin"));
                                question = reader.GetString(reader.GetOrdinal("userSecret"));
                                answer = reader.GetString(reader.GetOrdinal("userSecretAnswer"));

                                UserItem user = new UserItem(userID, userName, storedPassword, question, answer, isAdmin == 1);
                                SettingsManager.userItem = user;
                                await connection.CloseAsync();
                                return true;

                            }
                            else
                            {
                                
                                MessageBox.Show("User doesn't exist", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                await connection.CloseAsync();
                                return false;
                            }
                        }

                    }
                }
            }
            catch { throw; }
        }
        
        // This function create a user in the database
        public static async Task<bool> CreateUser(string UserName, string Password,string userQuestion,string userAnswer)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string insertQuery = "";
                    bool res = await AreThereAnyUsers();
                    if (res)
                        insertQuery = "INSERT INTO Users (user_Name, user_Password, isAdmin,userSecret,userSecretAnswer) VALUES (@UserName, @Password, 0, @userQuestion, @userAnswer)";
                    else
                        insertQuery = "INSERT INTO Users (user_Name, user_Password, isAdmin,userSecret,userSecretAnswer) VALUES (@UserName, @Password, 1, @userQuestion, @userAnswer)";
                    if (String.IsNullOrEmpty(insertQuery))
                        return false;
                    await connection.OpenAsync();
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@UserName", UserName);
                        insertCommand.Parameters.AddWithValue("@Password", Password);
                        insertCommand.Parameters.AddWithValue("@userQuestion", userQuestion);
                        insertCommand.Parameters.AddWithValue("@userAnswer", userAnswer);
                        await insertCommand.ExecuteScalarAsync();
                    }
                    MessageBox.Show($"{UserName} created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await connection.CloseAsync();
                    return true;
                }
            }
            catch { return false; throw;}
        }

        // This function handles updating user, it gets UserItem which was manipulated before according to the needs)
        public static async Task<bool> UpdateUser(UserItem user)
        {
            
            if (user == null)
                return false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "UPDATE Users SET user_Name = @userName,user_Password = @userPassword, isAdmin = @isAdmin, userSecret = @secret, userSecretAnswer = @answer WHERE USER_ID = @userID";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userID", user.GetID());
                        command.Parameters.AddWithValue("@userName", user.GetName());
                        command.Parameters.AddWithValue("@userPassword", user.GetPassword());
                        command.Parameters.AddWithValue("@isAdmin", user.GetIsAdmin());
                        command.Parameters.AddWithValue("@secret", user.GetQuestion());
                        command.Parameters.AddWithValue("@answer", user.GetAnswer());
                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        await connection.CloseAsync();
                       
                        return rowsAffected > 0;
                    }

                }

            }
            catch {  return false; throw; }
        }

        // This function delete the user from database (never implemented as we dont see any need for that but good to keep for further needs if clients request this feature hehe).
        public static async Task<bool> DeleteUser(UserItem user)
        {
            if (user == null) 
                return false;
            if (user == SettingsManager.userItem)
            {
                MessageBox.Show("You cannot delete yourself!","Action forbidden",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return false;
            }
            DialogResult dr;
            if (user.GetIsAdmin())
            {
                dr = MessageBox.Show("The user you want to delete is admin, are you sure you want to delete an admin user?","Alert",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (dr == DialogResult.Yes)
                {
                    
                }   
                else
                    return false;   
            }
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Users WHERE USER_ID = @userID";

                    using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@userID", user.GetID());

                        await connection.OpenAsync();
                        int rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                        await connection.CloseAsync();

                        if (rowsAffected > 0)
                        {
                            await GetAllAlbumsOfUser(user);
                            foreach(AlbumItem album in user.GetAlbumItems())
                            {
                                bool res = await DeleteAlbum(album);
                                if(res)
                                    user.DeleteSpecificAlbum(album);
                            }
                            return true;
                        }

                        return false;
                    }

                }
            }
            catch { return false; throw; }


        }
        // this function gets all users from database and populate UserItems which located in SettingsManager class for admin puposes.
        public static async Task<int> GetAllUserItems()
        {
            List<UserItem> users = new List<UserItem>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();

                    string query = $"SELECT * FROM Users"; // Query to get all users
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Asynchronously execute the command and get a data reader
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through all rows
                            while (await reader.ReadAsync())
                            {
                                int userID = reader.GetInt32(reader.GetOrdinal("USER_ID"));
                                string userName = reader.GetString(reader.GetOrdinal("user_Name"));
                                string userPassword = reader.GetString(reader.GetOrdinal("user_Password"));
                                int isAdmin = reader.GetInt32(reader.GetOrdinal("isAdmin"));
                                string userSecret = reader.GetString(reader.GetOrdinal("userSecret"));
                                string userSecretAnswer = reader.GetString(reader.GetOrdinal("userSecretAnswer"));
                                // Create a new UserItem for each row and add it to the list
                                UserItem user = new UserItem(userID, userName, userPassword, userSecret, userSecretAnswer,isAdmin==1);
                                int loadData = await GetAllAlbumsOfUser(user);
                                if (loadData >= 0)
                                    users.Add(user);
                                else
                                {
                                    MessageBox.Show($"Failed to load data from {user.GetName()}", "Failed");
                                    return -2;
                                }
                            }
                        }
                    }
                }
            SettingsManager.userItems = users;
            return users.Count;
            }
            catch { return -1; throw; }


        }
        #endregion user

        #region album queries
        // This function gets all albums of a user (for loading user albums for normal user or in admin panel for each user in database)
        public static async Task<int> GetAllAlbumsOfUser(UserItem user)
        {
            List<AlbumItem> albums = new List<AlbumItem>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = $"SELECT * FROM Albums WHERE User_ID={user.GetID()}"; // Query to get all users
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Asynchronously execute the command and get a data reader
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through all rows
                            while (await reader.ReadAsync())
                            {
                                int albumID = reader.GetInt32(reader.GetOrdinal("ALBUM_ID"));
                                string albumName = reader.GetString(reader.GetOrdinal("Album_Name"));
                                string albumDescription = reader.GetString(reader.GetOrdinal("Album_Description"));
                                string albumTemplate = reader.GetString(reader.GetOrdinal("Album_Template"));

                                // Create a new UserItem for each row and add it to the list
                                AlbumItem album = new AlbumItem(albumID, albumName, albumDescription, albumTemplate);
                                int loadData = await GetAllImagesOfAlbum(album);
                                if(loadData>=0)
                                    albums.Add(album);
                                else
                                {
                                    MessageBox.Show($"Failed to load data from {album.GetName()} album","Failed");
                                    return -2;
                                }
                            }
                        }
                    }
                }
                user.SetAlbumItems(albums);
            }
            catch { return -1; throw; }
            return user.GetAlbumItems().Count;
        }

        // The function handles the creating of a new album
        public static async Task<int> CreateAlbum(UserItem user, string albumName, string albumDescription,string albumTemplate)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string insertQuery = "INSERT INTO Albums (USER_ID, Album_Name, Album_Description, Album_Template) VALUES (@userID, @albumName, @albumDescription, @albumTemplate)";
                    // Open the connection
                    await connection.OpenAsync();
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        // Add parameters to the query
                        insertCommand.Parameters.AddWithValue("@userID", user.GetID());
                        insertCommand.Parameters.AddWithValue("@albumName", albumName);
                        insertCommand.Parameters.AddWithValue("@albumDescription", albumDescription);
                        insertCommand.Parameters.AddWithValue("@albumTemplate", albumTemplate);
                        // Execute the insert command
                        await insertCommand.ExecuteNonQueryAsync();
                    }                  
                    // Retrieve the last inserted row ID (ALBUM_ID)
                    using (SQLiteCommand getIdCommand = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                    {
                        var albumId = await getIdCommand.ExecuteScalarAsync();
                        await connection.CloseAsync();
                        AlbumItem albumItem = new AlbumItem(Convert.ToInt32(albumId), albumName, albumDescription, albumTemplate);
                        user.AddAlbumItem(albumItem);
                        return Convert.ToInt32(albumId);
                    }
                }
            }
            catch { return -1; throw; }
        }

        // The function handles updating an album giving to it
        public static async Task<bool> UpdateAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "UPDATE Albums SET Album_Name = @newName,Album_Description =@newDesc,Album_Template = @newTemplate WHERE ALBUM_ID = @albumID";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@albumID", album.GetID());
                        command.Parameters.AddWithValue("@newName", album.GetName());
                        command.Parameters.AddWithValue("@newDesc", album.GetDescription());
                        command.Parameters.AddWithValue("@newTemplate", album.GetTemplate());

                        await connection.OpenAsync(); 
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        connection.Close(); 
                        return rowsAffected > 0;
                    }
                }
            }
            catch { return false; throw; }
        }

        //The function handles deleting album (deleting files is not handled here)
        public static async Task<bool> DeleteAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Albums WHERE ALBUM_ID = @albumID";
                    using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@albumID", album.GetID());

                        await connection.OpenAsync();

                        int rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                        await connection.CloseAsync();
                        if (rowsAffected > 0)
                        {
                            await GetAllImagesOfAlbum(album);
                            
                            foreach(ImageItem image in album.GetImages())
                            {
                                bool res = await DeleteImage(image);
                            }
                            album.SetImages(new List<ImageItem>());
                            return true;
                        }                     
                        return false;
                    }
                }
            }
            catch { throw; }



        }
        #endregion albums

        #region image queries

        // The fucntion gets an album and by its id searches in the images table all images related to the album id and returns them as a list
        public static async Task<int> GetAllImagesOfAlbum(AlbumItem album)
        {
            List<ImageItem> images = new List<ImageItem>();
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    await connection.OpenAsync();
                    string query = $"SELECT * FROM Images WHERE ALBUM_ID={album.GetID()}"; // Query to get all users
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Asynchronously execute the command and get a data reader
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            // Iterate through all rows
                            while (await reader.ReadAsync())
                            {
                                int imageID = reader.GetInt32(reader.GetOrdinal("IMAGE_ID"));
                                string imagePath = reader.GetString(reader.GetOrdinal("Image_path"));
                                string imageDescription = reader.GetString(reader.GetOrdinal("Image_Description"));
                                // Create a new UserItem for each row and add it to the list
                                ImageItem image = new ImageItem(imageID, imagePath, imageDescription,album.GetID());
                                images.Add(image);
                            }                         
                        }
                        album.SetImages(images);
                    }
                }
            }
            catch { return -1; throw; }
            album.SetImages(images);
            return album.GetImages().Count;       
        }
        // The function creates a image in images table.
        public static async Task<bool> CreateImage(AlbumItem album, string imagePath, string imageDescription)
        {
            try
            {
                if(album==null)
                    return false;
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string insertQuery = insertQuery = "INSERT INTO Images (ALBUM_ID, Image_path, Image_Description) VALUES (@albumID, @imagePath, @imageDescription)";
                    if (String.IsNullOrEmpty(insertQuery))
                        return false;
                    await connection.OpenAsync();
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@albumID", album.GetID());
                        insertCommand.Parameters.AddWithValue("@imagePath", imagePath);
                        insertCommand.Parameters.AddWithValue("@imageDescription", imageDescription);
                        await insertCommand.ExecuteScalarAsync();
                    }
                    using (SQLiteCommand getIdCommand = new SQLiteCommand("SELECT last_insert_rowid()", connection))
                    {
                        var imageID = await getIdCommand.ExecuteScalarAsync();
                        ImageItem imageItem = new ImageItem(Convert.ToInt32(imageID), imagePath, imageDescription,album.GetID());
                        album.AddImage(imageItem);
                    }
                    await connection.CloseAsync();
                    return true;
                }
            }
            catch  { return false; throw; }
        }

        // The function update image, it can update location on the disk of the image or description (but its used really for updating description)
        public static async Task<bool> UpdateImage(ImageItem image)
        {
            if (image == null)
                return false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string query = "UPDATE Images SET Image_Description = @newDescription WHERE Image_path = @imagePath";

                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        // Replace this with the actual parameter value you want to set
                        command.Parameters.AddWithValue("@imagePath", image.GetName());
                        command.Parameters.AddWithValue("@newDescription", image.GetDescription());

                        await connection.OpenAsync(); // Open the connection before executing the command
                        int rowsAffected = await command.ExecuteNonQueryAsync();
                        connection.Close(); // Close the connection after executing the command
                        return rowsAffected > 0;
                    }

                }
            }
            catch { return false; throw; }
        }

        // The function delete from database (deleting from disk is not handled here)
        public static async Task<bool> DeleteImage(ImageItem image)
        {
            if (image == null)
                return false;
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string deleteQuery = "DELETE FROM Images WHERE IMAGE_ID = @imageID";

                    using (SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@imageID", image.GetID());

                        await connection.OpenAsync();
                        int rowsAffected = await deleteCommand.ExecuteNonQueryAsync();
                        await connection.CloseAsync();
                        if (rowsAffected > 0)
                        {
                            
                            return true;
                        }
                        return false;
                    }
                }
            }
            catch { return false; throw; }
        }
        #endregion
    }
}
