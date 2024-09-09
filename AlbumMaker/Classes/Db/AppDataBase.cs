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
        
        public bool VerifyUser(string userName,string password)
        {
            if (String.IsNullOrWhiteSpace(userName) || String.IsNullOrWhiteSpace(password))
                return false;
            return false;
        }
    }
}
