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
        public bool Locked { get; set; }
        public WaifuStats Stats;
        public MoodType Mood { get; set; }
        public PoseType Pose { get; set; }
        public List<ClothesType> Clothes { get; set; }


        private Dictionary<ActionType, WaifuStats> consequences;

        public Waifu(DialogueEntityName name) : base(name)
        {
            Memories = new List<Memory>();
            Clothes = new List<ClothesType>();

            SetStandardStats();
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

        private void SetStandardStats()
        {
            //standard stats
            switch (this.Name)
            {
                case DialogueEntityName.RICA:
                    Location = LocationType.NONE;
                    Locked = true;
                    Mood = MoodType.NORMAL;
                    Pose = PoseType.NORMAL;
                    Stats = new WaifuStats(10, 10, 10, 10);
                    consequences = new Dictionary<ActionType, WaifuStats>
                    {
                        {ActionType.TALK, new WaifuStats(2, 1 , 0, -1) }
                    };
                    break;
            }
        }

        /// <summary>
        /// Debug Method .... maybe ...
        /// </summary>
        /// <param name="eventArgs"></param>
        public void SetMood(int[] eventArgs)
        {
            //Mood = (MoodType) eventArgs[0];
            if (Mood == MoodType.NORMAL)
                Mood = MoodType.SURPRISED;
            else
                Mood = MoodType.NORMAL;
        }

        /// <summary>
        /// Debug Method .... maybe ...
        /// </summary>
        /// <param name="eventArgs"></param>
        public void SetClothes(int[] eventArgs)
        {
            if (Clothes.Count != 0)
            {
                Clothes = new List<ClothesType>();
            }
            else
            {
                Clothes = new List<ClothesType>()
                {
                    ClothesType.BRABLACKT,
                    ClothesType.TANGABLACKT,
                    //ClothesType.DRESSBLUE
                };
            }
        }
    }
}
