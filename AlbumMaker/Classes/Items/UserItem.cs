
namespace AlbumMaker.Classes.Items
{
    public class UserItem : Item
    {
        private string password;
        private string question;
        private string answer;
        private bool isAdmin;
        private List<AlbumItem> albumItems;
        internal UserItem(int id,string name, string password, string question, string answer,bool isAdmin) : base(id,name)
        {
            this.password = password;
            this.question = question;
            this.answer = answer;
            this.isAdmin = isAdmin;
            albumItems = new List<AlbumItem>();
        }
        public override string ToString()
        {
            return base.ToString() + $"Password: {password},Question: {question},Answer: {answer},Is admin? {isAdmin}";
        }
        public string GetPassword() => password;
        public string GetQuestion() => question;
        public string GetAnswer() => answer;
        public void SetQuestion(string question)=> this.question = question;
        public void SetAnswer(string answer)=> this.answer = answer;
        public void SetNewPassword(string newPassword) => this.password = newPassword;
        public bool GetIsAdmin() => isAdmin;
        public bool SetIsAdmin(bool admin) => isAdmin = admin;
        public List<AlbumItem> GetAlbumItems() => albumItems;
        public void AddAlbumItem(AlbumItem albumItem) => albumItems.Add(albumItem);
        public void SetAlbumItems(List<AlbumItem> albumItems) => this.albumItems = albumItems;
        public void DeleteSpecificAlbum(AlbumItem album) => albumItems.Remove(album);
        
       
    }
    
}
