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

        public Tile()
        {
            Type = TileType.ROOM;
            Orientation = new Vector3(0, -1, 0);
        }

        public Tile(TileType type, bool[] walls, EventType _event, Dictionary<EnemyType, double> enemies)
        {
            Type = type;
            Walls = walls;
            Event = _event;
            Enemies = enemies;
        }

        public Item[] GetItems()
        {
            Item[] items = null;

            if (this.Event == EventType.KEYRICA)
            {
                items = new Item[] { new BasicItem(ItemCategory.BASICITEM, BasicItemType.KEYRICA) };
            }

            return items;
        }

        public Boolean RemoveItem()
        {
            this.Event = EventType.NONE;

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
            if (index < array.Length && index >= 0)
            {
                element = array[index];
                return true;
            }
            element = default(Tile);
            return false;
        }
    }
}
