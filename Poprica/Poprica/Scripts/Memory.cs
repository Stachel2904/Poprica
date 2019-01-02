using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct Memory
    {
        /// <summary>
        /// Holds the type of this Memory. Is element of MemoryType
        /// </summary>
        public MemoryType Type { get; set; }

        /// <summary>
        /// Holds the moment of this Memory. Is of Type Memory.
        /// </summary>
        public Moment Moment { get; set; }

        public Memory(MemoryType type, Moment moment)
        {
            Type = type;
            Moment = moment;
        }
    }
}
