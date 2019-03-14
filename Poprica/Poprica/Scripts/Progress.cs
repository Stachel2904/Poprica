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

            return false;
        }

        /// <summary>
        /// Loads a whole new savegame.
        /// </summary>
        /// <param name="slot">Describes the saveslot, which should be loaded. Default: 0</param>
        /// <returns>Returns true if load was succesful.</returns>
        public static bool Load(int slot = 0)
        {
            return false;
        }

        #region Main
        public static DateTime DateTime;
        public static Dictionary<DialogueEntityName, Waifu> waifus;
        #endregion

        #region DC
        public static Vector3 DungeonPos;
        public static Vector3 DungeonRot;
        #endregion

    }
}
