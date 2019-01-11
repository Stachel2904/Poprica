﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using static DungeonCrawler.Tile;

namespace DungeonCrawler
{
    public sealed class DungeonCrawler : Poprica.MiniGame
    {

        /// <summary>
        /// Holds the state of the DungeonCrawler game.
        /// </summary>
        public GameStateType State { get; set; }

        /// <summary>
        /// Bib for all DC images.
        /// </summary>
        private Poprica.Image[] AllImages { get; set; }
        
        public DungeonCrawler() : base(Poprica.SceneType.DUNGEONCRAWLER)
        {
            AllImages = new Poprica.Image[Poprica.Maps.ImageMap[(int)Poprica.ImageType.DUNGEONCRAWLER].Count()];

            InitImages();
        }

        /// <summary>
        /// Loads all Images of the DungeonCrawler.
        /// </summary>
        private void InitImages()
        {
            Poprica.Image img;
            Rectangle rect = new Rectangle(Point.Zero, Point.Zero);

            for(int i = 0; i < Poprica.Maps.ImageMap[(int)Poprica.ImageType.DUNGEONCRAWLER].Count(); i++)
            {
                img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, i, rect);
                AllImages[i] = img;
            }
        }

        /// <summary>
        /// Loads Images which should be displayed.
        /// </summary>
        public override void LoadImages()
        {

            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image>();

            Vector3 entryPoint = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;

            for (int i = 0; i < 6; i++)
            {
                Tile current = null;
                Tile[] currentRow = null;
                
                if (!Dungeon.Main.Floor.Tiles.TryGetTiles((int)(entryPoint.Y + orientation.Y * (i+1)), out currentRow))
                {
                    break;
                }

                if (!currentRow.TryGetTile((int)(entryPoint.X + orientation.X * (i+1)), out current))
                {
                    break;
                }
                
                Poprica.Image img;
                Rectangle rect = new Rectangle(ImagePos(i), new Point((int)(1920 / (Math.Pow(2, i))), (int)(1080 / (Math.Pow(2, i)))));

                if (current.Type == TileType.STRAIGHT && (current.Orientation == orientation || current.Orientation == -orientation))
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.STRAIGHT, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.INTERSECTION, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.RIGHTTURN || current.Type == TileType.LEFTTURN)
                {
                    int imageNum = 0;

                    if (orientation == current.Orientation)
                    {
                        imageNum = (int)ImageType.RIGHTTURN;
                    }
                    else
                    {
                        imageNum = (int)ImageType.LEFTTURN;
                    }

                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imageNum, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation != orientation) //TODO : Orientierung der t-Kreuzung darf auch anders sein!
                {
                    int imageNum = 0;

                    if (orientation + current.Orientation == Vector3.Zero)
                    {
                        imageNum = (int) ImageType.TRCOSSMAIN;
                    }
                    else
                    {
                        imageNum = GetTcrossImageFromOrientation(orientation, current.Orientation);
                    }

                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, imageNum, rect);
                    this.Images.Add(img);
                }
                else if ((int) current.Type > (int)TileType.CONSTRUCTIONSIGN)
                {
                    AddImageField(new Vector2(entryPoint.X + orientation.X * i, entryPoint.Y + orientation.X * i), i);
                }
                else
                {
                    //img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.NONE, rect);
                    //this.Images.Add(img);
                    //this.Images.Add(AllImages[(int)current.Type]);
                }
            }
        }


        public override void Update()
        {
            this.LoadImages();
        }

        private void AddImageField(Vector2 startPos, int step)
        {
            Vector3 playerRot = Player.Main.Rotation;

            Poprica.Image imgLeft, img, imgRight;
            Rectangle rectLeft, rect, rectRight;

            Point pos = ImagePos(step);
            Point size = new Point((int)(1920 / (Math.Pow(2, step))), (int)(1080 / (Math.Pow(2, step))));

            rectLeft = new Rectangle(new Point(pos.X - (int)(1920 / (Math.Pow(2, step))), pos.Y), size);
            rect = new Rectangle(pos, size);
            rectRight = new Rectangle( new Point(pos.X + (int)(1920 / (Math.Pow(2, step))), pos.Y), size);

            imgLeft = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)Dungeon.Main.Floor.Tiles[(int)(startPos.Y - playerRot.Y)][(int)(startPos.X - playerRot.X)].Type, rectLeft);
            img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)Dungeon.Main.Floor.Tiles[(int)startPos.Y][(int)startPos.X].Type, rect);
            imgRight = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)Dungeon.Main.Floor.Tiles[(int)(startPos.Y + playerRot.Y)][(int)(startPos.X + playerRot.X)].Type, rectRight);

            this.Images.Add(imgLeft);
            this.Images.Add(img);
            this.Images.Add(imgRight);
        }

        /// <summary>
        /// Returns an int, which represents the orientation of the image of the TCross.
        /// </summary>
        /// <param name="player">Vector3 which represents the players rotation.</param>
        /// <param name="tile">Vector3, which represents the tile orientation.</param>
        /// <returns>Index for ImaageType enum.</returns>
        private int GetTcrossImageFromOrientation(Vector3 player, Vector3 tile)
        {
            int num = 0;

            if (player == Vector3.Down)
            {
                if (tile == Vector3.Left)
                    num = 18;
                else
                    num = 17;
            }
            else if (player == Vector3.Right)
            {
                if (tile == Vector3.Up)
                    num = 17;
                else
                    num = 18;
            }
            else if (player == Vector3.Up)
            {
                if (tile == Vector3.Left)
                    num = 17;
                else
                    num = 18;
            }
            else if (player == Vector3.Left)
            {
                if (tile == Vector3.Down)
                    num = 17;
                else
                    num = 18;
            }

            return num;
        }
      
        private Point ImagePos(int step)
        {
            return new Point(Poprica.MathFunctions.CalcPicturePosWidth(step), Poprica.MathFunctions.CalcPicturePosHeight(step));
        }
    }
}
