using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class TimeManager
    {

        #region Singleton

        private static TimeManager main;

        public static TimeManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new TimeManager();
                }
                return main;
            }
        }

        #endregion

        public DateTime DateTime { get; set; }

        private TimeManager()
        {
            DateTime = Progress.DateTime;
        }

        /// <summary>
        /// Returns the current in-game time.
        /// </summary>
        /// <returns>Date time object, which hold current date time.</returns>
        public DateTime CheckTime()
        {
            return DateTime;
        }

        /// <summary>
        /// Sets in-game time to a given date time.
        /// </summary>
        /// <param name="newDateTime">The new game time to set.</param>
        public void SetTime(DateTime newDateTime)
        {
            DateTime = newDateTime;
        }

        /// <summary>
        /// Increases the in-game time.
        /// </summary>
        /// <param name="minutes">Time amount to increase in-game time, in minutes.</param>
        public void IncreaseTime(int minutes)
        {
            DateTime = DateTime.AddMinutes(minutes);
        }

        /// <summary>
        /// Increase the in-game time.
        /// </summary>
        /// <param name="days">Time amount to increase in-game time, in days.</param>
        public void IncreaseDay(int days)
        {
            DateTime = DateTime.AddDays(days);
        }



    }
}
