using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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

        public DungeonCrawler() : base(Poprica.NamespaceType.DUNGEONCRAWLER)
        {
            AllImages = new Poprica.Image[Poprica.Maps.ImageMap[(int)Poprica.NamespaceType.DUNGEONCRAWLER].Count()];
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

            for(int i = 0; i < Poprica.Maps.ImageMap[(int)Poprica.NamespaceType.DUNGEONCRAWLER].Count(); i++)
            {
                img = new Poprica.Image(i, rect);
                AllImages[i] = img;
            }
        }

        /// <summary>
        /// Loads Images which should be displayed.
        /// </summary>
        public override void LoadImages()
        {
            if (!moved)
            {
                return;
            }

            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image>();

            Vector3 entryPoint = Player.Main.Location;
            Vector3 orientation = Player.Main.Rotation;

            for (int i = 0; i < 6; i++)
            {
                Tile current;
                Tile[] currentRow = Dungeon.Main.Floor.Tiles.ElementAtOrDefault<Tile[]>((int)(entryPoint.X + orientation.X * i));
                if (currentRow != null)
                {
                    current = currentRow.ElementAtOrDefault<Tile>((int)(entryPoint.Y + orientation.X * i));
                }
                else
                {
                    break;
                }

                Poprica.Image img;

                if (current.Type == TileType.STRAIGHT && (current.Orientation == orientation || current.Orientation == -orientation))
                {
                    img = new Poprica.Image((int)ImageType.STRAIGHT, new Rectangle(new Point(i*100, i*100), new Point(1920-960*i, 1080-540*i)));
                    this.Images.Add(img);
                }
                else if (current.Type == TileType.INTERSECTION)
                {
                    this.Images.Add(AllImages[(int)ImageType.INTERSECTION]);
                }
                else if (current.Type == TileType.TCROSS && current.Orientation == orientation) //TODO : Orientierung der t-Kreuzung darf auch anders sein!
                {
                    this.Images.Add(AllImages[(int)ImageType.TCROSS]);
                }
                else if ((int) current.Type > (int)TileType.CONSTRUCTIONSIGN)
                {
                    AddImageField(new Vector2(entryPoint.X + orientation.X * i, entryPoint.Y + orientation.X * i));
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

        private void AddImageField(Vector2 startPos)
        {

        }
    }
}
