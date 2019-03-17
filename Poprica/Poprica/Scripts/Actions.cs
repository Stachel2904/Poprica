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

        public static void Sleep(int[] eventArgs)
        {

        }

        public static void Talk(int[] eventArgs)
        {
            if (eventArgs == null)
                return;

            DialogueEntityName[] entities = new DialogueEntityName[eventArgs.Length];

            for (int i = 0; i < eventArgs.Length; i++)
            {
                entities[i] = (DialogueEntityName)eventArgs[i];
            }

            Console.WriteLine("Starte Dialog");
            //ToDo
            //DialogueManager.Main.LoadNewDialogue(entities, ActionType.TALK);
        }

        public static void Leave(int[] eventArgs)
        {
            Menu.LoadNewScene(new int[] { (int)SceneType.MENU, (int)MenuType.MAINMENU });
        }
    }
}
