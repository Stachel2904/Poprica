using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class Armor : Item
    {
        /// <summary>
        /// Holds the type of this armor.
        /// </summary>
        public ArmorType Type { get; set; }

        public Armor(ItemCategory category, ArmorType type) : base(category)
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
