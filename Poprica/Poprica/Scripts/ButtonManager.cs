﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
            List<Button> createdButtons = new List<Button>();
            for (int i = 0; i < buttons.Length; i += 10)
            {
                for (int j = 0; j < 10; j++)
                {
                    Button newButton = new Button(buttons[i + j], new Rectangle(i * 250, j / 10 * 50, 250, 50));
                    createdButtons.Add(newButton);
                }
            }
        }

        private void Call(ButtonType clickedButton)
        {
            Maps.ButtonMap[clickedButton].Invoke();
        }

        /// <summary>
        /// Checks if there is a Button on this position and calls the method lonked to that Button.
        /// </summary>
        /// <param name="position">The position the click was.</param>
        public void CheckButtonClick(Point position)
        {
            if (menuButtons.Length > 0)
            {
                for (int i = 0; i < menuButtons.Length; i++)
                {
                    Button checkedButton = menuButtons[i];

                    if(CheckPointInRect(position, checkedButton.Rect))
                    {
                        Call(checkedButton.Type);
                    }
                }
            }
            else
            {
                foreach (KeyValuePair<Button, Action> element in actionButtons)
                {

                }
            }
        }

        private bool CheckPointInRect(Point point, Rectangle rectangle)
        {
            bool insideX = point.X > rectangle.X && point.X < rectangle.X + rectangle.Width;
            bool insideY = point.Y > rectangle.Y && point.Y < rectangle.Y + rectangle.Height;

            if (insideX && insideY)
            {
                return true;
            }

            return false;
        }
    }
}
