using AlbumMaker.Classes.Items;
using AlbumMaker.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Db
{
    internal class AppDataBase
    {
        #region generic database queries

        #endregion generic

        #region user queries
        public bool VerifyUser(string userName,string password)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
                return false;
            if (userName=="dd".ToLower() && password=="dd")
            {
                return true;
            }
            return false;
        }
        public bool CreateUser(UserItem user)
        {
            if(user==null)
                return false;
            return true;
        }
        public UserItem ReadUser(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
                return null;
            UserItem user;
            return null;
        }
        public bool UpdateUser(UserItem user)
        {
            if (user == null)
                return false;
            return true;
        }

        public bool DeleteUser(UserItem user)
        {
             if(user==null) return
                    false;
             return true;
        }
        #endregion user


        #region album queries
        public bool CreateAlbum(AlbumItem album)
        {
            if (album == null)
                return false;
            return true;
        }
        public AlbumItem ReadAlbum(string albumName)
        {
            if (string.IsNullOrWhiteSpace(albumName))
                return null;
            AlbumItem album;
            return null;
        }
        public bool UpdateAlbum(AlbumItem album)
        {
            if(album==null)
                return false;
            return true;
        }
        public bool DeleteAlbum(AlbumItem album) 
        {
            if (album == null)
                return false;
            return true;
        }
        #endregion albums

        #region image queries
        public bool CreateImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        public ImageItem ReadImage(string imageName)
        {
            if (string.IsNullOrWhiteSpace(imageName))
                return null;
            ImageItem image;
            return null;
        }
        public bool UpdateImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        public bool DeleteImage(ImageItem image)
        {
            if (image == null)
                return false;
            return true;
        }
        #endregion
    }
}
