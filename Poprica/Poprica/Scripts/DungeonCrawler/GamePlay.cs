using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace DungeonCrawler
{
    public static class GamePlay
    {
        /// <summary>
        /// Spawns Enemies into the Dungeon.
        /// </summary>
        public static void SpawnEnemies()
        {

        }

        /// <summary>
        /// Creates possible Actions for current DungeonTile
        /// </summary>
        public static void CreateActions(EventType _event)
        {
            //creates actions and buttons?
        }

        /// <summary>
        /// Updates current Gameplay stuff.
        /// </summary>
        public static void Update(EventType _event)
        {
            CreateActions(_event);
        }

        public static void Rescue(BasicItem key)
        {
            Tile tile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X, Player.Main.Location.Y));

            if (tile.Event == EventType.RESCUE)
            {
                Tile prisonerTile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X + Player.Main.Rotation.X, Player.Main.Location.Y + Player.Main.Rotation.Y));
                EventType type = prisonerTile.Event;
                prisonerTile.Event = EventType.PRISON;

                //ToDo change to dynamic Waifu
                Poprica.WaifuManager.Main.UnlockWaifu(DecodeEventTypeToWaifuName(type));
                Console.WriteLine("Rica auf Tasche");
            }
        }

        private static Poprica.DialogueEntityName DecodeEventTypeToWaifuName(EventType type)
        {
            switch (type)
            {
                case EventType.RICA:
                    Poprica.DialogueEntityName name = Poprica.DialogueEntityName.RICA;
                    Poprica.WaifuManager.Main.GetWaifu(name).Location = Poprica.LocationType.LIVINGROOM;
                    return name;

                default:
                    return Poprica.DialogueEntityName.RICA;
            }
        }
    }
}
