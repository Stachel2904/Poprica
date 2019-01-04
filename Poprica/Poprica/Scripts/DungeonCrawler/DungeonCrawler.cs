using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class DungeonCrawler : Poprica.MiniGame
    {

        /// <summary>
        /// Holds the state of the DungeonCrawler game.
        /// </summary>
        public GameStateType State { get; set; }

        private Poprica.Image[] AllImages { get; set; }

        public DungeonCrawler() : base()
        {

        }

        public void InitImages()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public override void LoadImages()
        {
            //TODO: Find latest Location in Dungeon and load these, from Progess-Class

            this.Images = new List<Poprica.Image>();

            for(int i = 0; i < 6; i++)
            {
                if (Dungeon.Main.Floor.Tiles[Dungeon.Main.Floor.DefaultEntryPoint.X + i][Dungeon.Main.Floor.DefaultEntryPoint.Y + i].Type == TileType.STRAIGHT)
                {
                    this.Images.Add(AllImages[(int)ImageType.STRAIGHT]);
                }
                else if (Dungeon.Main.Floor.Tiles[Dungeon.Main.Floor.DefaultEntryPoint.X + i][Dungeon.Main.Floor.DefaultEntryPoint.Y + i].Type == TileType.INTERSECTION)
                {

                }
            }

            //this.Images.Add(Poprica.Maps.)
        }
    }
}
