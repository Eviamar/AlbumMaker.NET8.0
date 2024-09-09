using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class FileItem : Item
    {
        private string extension;
        private string rootDrive;
        private DateTime createdDate;
        private DateTime modifiedDate;
        public FileItem(int id, string rootDrive,string name,string extension, string path, DateTime createdDate, DateTime modifiedDate) : base(id,name)
        {
            this.rootDrive = rootDrive;
            this.extension = extension;
            this.createdDate = createdDate;
            this.modifiedDate = modifiedDate;
        }
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            FileItem other = (FileItem)obj;
            return other.GetName() == this.GetName();
        }
        public string GetRootDrive()=> this.rootDrive;
        public string GetExtension() => this.extension;
        public DateTime GetCreatedDate() => this.createdDate;
        public DateTime GetModifiedDate() => this.modifiedDate;
    }
}
