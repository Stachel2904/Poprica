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
        /// </summary>
        public bool[] Walls { get; set; }

        /// <summary>
        /// Holds the orientation of this tile. (0, -1) - Up, (0, 1) - Down, (-1, 0) - Left, (1, 0) - Right
        /// </summary>
        public Vector2 Orientation { get; set; }

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

        }

        public Tile(TileType type, bool[] walls, EventType _event, Dictionary<EnemyType, double> enemies)
        {
            Type = type;
            Walls = walls;
            Event = _event;
            Enemies = enemies;
        }
    }
}
