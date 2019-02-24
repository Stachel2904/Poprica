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
                prisonerTile.Event = EventType.PRISON;
                Console.WriteLine("Rica auf Tasche");
            }
        }
    }
}
