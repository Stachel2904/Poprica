using System.Collections.Generic;

namespace Poprica
{
    public class Decision : DialogueElement
    {
        /// <summary>
        /// The Choices you have.
        /// </summary>
        public Dictionary<string, int> Choices { get; set; }

        public Decision() : base(DialogueElementType.DECISION)
        {
            Choices = new Dictionary<string, int>();
        }

        /// <summary>
        /// Creates new Decision.
        /// </summary>
        /// <param name="choices">The Choices you have.</param>
        /// <param name="newDialogueIndex">The Index of the Statement the Choices lead to.</param>
        public Decision(string[] choices, int[] newDialogueIndex) : base(DialogueElementType.DECISION)
        {
            if(choices.Length != newDialogueIndex.Length)
            {
                throw new System.Exception("The Choices don't match the Indices.");
            }

            for (int i = 0; i < choices.Length; i++)
            {
                Choices.Add(choices[i], newDialogueIndex[i]);
            }
        }
    }
}