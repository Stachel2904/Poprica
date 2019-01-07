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

        private bool moved;

        public DungeonCrawler() : base(Poprica.SceneType.DUNGEONCRAWLER)
        {
            AllImages = new Poprica.Image[Poprica.Maps.ImageMap[(int)Poprica.ImageType.DUNGEONCRAWLER].Count()];
            moved = true;

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
                
                if (!Dungeon.Main.Floor.Tiles.TryGetTiles((int)(entryPoint.Y + orientation.Y * i), out currentRow))
                {
                    break;
                }

                if (!currentRow.TryGetTile((int)(entryPoint.X + orientation.X * i), out current))
                {
                    break;
                }
                
                Poprica.Image img;
                Rectangle rect = new Rectangle(ImagePos(i), new Point((int)(1920 / (Math.Pow(2, i))), (int)(1080 / (Math.Pow(2, i)))));

                if (current.Type == TileType.STRAIGHT && (current.Orientation == orientation || current.Orientation == -orientation))
                {
                    img = new Poprica.Image(Poprica.ImageType.DUNGEONCRAWLER, (int)ImageType.STRAIGHT, new Rectangle(new Point(i*100, i*100), new Point(1920-960*i, 1080-540*i)));
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    img = new Poprica.Image((int)ImageType.INTERSECTION, rect);
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation == orientation) //TODO : Orientierung der t-Kreuzung darf auch anders sein!
                {
                    img = new Poprica.Image((int)ImageType.TCROSS, rect);
                    this.Images.Add(img);
                }
                else if ((int) current.Type > (int)TileType.CONSTRUCTIONSIGN)
                {
                    AddImageField(new Vector2(entryPoint.X + orientation.X * i, entryPoint.Y + orientation.X * i), i);
                }
                else
                {

                    this.Images.Add(AllImages[(int)current.Type]);
                }
            }
        }


        public override void Update()
        {
            this.LoadImages();
        }

        private void AddImageField(Vector2 startPos, int step)
        {
            Poprica.Image imgLeft, img, imgRight;
            Rectangle rectLeft, rect, rectRight;

            Point pos = ImagePos(step);

            rectLeft = new Rectangle(new Point(pos.X - (int)(1920 / (Math.Pow(2, step))), pos.Y), new Point((int)(1920 / (Math.Pow(2, step))), (int)(1080 / (Math.Pow(2, step)))));
            rect = new Rectangle(pos, new Point((int)(1920 / (Math.Pow(2, step))), (int)(1080 / (Math.Pow(2, step)))));
            rectRight = new Rectangle( new Point(pos.X + (int)(1920 / (Math.Pow(2, step))), pos.Y), new Point((int)(1920 / (Math.Pow(2, step))), (int)(1080 / (Math.Pow(2, step)))));

            imgLeft = new Poprica.Image((int)Dungeon.Main.Floor.Tiles[(int)startPos.Y][(int)startPos.X-1].Type, rectLeft);
            img = new Poprica.Image((int)Dungeon.Main.Floor.Tiles[(int)startPos.Y][(int)startPos.X].Type, rect);
            imgRight = new Poprica.Image((int)Dungeon.Main.Floor.Tiles[(int)startPos.Y][(int)startPos.X+1].Type, rectRight);

            this.Images.Add(imgLeft);
            this.Images.Add(img);
            this.Images.Add(imgRight);
        }

        private Point ImagePos(int step)
        {
            return new Point(Poprica.MathFunctions.CalcPicturePosWidth(step), Poprica.MathFunctions.CalcPicturePosHeight(step));
        }
    }
}
