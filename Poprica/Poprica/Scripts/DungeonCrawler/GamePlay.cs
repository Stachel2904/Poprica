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
        public static Poprica.Action[] CreateActions(EventType _event)
        {
            List<Poprica.Action> actions = new List<Poprica.Action>();

            if (_event == EventType.RESCUE)
            {
                foreach (Item item in Inventory.Main.Items.Keys)
                {
                    if (item.Category == ItemCategory.BASICITEM && (item as BasicItem).Type == BasicItemType.KEY)
                    {
                        Tile prisonerTile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X + Player.Main.Rotation.X, Player.Main.Location.Y + Player.Main.Rotation.Y));

                        if (prisonerTile.Event >= EventType.RICA)
                        {
                            //actionButtons.Add(Poprica.ButtonType.RESCUE);
                            actions.Add(new Poprica.Action(Poprica.ActionType.RESCUE, null));
                        }
                    }
                }
                
            }

            return actions.ToArray();
        }

        /// <summary>
        /// Updates current Gameplay stuff.
        /// </summary>
        public static void Update(EventType _event)
        {
            CreateActions(_event);
        }

        public static bool Rescue(BasicItem key)
        {
            Tile tile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X, Player.Main.Location.Y));
            Tile prisonerTile = Dungeon.Main.Floor.GetTile(new Vector2(Player.Main.Location.X + Player.Main.Rotation.X, Player.Main.Location.Y + Player.Main.Rotation.Y));
            
            if (tile.Event == EventType.RESCUE && prisonerTile.Event >= EventType.RICA)
            {
                EventType type = prisonerTile.Event;
                prisonerTile.Event = EventType.PRISON;

                //ToDo change to dynamic Waifu
                Poprica.WaifuManager.Main.UnlockWaifu(DecodeEventTypeToWaifuName(type));
                Console.WriteLine("Waifu auf Tasche");

                return true;
            }

            return false;
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
