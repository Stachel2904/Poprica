using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class WaifuManager
    {
        #region Singleton
        private static WaifuManager main;

        public static WaifuManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new WaifuManager();
                }
                return main;
            }
        }
        #endregion

        private List<Waifu> waifus;
        private List<Waifu> party;

        private WaifuManager()
        {
            waifus = new List<Waifu>();
            party = new List<Waifu>();
        }

        /// <summary>
        /// Change the location of a Waifu.
        /// </summary>
        /// <param name="name">The name of the Waifu.</param>
        /// <param name="newLocation">The new location of the Waifu.</param>
        public void ChangeLocation(DialogueEntityName name, LocationType newLocation)
        {

        }

        /// <summary>
        /// Get the Waifu from a name.
        /// </summary>
        /// <param name="name">The name of the Waifu you want.</param>
        /// <returns>Returns the Waifu you want.</returns>
        public Waifu GetWaifu(DialogueEntityName name)
        {

        }

        /// <summary>
        /// Get the location of a Waifu.
        /// </summary>
        /// <param name="name">The name of the Waifu, which location you want.</param>
        /// <returns>Returns the location of the given Waifu.</returns>
        public LocationType GetLocation (DialogueEntityName name)
        {

        }
    }
}
