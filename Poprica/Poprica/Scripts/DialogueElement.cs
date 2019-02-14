namespace Poprica
{
    public class DialogueElement
    {
        /// <summary>
        /// The Type of this DialogueElement
        /// </summary>
        public DialogueElementType Type { get; private set; }
        
        /// <summary>
        /// Creates new DialogueElement.
        /// </summary>
        /// <param name="type">The Type of this new DialogueElement.</param>
        public DialogueElement(DialogueElementType type)
        {
            Type = type;
        }
    }
}