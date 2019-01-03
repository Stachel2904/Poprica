using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public abstract class Item
    {
        /// <summary>
        /// Holds the item type.
        /// </summary>
        public ItemCategory Category { get; set; }

        public Item()
        {

        }

        public abstract void Use();
    }
}
