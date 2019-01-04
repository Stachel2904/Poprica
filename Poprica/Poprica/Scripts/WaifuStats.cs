using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct WaifuStats
    {
        /// <summary>
        /// Displays the affection.
        /// </summary>
        public int Affection { get; set; }

        /// <summary>
        /// Displays the obedience.
        /// </summary>
        public int Obedience { get; set; }

        /// <summary>
        /// Displays the hornyness.
        /// </summary>
        public int Hornyness { get; set; }

        /// <summary>
        /// Displays the stamina.
        /// </summary>
        public int Stamina { get; set; }

        public WaifuStats(int affection, int obedience, int hornyness, int stamina)
        {
            Affection = affection;
            Obedience = obedience;
            Hornyness = hornyness;
            Stamina = stamina;
        }
    }
}
