using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class BasicItem : Item
    {
        /// <summary>
        /// Holds the type of this item.
        /// </summary>
        public BasicItemType Type { get; set; }

        public BasicItem(ItemCategory category, BasicItemType type) : base(category)
        {
            Type = type;
        }

        /// <summary>
        /// Uses this item.
        /// </summary>
        public override void Use()
        {
            throw new NotImplementedException();
        }
    }
}
