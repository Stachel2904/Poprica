using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class Dungeon
    {

        #region Singelton

        private static Dungeon main;

        public static Dungeon Main
        {
            get
            {
                if (main == null)
                {
                    main = new Dungeon();
                }

                return main;
            }
        }

        #endregion

        /// <summary>
        /// Holds the current Floor of the the dungeon.
        /// </summary>
        public Floor Floor { get; set; }

        /// <summary>
        /// Holds the index of the current Floor.
        /// </summary>
        public int FloorCount { get; set; }

        private Dictionary<int, string> FloorMap = new Dictionary<int, string>
        {
            { 0,  "Content/Json/DC/FloorTest.json"},

        };

        private Dungeon(int floor = 0)
        {
            FloorCount = floor;
            Floor = Poprica.DataManager.LoadJson<Floor>(new string[] { FloorMap[FloorCount]})[0];
        }

        /// <summary>
        /// Loads new Floor into the Dungeon.
        /// </summary>
        /// <param name="floor">Index of Floor which should be loaded.</param>
        /// <returns>True if load was succesful.</returns>
        public bool LoadFloor(int floor)
        {
            return false;
        }

        /// <summary>
        /// Refreshs the Dungeon. No idea hwta should happen here :D
        /// </summary>
        public void Refresh()
        {

        }

        /// <summary>
        /// Get possible direction to move to.
        /// </summary>
        /// <returns>Array of directions. Of type DirectionType.</returns>
        public DirectionType[] GetDirections()
        {
            return null;
        }
    }
}
