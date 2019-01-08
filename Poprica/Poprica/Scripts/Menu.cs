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

        public Menu(MenuType type) : base(SceneType.MENU)
        {
            ButtonType[] menuButtons = Maps.MenuButtonMap[type];

            Button[] createdButtons = ButtonManager.Main.CreateButtons(menuButtons);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                this.Images.Add(new Image(ImageType.UI, (int)UIImageType.BUTTON, createdButtons[i].Rect));
                this.Texts.Add(new TextObject(Maps.MenuButtonText[(int)createdButtons[i].Type], createdButtons[i].Rect));
            }

        }

        /// <summary>
        /// Navigate back to the previous Menu.
        /// </summary>
        public void Back()
        {

        }

        /// <summary>
        /// Exits the Game.
        /// </summary>
        public static void Exit(int[] eventArgs)
        {
            PopricaGame.MainState = GameState.EXIT;
        }

        /// <summary>
        /// Start a new Scene from ButtonClick
        /// </summary>
        public static void LoadNewScene(int[] eventArgs)
        {
            switch ((SceneType)eventArgs[0])
            {
                case SceneType.DUNGEONCRAWLER:
                    SceneManager.Main.LoadScene(SceneType.DUNGEONCRAWLER);
                    break;
                default:
                    SceneManager.Main.LoadScene((SceneType)eventArgs[0], eventArgs[1]);
                    break;
            }
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
