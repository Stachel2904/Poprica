using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class DialogueEntity
    {
        /// <summary>
        /// Holds the name of this Entity. Is element from enum DialogueEntityName.
        /// </summary>
        public DialogueEntityName Name { get; set; }

        /// <summary>
        /// Holds the location of this Entity. Is element from enum LocationType.
        /// </summary>
        public LocationType Location { get; set; }

        /// <summary>
        /// Holds the type of this Entity. Is element from enum DialogueEntityType.
        /// </summary>
        public DialogueEntityType Type { get; set; }

        /// <summary>
        /// Holds the position, on screen, of this Entity. Is element from enum DialogueEntityPositionType.
        /// </summary>
        public DialogueEntityPositionType Position { get; set; }

        private int age;

        public DialogueEntity(DialogueEntityName name)
        {
            Name = name;
        }
    }
}
