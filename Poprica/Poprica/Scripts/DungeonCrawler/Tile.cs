using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public sealed class Tile
    {
        /// <summary>
        /// Holds the type of this Tile.
        /// </summary>
        public TileType Type { get; set; }

        /// <summary>
        /// Array of true and false values, which indicates if ther is a wall in a given direction.
        /// 0 - is top, 1 - right, 2 - bottom, 3 - left side
        /// </summary>
        public bool[] Walls { get; set; }

        /// <summary>
        /// Holds the orientation of this tile. (0, -1) - Up, (0, 1) - Down, (-1, 0) - Left, (1, 0) - Right
        /// </summary>
        public Vector3 Orientation { get; set; }

        /// <summary>
        /// Hold the type of event for this Tile.
        /// </summary>
        public EventType Event { get; set; }

        /// <summary>
        /// Dictionary of EnemieTypes and their spwaningrate.
        /// </summary>
        public Dictionary<EnemyType, double> Enemies { get; set; }

        /// <summary>
        /// Dictionaray of Item which can be found on this Tile.
        /// Value is of type dynamic.
        /// </summary>
        public Dictionary<ItemCategory, dynamic> Items { get; set; }
        
        public Tile()
        {
            Type = TileType.ROOM;
            Orientation = new Vector3(0, -1, 0);
        }

        public Tile(TileType type, bool[] walls, EventType _event, Dictionary<EnemyType, double> enemies, Dictionary<ItemCategory, dynamic> items)
        {
            Type = type;
            Walls = walls;
            Event = _event;
            Enemies = enemies;
            Items = items;
        }

        public Item[] GetItems()
        {
            if (Items == null)
                return null;

            Item[] items = null;

            items = new Item[Items.Count()];

            int i = 0;

            foreach (KeyValuePair<ItemCategory, dynamic> pair in Items)
            {
                if (pair.Key == ItemCategory.BASICITEM)
                    items[i] = new BasicItem(pair.Key, (BasicItemType) pair.Value);
                else if (pair.Key == ItemCategory.ARMOR)
                    items[i] = new Armor(pair.Key, (ArmorType) pair.Value);
                else if (pair.Key == ItemCategory.WEAPON)
                    items[i] = new Weapon(pair.Key, (WeaponType) pair.Value);
                else if (pair.Key == ItemCategory.POTION)
                    items[i] = new Potion(pair.Key, (PotionType) pair.Value);

                i++;
            }
            
            return items;
        }

        public Boolean RemoveItem()
        {
            this.Items = null;    //ToDo
             
            return true;
        }
    }

    public static class Extension
    {
        public static bool TryGetTiles(this Tile[][] array, int index, out Tile[] element)
        {
            if (index < array.Length && index >= 0)
            {
                element = array[index];
                return true;
            }
            element = default(Tile[]);
            return false;
        }

        public static bool TryGetTile(this Tile[] array, int index, out Tile element)
        {
            if (array != null && index < array.Length && index >= 0)
            {
                element = array[index];
                return true;
            }
            element = default(Tile);
            return false;
        }
    }
}
