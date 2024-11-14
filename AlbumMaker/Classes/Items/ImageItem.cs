

namespace AlbumMaker.Classes.Items
{
    // This class was made to handle Images
    public class ImageItem : Item
    {
        private string path;
        private string description;
        private int relatedAlbumID;

        internal ImageItem(int id,string path,string description,int relatedAlbumID) : base(id,path)
        {
            this.description = description;
            this.relatedAlbumID = relatedAlbumID;
        }
        public string GetDescription()=> description;
        public int GetRelatedAlbumID() => relatedAlbumID;
        public void SetDescription(string description) => this.description = description;
        public override string ToString()
        {
            return base.ToString()+$"Path: {path}\nDescription:{description}";
        }
        public string GetImagePath()
        {
            return $@"{Properties.AppSettings.Default.AppDataFolder}\{Properties.AppSettings.Default.AppName}\{Properties.AppSettings.Default.AppAlbumsFolderName}\{this.GetName()}";

        }
    }
}
