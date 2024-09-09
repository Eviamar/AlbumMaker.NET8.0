using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class AlbumItem : Item
    {
        
        private string description;
        private List<ImageItem> images;
        public AlbumItem(int id, string name, string description) : base(id,name)
        {
            this.description = description;
            images = new List<ImageItem>();
        }
        
        public string GetDescription()=> description;
        public List<ImageItem> GetImages() => images;
        public void AddImage(ImageItem image) => images.Add(image);
        public void DeleteAllImages() => images.Clear();
        public bool DeleteImageItem(ImageItem image)
        {
            for (int i = 0; i < images.Count; i++)
            {
                if(image.GetID() == images[i].GetID())
                {
                    images.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        public ImageItem GetSpecificImage(ImageItem image)
        {
            foreach(ImageItem imageItem in images)
            {
                if(image == imageItem)
                    return image;

            }
            return null;
        }


    }
}
