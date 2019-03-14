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

        public DateTime CheckTime()
        {
            return DateTime;
        }

        public void SetTime(DateTime newDateTime)
        {
            DateTime = newDateTime;
        }

        public void IncreaseTime(int minutes)
        {
            DateTime.AddMinutes(minutes);
        }

        public void IncreaseDay(int days)
        {
            DateTime.AddDays(days);
        }



    }
}
