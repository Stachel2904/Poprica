using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public sealed class DungeonCrawler<T> : Poprica.MiniGame<T>
    {

        /// <summary>
        /// Holds the state of the DungeonCrawler game.
        /// </summary>
        public GameStateType State { get; set; }

        /// <summary>
        /// Bib for all DC images.
        /// </summary>
        private Poprica.Image<T>[] AllImages { get; set; }

        public DungeonCrawler() : base()
        {

        }

        /// <summary>
        /// Loads all Images of the DungeonCrawler.
        /// </summary>
        private void InitImages()
        {
            Poprica.Image<ImageType> img;
            Rectangle rect = new Rectangle(Point.Zero, Point.Zero);

            for(int i = 0; i < Poprica.Maps.DungeonCrawlerImageMap.Count(); i++)
            {
                img = new Poprica.Image<ImageType>((ImageType)i, rect);

            }
        }

        /// <summary>
        /// Loads Images which should be displayed.
        /// </summary>
        public override void LoadImages()
        {
            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image<T>>();

            Point entryPoint = Dungeon.Main.Floor.DefaultEntryPoint;

            for (int i = 0; i < 6; i++)
            {
                Tile current = Dungeon.Main.Floor.Tiles[entryPoint.X + i][entryPoint.Y + i];

                if (current.Type == TileType.STRAIGHT && (current.Orientation == Player.Main.Rotation || current.Orientation == -Player.Main.Rotation))
                {
                    this.Images.Add(AllImages[(int)ImageType.STRAIGHT]);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    this.Images.Add(AllImages[(int)ImageType.INTERSECTION]);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation == Player.Main.Rotation) //TODO : Orientierung der t-Kreuzung darf auch anders sein!
                {
                    this.Images.Add(AllImages[(int)ImageType.TCROSS]);
                }
                else
                {
                    this.Images.Add(AllImages[(int)current.Type]);
                }
            }
        }


    }
}
