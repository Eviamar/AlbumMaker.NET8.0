using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    // This class was made to make things easier for us to handle files and objects in the app.
    public abstract class Item
    {
        private int id;
        private string name;
        internal Item(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return $"ID: {id}, Name: {name}, ";
        }
        public string GetName()=> name;
        public int GetID()=> id;
        public void SetNewName(string newName)=> name = newName;
    }
    
}
