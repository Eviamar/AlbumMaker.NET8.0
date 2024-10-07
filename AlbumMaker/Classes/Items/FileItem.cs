
namespace AlbumMaker.Classes.Items
{
    public class FileItem : Item
    {
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
        //public string GetRootDrive()=> this.rootDrive;
        //public string GetExtension() => this.extension;
        //public DateTime GetCreatedDate() => this.createdDate;
        //public DateTime GetModifiedDate() => this.modifiedDate;
        //public override string ToString()
        //{
        //    return $"Name: {this.GetName()}\nExtension: {this.extension}\nDrive: {this.rootDrive}\nCreated Date: {this.createdDate}\nModified Date: {this.modifiedDate}";
        //}
    }
}
