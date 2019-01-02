using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public static class Actions
    {

        private static Dictionary<Action, System.Action> actions;
        private static Action currentAction;

        /// <summary>
        /// Gets all possible Actions for given entities and the current location.
        /// </summary>
        /// <param name="location">Current Location, element of LocationType enum.</param>
        /// <param name="names">Array of names of all present entities.</param>
        /// <returns>Returns array of possible Actions.</returns>
        public static Action[] GetAllPossibleActions(LocationType location, DialogueEntityName[] names)
        {

            return null;
        }

        /// <summary>
        /// Calls the given Action.
        /// </summary>
        /// <param name="action">Action which should be called.</param>
        public static void CallAction(Action action)
        {

        }

        private static void Sleep()
        {

        }

        private static void Talk()
        {

        }
    }
}
