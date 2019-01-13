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
        public Scene CurrentScene { get; private set; }

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
        /// <param name="newScene">The LocationType, MenuType or ShopType of the Scene as Integer.</param>
        /// <param name="cache">Set true if the old Scene should be cached.</param>
        public void LoadScene(SceneType newSceneType, int newScene = 0, bool cache = false)
        {
            RessourceManager.Main.UnloadCache();

            if (cache)
            {
                PreviousScenes.Add(CurrentScene);
            }
            else if (PreviousScenes.Count() > 0 && !cache)
            {
                PreviousScenes = new List<Scene>();
            }

            switch (newSceneType)
            {
                case SceneType.MENU:
                    CurrentScene = new Menu((MenuType)newScene);
                    break;
                case SceneType.SHOP:
                    CurrentScene = new Shop();
                    break;
                case SceneType.PLACE:
                    CurrentScene = new Place((LocationType)newScene);
                    break;
                case SceneType.DUNGEONCRAWLER:
                    CurrentScene = new DungeonCrawler.DungeonCrawler();
                    break;
            }
        }
        
        private void LoadScene(Scene oldScene)
        {
            RessourceManager.Main.UnloadCache();

            PreviousScenes = new List<Scene>();

            CurrentScene = oldScene;
        }

        public void RenderScene()
        {
            for (int i = 0; i < CurrentScene.Images.Count(); i++)
            {
                Image drawedImage = CurrentScene.Images[i];

                string pathToImage = Maps.ImageMap[(int)drawedImage.Type][drawedImage.Index];

                RessourceManager.Main.Draw(pathToImage, drawedImage.Rect, null, Color.White);
            }
            for (int i = 0; i < CurrentScene.Texts.Count(); i++)
            {
                RessourceManager.Main.DrawText(CurrentScene.Texts[i]);
            }

            if (CurrentScene.SceneCategory == SceneType.PLACE)
            {
                WaifuManager.Main.RenderWaifus();
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