using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class ImageItem : Item
    {
        private string name;

        public ImageItem(int id,string name) : base(id,name)
        {
            this.name = name;
        }
    }
}
