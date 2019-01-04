using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct Statement
    {
        /// <summary>
        /// Holds an array of DialogEntityNames, which represents the entitiey with that statement.
        /// </summary>
        public DialogueEntityName[] Speakers { get; set; }

        /// <summary>
        /// Holds text message of this Statement.
        /// </summary>
        public string Message { get; set; }

        public Statement(DialogueEntityName[] speakers, string message)
        {
            Speakers = speakers;
            Message = message;
        }

    }
}
