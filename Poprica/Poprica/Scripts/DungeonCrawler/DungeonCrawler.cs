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

        private bool moved;

        public DungeonCrawler() : base()
        {
            AllImages = new Poprica.Image<T>[Poprica.Maps.DungeonCrawlerImageMap.Count()];
            moved = false;
        }

        /// <summary>
        /// Loads all Images of the DungeonCrawler.
        /// </summary>
        private void InitImages()
        {
            Poprica.Image<T> img;
            Rectangle rect = new Rectangle(Point.Zero, Point.Zero);

            for(int i = 0; i < Poprica.Maps.DungeonCrawlerImageMap.Count(); i++)
            {
                img = new Poprica.Image<T>((T)(object)i, rect);
                AllImages[i] = img;
            }
        }

        /// <summary>
        /// Loads Images which should be displayed.
        /// </summary>
        public override void LoadImages()
        {
            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image<T>>();

            Vector3 entryPoint = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;

            for (int i = 0; i < 6; i++)
            {
                Tile current = Dungeon.Main.Floor.Tiles[(int)(entryPoint.X + orientation.X*i)][(int)(entryPoint.Y + orientation.X*i)];

                if (current.Type == TileType.STRAIGHT && (current.Orientation == orientation || current.Orientation == -orientation))
                {
                    this.Images.Add(AllImages[(int)ImageType.STRAIGHT]);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    this.Images.Add(AllImages[(int)ImageType.INTERSECTION]);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation == orientation) //TODO : Orientierung der t-Kreuzung darf auch anders sein!
                {
                    this.Images.Add(AllImages[(int)ImageType.TCROSS]);
                }
                else
                {
                    this.Images.Add(AllImages[(int)current.Type]);
                }
            }
        }

        public override void Update()
        {
            if (moved)
            {
                this.LoadImages();
            }
            
        }


    }
}
