using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public sealed class SceneManager
    {
        #region Singleton
        private static SceneManager main;

        public static SceneManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new SceneManager();
                }
                return main;
            }
        }
        #endregion

        /// <summary>
        /// Cache of previous Scenes;
        /// </summary>
        public List<Scene> PreviousScenes { get; private set; }

        /// <summary>
        /// The current Scene.
        /// </summary>
        public Scene currentScene { get; private set; }

        /// <summary>
        /// The current time.
        /// </summary>
        public Moment CurrentMoment { get; private set; }

        private SceneManager()
        {
            PreviousScenes = new List<Scene>();
        }

        /// <summary>
        /// Loads new Scene.
        /// </summary>
        /// <param name="newSceneType">The type of the Scene.</param>
        /// <param name="cache">Set true if the old Scene should be cached.</param>
        /// <param name="newScene">The LocationType, MenuType or ShopType of the Scene as Integer.</param>
        public void LoadScene(SceneType newSceneType, bool cache = false, int newScene = 0)
        {
            RessourceManager.Main.UnloadCache();

            if (cache)
            {
                PreviousScenes.Add(currentScene);
            }
            else if (PreviousScenes.Count() > 0 && !cache)
            {
                PreviousScenes = new List<Scene>();
            }

            switch (newSceneType)
            {
                case SceneType.MENU:
                    currentScene = new Menu();
                    break;
                case SceneType.SHOP:
                    currentScene = new Shop();
                    break;
                case SceneType.PLACE:
                    currentScene = new Place((LocationType)newScene);
                    break;
            }
        }
        
        private void LoadScene(Scene oldScene)
        {
            RessourceManager.Main.UnloadCache();

            PreviousScenes = new List<Scene>();

            currentScene = oldScene;
        }

        public void RenderScene()
        {
            if(currentScene.GetType() == typeof(MiniGame))
            {
                return;
            }

            UserInterface currentUserInterface = currentScene as UserInterface;

            for (int i = 0; i < currentUserInterface.Images.Count(); i++)
            {
                Image drawedImage = currentUserInterface.Images[i];

                //TODO: Map ImageType to Path
                RessourceManager.Main.Draw("", drawedImage.Rect, null, Color.White);
            }
        }

        /// <summary>
        /// Returns to a previous Scene.
        /// </summary>
        /// <param name="step">The step of how far you want to go back.</param>
        public void ReturnToPreviousScene(int step = 1)
        {
            if(step > PreviousScenes.Count())
            {
                throw new Exception("Less than " + step.ToString() + " Scenes cached!");
            }

            LoadScene(PreviousScenes[step - 1]);
        }
    }
}