using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class Menu : UserInterface
    {
        /// <summary>
        /// Holds the MenuType of this instance. 
        /// </summary>
        public MenuType Type { get; set; }

        public Menu(MenuType type) : base()
        {
            ButtonType[] menuButtons = Maps.MenuButtonMap[type];

            Button[] createdButtons = ButtonManager.Main.CreateButtons(menuButtons);
            Images = new List<Image>();

            for (int i = 0; i < createdButtons.Length; i++)
            {
                this.Images.Add(new Image(ImageType.BUTTON, createdButtons[i].Rect));
            }

        }

        /// <summary>
        /// Navigate back to the previous Menu.
        /// </summary>
        public void Back()
        {

        }

        /// <summary>
        /// Exits the actual Menu.
        /// </summary>
        public static void Exit()
        {
            PopricaGame.MainState = GameState.EXIT;
        }

        /// <summary>
        /// Opens the menu specific options.
        /// </summary>
        public void Options()
        {

        }

        /// <summary>
        /// Calls the Save-fct. from Progress.
        /// </summary>
        public void Save()
        {

        }

        /// <summary>
        /// Calls the Load-fct. from Progress.
        /// </summary>
        public void Load()
        {

        }

        /// <summary>
        /// Opens the main menu.
        /// </summary>
        public void MainMenu()
        {

        }
    }
}
