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
        public void Move(int[] eventArgs)
        {
            DirectionType direction = (DirectionType)eventArgs[0];
            
            if (!Allowed(direction))
                return;

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
                        this.Rotation = Vector3.Right;
                    }
                    else if (this.Rotation == Vector3.Up)
                    {
                        this.Rotation = Vector3.Left;
                    }
                    else if (this.Rotation == Vector3.Left)
                    {
                        this.Rotation = Vector3.Down;
                    }
                    else if (this.Rotation == Vector3.Right)
                    {
                        this.Rotation = Vector3.Up;
                    }
                    break;
                case DirectionType.TURNLEFT:
                    if(this.Rotation == Vector3.Down)
                    {
                        this.Rotation = Vector3.Left;
                    }
                    else if(this.Rotation == Vector3.Up)
                    {
                        this.Rotation = Vector3.Right;
                    }
                    else if(this.Rotation == Vector3.Left)
                    {
                        this.Rotation = Vector3.Up;
                    }
                    else if(this.Rotation == Vector3.Right)
                    {
                        this.Rotation = Vector3.Down;
                    }
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

        /// <summary>
        /// Returns if the tried movement action is legal.
        /// </summary>
        /// <param name="dir">Direction to try to move to.</param>
        /// <returns>True if the movment is leagl.</returns>
        public bool Allowed(DirectionType dir)
        {
            if ((int)dir > 3)
                return true;

            Tile current = Dungeon.Main.Floor.Tiles[(int)this.Location.Y][(int)this.Location.X];
            int index = 0;
            
            if (this.Rotation == Vector3.Down)
            {
                index = (int)dir;
            }
            else if (this.Rotation == Vector3.Right)
            {
                index = ((int)dir + 1 < 4) ? (int)dir +1 : 0;
            }
            else if (this.Rotation == Vector3.Up)
            {
                index = ((int)dir + 2 < 4) ? (int)dir + 2 : (((int)dir + 1 < 4) ? 0 : 1);
            }
            else if (this.Rotation == Vector3.Left)
            {
                index = ((int)dir - 1 > 0) ? (int)dir - 1 : 3;
            }

            if (!current.Walls[index])
                return true;
            else
                return false;
        }

        /// <summary>
        /// Updates the Players Inventory, calls Inventory Class.
        /// </summary>
        public void UpdateInventory()
        {
            Tile tile = Dungeon.Main.Floor.GetTile(new Vector2(this.Location.X, this.Location.Y));

            if (tile == null)
            {
                return;
            }
            
            Item[] items = tile.GetItems();

            if(items == null)
                return;

            tile.RemoveItem();

            for (int i = 0; i < items.Length; i++)
            {
                Inventory.Main.Additem(items[i]);
            }
        }
    }
}
