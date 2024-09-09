using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class UserItem : Item
    {
        private string password;
        private string question;
        private string answer;
        private bool isAdmin;
        private List<AlbumItem> albumItems;
         
        public UserItem(int id,string name, string password, string question, string answer,bool isAdmin) : base(id,name)
        {
            this.password = password;
            this.question = question;
            this.answer = answer;
            this.isAdmin = isAdmin;
            albumItems = new List<AlbumItem>();
        }
        public string GetPassword() => password;
        public string GetQuestion() => question;
        public string GetAnswer() => answer;
        public bool IsAdmin() => isAdmin;
        public List<AlbumItem> GetAlbumItems() => albumItems;
        public void AddAlbumItem(AlbumItem albumItem) => albumItems.Add(albumItem);
        public void SetAlbumItems(List<AlbumItem> albumItems) => this.albumItems = albumItems;
        public void DeleteAllAlbums()=> albumItems.Clear();
        public void DeleteSpecificAlbum(AlbumItem album) => albumItems.Remove(album);
        public void SearchAlbumByName(string name)
        {
            foreach(AlbumItem albumItem in albumItems)
            {
                
            }
        }
    }
}
