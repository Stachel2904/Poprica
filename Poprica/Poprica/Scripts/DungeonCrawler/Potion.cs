using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class Potion : Item
    {
        /// <summary>
        /// Holds the type of this potion.
        /// </summary>
        public PotionType Type { get; set; }

        public Potion(ItemCategory category) : base(category)
        {

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
