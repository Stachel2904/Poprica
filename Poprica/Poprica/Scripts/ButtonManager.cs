using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class ButtonManager
    {
        #region Singleton
        private static ButtonManager main;

        public static ButtonManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new ButtonManager();
                }
                return main;
            }
        }
        #endregion

        private Dictionary<Button, Action> actionButtons;
        private Button[] menuButtons;

        private ButtonManager()
        {

        }

        /// <summary>
        /// Create a Button for each Action.
        /// </summary>
        /// <param name="actions">The Actions linked to the Buttons</param>
        public void CreateButtons(Action[] actions)
        {

        }

        /// <summary>
        /// Create a Button for each Location.
        /// </summary>
        /// <param name="locations">The Locations linked to the Buttons</param>
        public void CreateButtons(LocationType[] locations)
        {

        }

        /// <summary>
        /// Create a Button for each ButtonType.
        /// </summary>
        /// <param name="buttons">The ButtonTypes linked to the Buttons</param>
        public void CreateButtons(ButtonType[] buttons)
        {

        }

        private void Call(ButtonType clickedButton)
        {

        }

        /// <summary>
        /// Checks if there is a Button on this position and calls the method lonked to that Button.
        /// </summary>
        /// <param name="position">The position the click was.</param>
        public void CheckButtonClick(Vector2 position)
        {

        }
    }
}
