using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct Action
    {
        /// <summary>
        /// Holds the type of this Action. Is element of ActionType enum.
        /// </summary>
        public ActionType Type { get; set; }

        /// <summary>
        /// Holds the entity names which are involed in this action.
        /// </summary>
        public DialogueEntityName[] DialogueEntities { get; set; }

        public Action(ActionType type, DialogueEntityName[] names)
        {
            Type = type;
            DialogueEntities = names;
        }
    }
}
