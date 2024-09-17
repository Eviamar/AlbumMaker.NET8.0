

namespace AlbumMaker.Classes.Items
{
    public class ImageItem : Item
    {
        //maybe consider add id of related album so you can put it in the path {albumID}\\{this.imageName} //instead of this.path => change path field name to "imageName"
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
