using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

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

            Images.Add(new Image(ImageType.MENU, (int)Type, new Rectangle(0, 0, width, height)));
            

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
        /// <param name="eventArgs">Arguments which describe the previous scene.</param>
        public static void Back(int[] eventArgs)
        {
            SceneManager.Main.ReturnToPreviousScene();
        }

        /// <summary>
        /// Exits the Game.
        /// </summary>
        public static void Exit(int[] eventArgs)
        {
            if (SceneManager.Main.CurrentScene.SceneCategory == SceneType.MENU && (SceneManager.Main.CurrentScene as Menu).Type == MenuType.MAINMENU)
                PopricaGame.MainState = GameState.EXIT;
            else
                SceneManager.Main.ReturnToPreviousScene();
        }

        /// <summary>
        /// Starts a new Scene from a Buttonclick.
        /// </summary>
        /// <param name="eventArgs">Arguments which describe the new scene.</param>
        public static void LoadNewScene(int[] eventArgs)
        {
            switch ((SceneType)eventArgs[0])
            {
                case SceneType.DUNGEONCRAWLER:
                    SceneManager.Main.LoadScene(SceneType.DUNGEONCRAWLER);
                    break;
                case SceneType.WAIFUCOLLECTION:
                    SceneManager.Main.LoadScene(SceneType.WAIFUCOLLECTION);
                    break;
                default:
                    SceneManager.Main.LoadScene((SceneType)eventArgs[0], eventArgs[1], true);
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
        public static void Save(int[] eventArgs)
        {
            Progress.Save();
        }

        /// <summary>
        /// Calls the Load-fct. from Progress.
        /// </summary>
        public static void Load(int[] eventArgs)
        {
            Progress.Load();

            //ToDo
            //refresh complete InputMaps
            Maps.InputMaps[0][Microsoft.Xna.Framework.Input.Keys.F] = new ActionEvent(new System.Action<int[]>(WaifuManager.Main.GetWaifu(DialogueEntityName.RICA).SetMood), new int[] { (int)MoodType.HAPPY });
            Maps.InputMaps[0][Microsoft.Xna.Framework.Input.Keys.T] = new ActionEvent(new System.Action<int[]>(WaifuManager.Main.GetWaifu(DialogueEntityName.RICA).SetClothes), new int[] { });
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
