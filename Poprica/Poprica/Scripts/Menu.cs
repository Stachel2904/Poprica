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

        public Menu(MenuType type, NamespaceType namespaceType) : base(SceneType.MENU, namespaceType)
        {
            ButtonType[] menuButtons = Maps.MenuButtonMap[type];

            Button[] createdButtons = ButtonManager.Main.CreateButtons(menuButtons);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                this.Images.Add(new Image((int)ImageType.BUTTON, createdButtons[i].Rect));
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
        public static void Exit()
        {
            PopricaGame.MainState = GameState.EXIT;
        }

        /// <summary>
        /// Start the Main Poprica Game
        /// </summary>
        public static void LoadPoprica()
        {
            SceneManager.Main.LoadScene(SceneType.PLACE, NamespaceType.POPRICA, (int)LocationType.LIVINGROOM);
        }

        /// <summary>
        /// Start the Main DungeonCrawler Game
        /// </summary>
        public static void LoadDungeonCrawler()
        {
            SceneManager.Main.LoadScene(SceneType.MINIGAME, NamespaceType.DUNGEONCRAWLER);
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
