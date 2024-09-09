using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlbumMaker.Classes.Items
{
    internal class Item
    {
        private readonly int id;
        private string name;

        public Item(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public string GetName()=> name;
        public int GetID()=> id;
        public void SetNewName(string newName)=> name = newName;
    }
}
