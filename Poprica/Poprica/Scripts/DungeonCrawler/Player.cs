using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public sealed class Player
    {

        #region Singleton
        private static Player main;

        public static Player Main
        {
            get
            {
                if(main == null)
                {
                    main = new Player();
                }

                return main;
            }
        }

        #endregion

        /// <summary>
        /// Holds the location of the Player object.
        /// </summary>
        public Vector3 Location { get; set; }

        /// <summary>
        /// Holds the amount of health for the Player object.
        /// </summary>
        public int Health { get; set; }

        private Player()
        {

        }

        /// <summary>
        /// Moves the Player into a given direction.
        /// </summary>
        /// <param name="direction">Direction to move to.</param>
        public void Move(DirectionType direction)
        {
            #region Move

            #endregion

            #region Rotation

            #endregion
        }

        /// <summary>
        /// Sets the loaction of the Player directly.
        /// </summary>
        /// <param name="newLocation">New Loaction (Floor, x-Axis, y-Axis)</param>
        /// <returns>True is SetLocation was succesful.</returns>
        public bool SetLocation(Vector3 newLocation)
        {
            return false;
        }

        /// <summary>
        /// Use a given Item.
        /// </summary>
        /// <param name="item">Item which should be used.</param>
        public void UseItem(Item item)
        {
            item.Use();
        }
    }
}
