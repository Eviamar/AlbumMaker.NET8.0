

namespace AlbumMaker.Classes.Items
{
    internal class AlbumItem : Item
    {
        
        private string description;
        private string template;
        private List<ImageItem> images;
        public AlbumItem(int id, string name, string description,string template) : base(id,name)
        {
            this.description = description;
            this.template = template;
            images = new List<ImageItem>();
        }
        public override string ToString()
        {
            return base.ToString()+$"Description: {description},Template: {template} ";
        }
        public string GetDescription()=> description;
        public string GetTemplate()=> template;
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
        public void SetImages(List<ImageItem> images) => this.images = images;


    }
}
