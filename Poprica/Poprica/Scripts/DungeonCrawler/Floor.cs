using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public sealed class Floor
    {
        /// <summary>
        /// Holds 2D array of Tiles which represents the Floor 
        /// </summary>
        public Tile[][] Tiles { get; set; }

        /// <summary>
        /// Index of that Floor.
        /// </summary>
        public int FloorNum { get; set; }

        public Vector3 DefaultEntryPoint { get; set; }

        public Floor()
        {

        }

        /// <summary>
        /// Gets the Tile at a given location.
        /// </summary>
        /// <param name="location">Location of Tile.</param>
        /// <returns>The Tile at the given location. Empty Tile if location is not found.</returns>
        public Tile GetTile(Vector2 location)
        {
            return null;
        }

        /// <summary>
        /// Gets location of a given Tile.
        /// </summary>
        /// <param name="tile">Tile which location should be returned.</param>
        /// <returns>vector3 with location of given Tile.</returns>
        public Vector3 GetLocation(Tile tile)
        {
            return Vector3.Zero;
        }
    }
}
