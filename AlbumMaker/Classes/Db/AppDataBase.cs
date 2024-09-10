using AlbumMaker.Classes.Items;
using Microsoft.VisualBasic.ApplicationServices;
using System.Data.SQLite;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
namespace AlbumMaker.Classes.Db
{
    internal static class AppDataBase
    {
        static string connectionString = @$"Data Source={Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\Database\Database.db;Version=3";
        public static UserItem userItem { get; set; } //try to use that as global variable to do whatever in the app

        #region generic database queries
        public static void CreateDataBase()
        {
            try
            {
                Directory.CreateDirectory($@"{Properties.AppSettings.Default.AppDataFolder}\\{Properties.AppSettings.Default.AppName}\Database");
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

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
                        Album_Name NVARCHAR(100) NOT NULL UNIQUE,
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
                            command.ExecuteNonQuery();
                        }
                    }
                    connection.Close();
                }
            }
            catch (SQLiteException sqlex) { throw; }
            catch (Exception ex) { throw; }


        }

        #endregion generic

        #region user queries
        public static bool VerifyUser(string userName, string password)
        {
            try
            {
                int userID = -1;
                string storedPassword = null;
                int isAdmin = -1;
                string question = "";
                string answer = "";
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM Users WHERE user_Name = @UserName";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@UserName", userName);

                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // User exists
                            {
                                userID = reader.GetInt32(reader.GetOrdinal("USER_ID"));
                                storedPassword = reader.GetString(reader.GetOrdinal("user_Password"));
                                isAdmin = reader.GetInt32(reader.GetOrdinal("isAdmin"));
                                question = reader.GetString(reader.GetOrdinal("userSecret"));
                                answer = reader.GetString(reader.GetOrdinal("userSecretAnswer"));

                                if (password == storedPassword)
                                {

                                    UserItem user = new UserItem(userID, userName, storedPassword, question, answer, isAdmin == 1);
                                    userItem = user;
                                    connection.Close();
                                    return true;
                                }
                                else
                                {
                                    MessageBox.Show("Incorrect password", "Attention!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    connection.Close();
                                    return false;
                                }
                            }
                            else
                            {
                                // User doesn't exist
                                MessageBox.Show("User doesn't exist", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                connection.Close();
                                return false;
                            }
                        }

                    }
                }
            }
            catch (Exception ex) { throw; }
        }

        private static bool AreThereAnyUsers() 
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT COUNT(*) FROM Users";
                    using (SQLiteCommand command = new SQLiteCommand(query, connection))
                    {
                        int userCount = Convert.ToInt32(command.ExecuteScalar());
                        connection.Close();
                        return userCount > 0;
                    }
                }
            }
            catch (SQLiteException ex)
            {
                //MessageBox.Show($"{ex.Message}\nError code: {ex.ErrorCode}", "SQL error #04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message, "Error #04", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                throw;
            }
        }

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
                                userItem = user;
                                connection.Close();
                                return true;

                            }
                            else
                            {
                                
                                MessageBox.Show("User doesn't exist", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                connection.Close();
                                return false;
                            }
                        }

                    }
                }
            }
            catch (Exception ex) { throw; }
        }

        public static bool CreateUser(string UserName, string Password,string userQuestion,string userAnswer)
        {
            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    string insertQuery = "";
                    bool res = AreThereAnyUsers();
                    if (res)
                        insertQuery = "INSERT INTO Users (user_Name, user_Password, isAdmin,userSecret,userSecretAnswer) VALUES (@UserName, @Password, 0, @userQuestion, @userAnswer)";
                    else
                        insertQuery = "INSERT INTO Users (user_Name, user_Password, isAdmin,userSecret,userSecretAnswer) VALUES (@UserName, @Password, 1, @userQuestion, @userAnswer)";
                    if (String.IsNullOrEmpty(insertQuery))
                        return false;
                    connection.Open();
                    using (SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection))
                    {
                        insertCommand.Parameters.AddWithValue("@UserName", UserName);
                        insertCommand.Parameters.AddWithValue("@Password", Password);
                        insertCommand.Parameters.AddWithValue("@userQuestion", userQuestion);
                        insertCommand.Parameters.AddWithValue("@userAnswer", userAnswer);
                        insertCommand.ExecuteNonQuery();
                    }
                    MessageBox.Show($"{UserName} created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    return true;
                }
            }
            catch (SQLiteException ex) { return false;  throw; }
            catch (Exception ex){ return false; throw;}
        }
        public static UserItem ReadUser(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            UserItem user;
            return null;
        }
        public static bool UpdateUser(UserItem user)
        {
            if (user == null)
                return false;
            return true;
        }

        public static bool DeleteUser(UserItem user)
        {
            if (user == null) return
                   false;
            return true;
        }
        #endregion user


        #region album queries
        public static bool CreateAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            return true;
        }
        public static AlbumItem ReadAlbum(string albumName)
        {
            if (string.IsNullOrWhiteSpace(albumName))
                return null;
            AlbumItem album;
            return null;
        }
        public static bool UpdateAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            return true;
        }
        public static bool DeleteAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            return true;
        }
        #endregion albums

        #region image queries
        public static bool CreateImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        public static ImageItem ReadImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;
            ImageItem image;
            return null;
        }
        public static bool UpdateImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        public static bool DeleteImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        #endregion
    }
}
