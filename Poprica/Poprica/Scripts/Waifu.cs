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
        public LocationType Location { get; set; }
        public bool Locked { get; set; }
        public WaifuStats stats;

        private Dictionary<ActionType, WaifuStats> consequences;

        public Waifu(DialogueEntityName name) : base(name)
        {
            Memories = new List<Memory>();
            //standard stats
            switch (name)
            {
                case DialogueEntityName.RICA:
                    Location = LocationType.LIVINGROOM;
                    Locked = true;
                    stats = new WaifuStats(10, 10, 10, 10);
                    consequences = new Dictionary<ActionType, WaifuStats>
                    {
                        {ActionType.TALK, new WaifuStats(2, 1 , 0, -1) }
                    };
                    break;
            }
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

            return consequences[action];
        }
    }
}
