using System.Collections.Generic;

namespace Poprica
{
    public class SpeakerProberties
    {
        /// <summary>
        /// The facial Expression of this Speaker.
        /// </summary>
        public MoodType Mood { get; set; }

        /// <summary>
        /// The Pose of this Speaker.
        /// </summary>
        public PoseType Pose { get; set; }

        /// <summary>
        /// The Position on screen of this Speaker.
        /// </summary>
        public PositionType Position { get; set; }

        /// <summary>
        /// Contains Conditions, that must be true for this Statement.
        /// </summary>
        public Dictionary<TraitType, int> Conditions { get; set; }

        /// <summary>
        /// The Index to jump to, if one of the Conditions are false.
        /// </summary>
        public int FalseConditionJumpIndex { get; set; }

        /// <summary>
        /// Contains the Consequences if this Statement is finished.
        /// </summary>
        public Dictionary<TraitType, int> Consequences { get; set; }

        public SpeakerProberties()
        {
            Mood = MoodType.NORMAL;
            Pose = PoseType.NORMAL;
            Position = PositionType.RIGHT;
            Conditions = new Dictionary<TraitType, int>();
            FalseConditionJumpIndex = -1;
            Consequences = new Dictionary<TraitType, int>();
        }

        /// <summary>
        /// Creates a new SpeakerProberty
        /// </summary>
        /// <param name="mood">The facial Expression of this Speaker.</param>
        /// <param name="pose">The Pose of this Speaker.</param>
        /// <param name="position">The Position on screen of this Speaker.</param>
        public SpeakerProberties (MoodType mood, PoseType pose, PositionType position)
        {
            Mood = mood;
            Pose = pose;
            Position = position;
            Conditions = new Dictionary<TraitType, int>();
            FalseConditionJumpIndex = -1;
            Consequences = new Dictionary<TraitType, int>();
        }
    }
}