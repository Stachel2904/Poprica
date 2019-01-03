using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonCrawler
{
    public sealed class Inventory
    {

        #region Singelton

        private static Inventory main;

        public static Inventory Main
        {
            get
            {
                if (main == null)
                {
                    main = new Inventory();
                }

                return main;
            }
        }
        #endregion

        public Dictionary<Item, int> Items { get; set; }

        private Inventory()
        {

        }

        /// <summary>
        /// Load the Inventory from the Progress class.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Saves the Inventory form the Progress class.
        /// </summary>
        public void Save()
        {

        }

        /// <summary>
        /// Adds a Item to the Items field. (To the Inventory)
        /// </summary>
        /// <param name="item">The Item which should be added.</param>
        /// <param name="amount">The amount, of how many of these Items should be added. Default: 1</param>
        public void Additem(Item item, int amount = 1)
        {
            if (!Items.ContainsKey(item))
            {
                Items.Add(item, amount);
            }
            else
            {
                Items[item] += amount;
            }
        }

        /// <summary>
        /// Gets the amount of these Items in the Inventory.
        /// </summary>
        /// <param name="item">Item which should be checked.</param>
        /// <returns>Amount of this Item in Inventory.</returns>
        public int GetAmount(Item item)
        {
            return (Items.ContainsKey(item)) ? Items[item] : 0;
        }

        /// <summary>
        /// Removes given amount of Item from the Inventory.
        /// </summary>
        /// <param name="item">Item which should be removed.</param>
        /// <param name="amount">The amount, of how many of these Items should be removed. Default: 1</param>
        /// <returns>True if Items removed succesful.</returns>
        public bool RemoveItem(Item item, int amount = 1)
        {
            if (Items.ContainsKey(item))
            {
                if (Items[item] <= amount)
                {
                    Items[item] = 0;
                }
                else
                {
                    Items[item] -= amount;
                }

                return true;
            }

            return false;
        }

    }
}
