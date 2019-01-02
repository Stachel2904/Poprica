using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct Moment
    {
        /// <summary>
        /// Holds current day of this Memory.
        /// </summary>
        public int Day { get; set; }

        /// <summary>
        /// Holds current time of this Memory.
        /// </summary>
        public int Time { get; set; }

        public Moment(int day, int time)
        {
            Day = day;
            Time = time;
        }
    }
}
