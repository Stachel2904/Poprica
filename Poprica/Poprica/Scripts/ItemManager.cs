using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class ItemManager
    {
        #region Singleton
        private static ItemManager main;

        public static ItemManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new ItemManager();
                }
                return main;
            }
        }
        #endregion

        private ItemManager()
        {

        }
    }
}
