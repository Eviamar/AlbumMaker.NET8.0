using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class ImageItem : Item
    {
        private string path;
        private string description;

        public ImageItem(int id,string path,string description) : base(id,path)
        {
            this.description = description;
        }
        public string GetDescription()=> description;
    }
}
