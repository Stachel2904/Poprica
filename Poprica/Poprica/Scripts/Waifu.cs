using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class Waifu : DialogueEntity
    {

        /// <summary>
        /// Holds a list of Memories of this Waifu, representing previous key actions with this Waifu.
        /// </summary>
        public List<Memory> Memories { get; set; }

        private Dictionary<ActionType, WaifuStats> consequences;
        private WaifuStats stats;

        public Waifu()
        {

        }

        /// <summary>
        /// Adds a new Memory to the memories List of this Waifu.
        /// </summary>
        /// <param name="memory">The Memory which should be added.</param>
        public void AddMemory(Memory memory)
        {

        }

        /// <summary>
        /// Returns the the consequences which will result for a given Action at a specific "time".
        /// </summary>
        /// <param name="action"></param>
        private WaifuStats GetConsequences(ActionType action)
        {

            return null;
        }
    }
}
