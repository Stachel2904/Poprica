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
        private Button[] locationButtons;

        private Vector2 currentScale;

        private ButtonManager()
        {
            
        }

        /// <summary>
        /// Create a Button for each Action.
        /// </summary>
        /// <param name="actions">The Actions linked to the Buttons</param>
        public void CreateButtons(Action[] actions)
        {
            currentScale = PopricaGame.Main.CalcCurrentScale();


        }

        /// <summary>
        /// Create a Button for each Location.
        /// </summary>
        /// <param name="location">The Locations linked to the Buttons</param>
        public Button[] CreateButtons(ButtonType[] buttons, LocationType location)
        {
            currentScale = PopricaGame.Main.CalcCurrentScale();

            List<Button> createdButtons = new List<Button>();

            Rectangle rect = new Rectangle(10, 400, 300, 80);

            for (int i = 0; i < buttons.Length; i++)
            {
                switch (buttons[i])
                {
                    case ButtonType.TALK:
                        if (WaifuManager.Main.GetEnities().Length == 0)
                            continue;
                        break;
                    
                    //ToDo add button conditions

                }

                int rectX = (int)(rect.Location.X * currentScale.X);
                int rectY = (int)(rect.Location.Y * currentScale.Y);
                int rectW = (int)(rect.Size.X); // * currentScale.X);
                int rectH = (int)(rect.Size.Y); // * currentScale.Y);
                
                Button button = new Button(buttons[i], new Rectangle(rectX, rectY + (i * 90), rectW, rectH));
                createdButtons.Add(button);
            }

            locationButtons = createdButtons.ToArray();

            return locationButtons;
        }

        /// <summary>
        /// Create a Button for each ButtonType.
        /// </summary>
        /// <param name="buttons">The ButtonTypes linked to the Buttons</param>
        public Button[] CreateButtons(ButtonType[] buttons, MenuType type)
        {
            currentScale = PopricaGame.Main.CalcCurrentScale();

            List<Button> createdButtons = new List<Button>();
            
            for (int i = 0; i < buttons.Length; i++)
            {
                Rectangle rect = Maps.MenuButtonRects[type][i];

                //Console.WriteLine("scale: " + currentScale.X);
                //Console.WriteLine("Old: " + rect.Location.X);

                int rectX = (int) (rect.Location.X * currentScale.X);
                int rectY = (int) (rect.Location.Y * currentScale.Y);
                int rectW = (int) (rect.Size.X); // * currentScale.X);
                int rectH = (int)(rect.Size.Y); // * currentScale.Y);

                //Console.WriteLine("new: " + rectX);

                Button button = new Button(buttons[i], new Rectangle(rectX, rectY, rectW, rectH));
                createdButtons.Add(button);
            }

            menuButtons = createdButtons.ToArray();
            return menuButtons;
        }

        private void Call(ButtonType clickedButton)
        {
            ActionEvent triggeredEvent = Maps.ButtonMap[clickedButton];

            triggeredEvent.method.Invoke(triggeredEvent.args);
        }

        /// <summary>
        /// Checks if there is a Button on this position and calls the method linked to that Button.
        /// </summary>
        /// <param name="position">The position the click was.</param>
        public void CheckButtonClick(Point position)
        {
            if (menuButtons != null && menuButtons.Length > 0)
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
            
            if (locationButtons != null && locationButtons.Length > 0)
            {
                for (int i = 0; i < locationButtons.Length; i++)
                {
                    Button checkedButton = locationButtons[i];

                    if (CheckPointInRect(position, checkedButton.Rect))
                    {
                        Call(checkedButton.Type);
                    }
                }
            }
            
            if (actionButtons != null)
            {
                foreach (KeyValuePair<Button, Action> element in actionButtons)
                {

                }
            }
        }

        private bool CheckPointInRect(Point point, Rectangle rectangle, bool isRect = true)
        {
            if (isRect)
            {
                bool insideX = point.X > rectangle.X && point.X < rectangle.X + (int)(rectangle.Width * currentScale.X);   //remove Button scale later!
                bool insideY = point.Y > rectangle.Y && point.Y < rectangle.Y + (int)(rectangle.Height * currentScale.Y);

                if (insideX && insideY)
                {
                    return true;
                }
            }
            else
            {

            }

            return false;
        }
        
    }
}
