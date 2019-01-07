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
        /// Holds the current rotation of the Player object. (0, -1) - Up, (0, 1) - Down, (-1, 0) - Left, (1, 0) - Right
        /// </summary>
        public Vector3 Rotation { get; set; }

        /// <summary>
        /// Holds the amount of health for the Player object.
        /// </summary>
        public int Health { get; set; }

        private Player()
        {
            Location = (Poprica.Progress.DungeonPos == null) ? Poprica.Progress.DungeonPos : Dungeon.Main.Floor.DefaultEntryPoint;
            Rotation = (Poprica.Progress.DungeonRot == null) ? Poprica.Progress.DungeonRot : new Vector3(0, -1, 0);

        }

        /// <summary>
        /// Moves the Player into a given direction.
        /// </summary>
        /// <param name="direction">Direction to move to.</param>
        public void Move(DirectionType direction)
        {
            switch (direction)
            {
                #region Move
                case DirectionType.FORWARD:
                    this.Location += this.Rotation;
                    break;
                case DirectionType.BACKWARD:
                    this.Location -= this.Rotation;
                    break;
                case DirectionType.RIGHT:
                    if (this.Rotation.Y < 0)
                    {
                        this.Location += Vector3.Right;
                    }
                    else if (this.Rotation.Y > 0)
                    {
                        this.Location += Vector3.Left;
                    }
                    else if (this.Rotation.X > 0)
                    {
                        this.Location += Vector3.Up;
                    }
                    else if (this.Rotation.X < 0)
                    {
                        this.Location += Vector3.Down;
                    }
                    break;
                case DirectionType.LEFT:
                    if (this.Rotation.Y < 0)
                    {
                        this.Location += Vector3.Left;
                    }
                    else if (this.Rotation.Y > 0)
                    {
                        this.Location += Vector3.Right;
                    }
                    else if (this.Rotation.X > 0)
                    {
                        this.Location += Vector3.Down;
                    }
                    else if (this.Rotation.X < 0)
                    {
                        this.Location += Vector3.Up;
                    }
                    break;
                #endregion
                #region Rotation
                case DirectionType.TURNRIGHT:
                    if (this.Rotation == Vector3.Down)
                    {
                        this.Rotation += (Vector3.One - Vector3.Backward);
                    }
                    else if (this.Rotation == Vector3.Up)
                    {
                        this.Rotation -= (Vector3.One - Vector3.Backward);
                    }
                    else if (this.Rotation == Vector3.Left)
                    {
                        this.Rotation += (Vector3.Right + Vector3.Down);
                    }
                    else if (this.Rotation == Vector3.Right)
                    {
                        this.Rotation += (Vector3.Left + Vector3.Up);
                    }
                    break;
                case DirectionType.TURNLEFT:
                    if (this.Rotation == Vector3.Down || this.Rotation == Vector3.Right)
                    {
                        this.Rotation -= (Vector3.One - Vector3.Backward);
                    }
                    else if (this.Rotation == Vector3.Up || this.Rotation == Vector3.Left)
                    {
                        this.Rotation += (Vector3.One - Vector3.Backward);
                    }
                    //else if (this.Rotation == Vector3.Left)
                    //{
                    //    this.Rotation += (Vector3.One - Vector3.Backward);
                    //}
                    //else if (this.Rotation == Vector3.Right)
                    //{
                    //    this.Rotation -= (Vector3.One - Vector3.Backward);
                    //}
                    break;
                #endregion
            }
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
