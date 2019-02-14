using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class Statement : DialogueElement
    {
        /// <summary>
        /// Holds an array of DialogEntityNames, which represents the entities declaring that statement. Additionally the Proberties are also linked.
        /// </summary>
        public Dictionary<DialogueEntityName, SpeakerProberties> Speakers { get; set; }

        /// <summary>
        /// Holds text message of this Statement.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// The Index of the next Statement inside the Dialogue. -1 if Ending, -2 if just one step forward.
        /// </summary>
        public int NextStatement { get; set; }

        public Statement() : base(DialogueElementType.STATEMENT)
        {
            Speakers = new Dictionary<DialogueEntityName, SpeakerProberties>();
            NextStatement = -2;
        }


        public Statement(DialogueEntityName[] speakers, MoodType[] moods, PoseType[] poses, PositionType[] positions, string message) : base(DialogueElementType.STATEMENT)
        {
            if(moods.Length != speakers.Length || poses.Length != speakers.Length || positions.Length != speakers.Length)
            {
                throw new Exception("The Speaker don't match the Proberties.");
            }

            Speakers = new Dictionary<DialogueEntityName, SpeakerProberties>();

            for (int i = 0; i < speakers.Length; i++)
            {
                Speakers.Add(speakers[i], new SpeakerProberties(moods[i], poses[i], positions[i]));
            }

            Message = message;
        }

    }
}
