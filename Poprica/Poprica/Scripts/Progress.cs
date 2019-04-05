using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public static class Progress
    {
        /// <summary>
        /// Saves the whole progress of the game.
        /// </summary>
        /// <param name="slot">Describes the saveslot which should be saved. Default: 0</param>
        /// <returns>Returns true if save was succesful.</returns>
        public static bool Save(int slot = 0)
        {
            try
            {
                Dictionary<string, dynamic> gameData = new Dictionary<string, dynamic>()
                {
                    {
                        "DateTime",
                        TimeManager.Main.DateTime
                    }
                };

                Dictionary<DialogueEntityName, Waifu> waifuData = WaifuManager.Main.GetWaifus();
                
                DataManager.SaveJson<Dictionary<string, dynamic>>(gameData, "Content/Json/SaveGames/0/gameData.json");
                DataManager.SaveJson<Dictionary<DialogueEntityName, Waifu>>(waifuData, "Content/Json/SaveGames/0/waifuData.json");
                DataManager.SaveJson<DungeonCrawler.Player>(DungeonCrawler.Player.Main, "Content/Json/SaveGames/0/player.json");
                DataManager.SaveJsonDict<DungeonCrawler.Inventory>(DungeonCrawler.Inventory.Main, "Content/Json/SaveGames/0/inventory.json");
                DataManager.SaveJson<DungeonCrawler.Floor>(DungeonCrawler.Dungeon.Main.Floor, "Content/Json/SaveGames/0/floor.json");

                Console.WriteLine("Save!");

                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("Save nicht!");

                return false;
            }
        }

        /// <summary>
        /// Loads a whole new savegame.
        /// </summary>
        /// <param name="slot">Describes the saveslot, which should be loaded. Default: 0</param>
        /// <returns>Returns true if load was succesful.</returns>
        public static bool Load(int slot = 0)
        {
            try
            {
                Dictionary<string, dynamic> gameData;
                Dictionary<DialogueEntityName, Waifu> waifuData;

                gameData = DataManager.LoadJson<Dictionary<string, dynamic>>("Content/Json/SaveGames/0/gameData.json");

                TimeManager.Main.SetTime((DateTime)gameData["DateTime"]);

                waifuData = DataManager.LoadJson<Dictionary<DialogueEntityName, Waifu>>("Content/Json/SaveGames/0/waifuData.json");

                Console.WriteLine(waifuData[DialogueEntityName.RICA].Locked);

                WaifuManager.Main.SetWaifus((Dictionary<DialogueEntityName, Waifu>)waifuData);

                DungeonCrawler.Player playerData = DataManager.LoadJson<DungeonCrawler.Player>("Content/Json/SaveGames/0/player.json");

                DungeonCrawler.Player.Main.Location = playerData.Location;
                DungeonCrawler.Player.Main.Rotation = playerData.Rotation;

                DungeonCrawler.Dungeon.Main.Floor = DataManager.LoadJson<DungeonCrawler.Floor>("Content/Json/SaveGames/0/floor.json");

                DungeonCrawler.Inventory inventoryData = DataManager.LoadJsonDict<DungeonCrawler.Inventory>("Content/Json/SaveGames/0/inventory.json");

                DungeonCrawler.Inventory.Main.Items = inventoryData.Items;
                DungeonCrawler.Inventory.Main.ActiveItem = inventoryData.ActiveItem;

                Console.WriteLine("Load!");

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("load nicht!");

                return false;
            }
        }

        #region Main
        public static DateTime DateTime = DateTime.Now;
        public static Dictionary<DialogueEntityName, Waifu> waifus;
        #endregion

        #region DC
        public static Vector3 DungeonPos;
        public static Vector3 DungeonRot;
        #endregion

    }
}
