using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class Weapon : Item
    {
        /// <summary>
        /// Holds the type of the weapon.
        /// </summary>
        public WeaponType Type { get; set; }

        public Weapon(ItemCategory category) : base(category)
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
