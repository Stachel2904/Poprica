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
            Tiles = new Tile[][]
            {
                new Tile[]
                {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                },
                new Tile[]
                {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                },
                new Tile[]
                {
                    new Tile(),
                    new Tile(),
                    new Tile(),
                }
            };

            DefaultEntryPoint = new Vector3(1, 2, 0);
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

        /// <summary>
        /// Calculates the Neighbours of a Tile with a given location.
        /// </summary>
        /// <param name="pos">Position of Tile which neighbours should be calculated.</param>
        /// <returns>Array of Vector3, Positions of Neighbours.</returns>
        public Vector3[] CalculateNeighbours(Vector3 pos)
        {
            return null;
        }
    }
}
