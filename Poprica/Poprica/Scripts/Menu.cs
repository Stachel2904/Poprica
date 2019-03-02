using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

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
            Type = type;

            LoadImages();

        }

        public override void LoadImages()
        {
            Images.Clear();
            Texts.Clear();

            Images.Add(new Image(ImageType.MENU, (int)Type, new Rectangle(0, 0, PopricaGame.maxGameWidth, PopricaGame.maxGameHeight)));

            ButtonType[] menuButtons = Maps.MenuButtonMap[Type];

            Button[] createdButtons = ButtonManager.Main.CreateButtons(menuButtons, Type);

            for (int i = 0; i < createdButtons.Length; i++)
            {
                int imgIndex = (int)((UIImageType)Enum.Parse(typeof(UIImageType), createdButtons[i].Type.ToString()));

                this.Images.Add(new Image(ImageType.UI, imgIndex, createdButtons[i].Rect));
                //this.Texts.Add(new TextObject(Maps.MenuButtonText[(int)createdButtons[i].Type], createdButtons[i].Rect));
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
        /// Opens the pause menu.
        /// </summary>
        public void PauseMenu()
        {

        }

        /// <summary>
        /// Opens the main menu.
        /// </summary>
        public void MainMenu()
        {

        }

        /// <summary>
        /// Updates the Menu.
        /// </summary>
        public override void Update()
        {
            base.Update();

            LoadImages();
        }
    }
}
