

namespace AlbumMaker.Classes.Items
{
    internal class ImageItem : Item
    {
        //maybe consider add id of related album so you can put it in the path {albumID}\\{this.imageName} //instead of this.path => change path field name to "imageName"
        private string path;
        private string description;

        public ImageItem(int id,string path,string description) : base(id,path)
        {
            this.description = description;
        }
        public string GetDescription()=> description;
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
