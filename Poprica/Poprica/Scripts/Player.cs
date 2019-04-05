using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class Player
    {

        #region Singleton
        private static Player _main;

        public static Player Main
        {
            get
            {
                if (_main == null)
                {
                    _main = new Player();
                }

                return _main;
            }
        }
        #endregion

        public int Money { get; set; }
        public string Name { get; set; }

        protected Player()
        {
            Money = 100;

        }

        /// <summary>
        /// Adds a gieven amount of money ontop of the current money.
        /// </summary>
        /// <param name="amount">Amount which is to add.</param>
        public virtual void GetMoney(int amount)
        {
            Money += amount;
        }
    }
}
