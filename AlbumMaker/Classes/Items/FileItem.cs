
namespace AlbumMaker.Classes.Items
{
    // This class was made to handle files (for using in Scan Drive form)
    public class FileItem : Item
    {
        // Although the Item class has name variable already but this one requires a one that is also public for DataBiding (in scan form) ¯\_(ツ)_/¯
        public string Name { get; private set; }
        public string Extension { get; private set; }
        public string RootDrive { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime ModifiedDate { get; private set; }
        internal FileItem(int id, string rootDrive,string name,string extension, string path, DateTime createdDate, DateTime modifiedDate) : base(id,name)
        {
            this.Name = name;
            this.RootDrive = rootDrive;
            this.Extension = extension;
            this.CreatedDate = createdDate;
            this.ModifiedDate = modifiedDate;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            FileItem other = (FileItem)obj;
            return other.GetName() == this.GetName();
        }
        
    }
}
