using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public List<Scene> PreviousScenes { get; }

        /// <summary>
        /// The current Scene.
        /// </summary>
        public Scene currentScene { get; }

        /// <summary>
        /// The current time.
        /// </summary>
        public Moment CurrentMoment { get; }

        private SceneManager()
        {
            PreviousScenes = new List<Scene>();
        }

        /// <summary>
        /// Load a new Scene.
        /// </summary>
        /// <param name="newScene">The new Scene, that should be loaded.</param>
        public void LoadScene(SceneType newScene)
        {

        }

        /// <summary>
        /// Returns to a previous Scene.
        /// </summary>
        /// <param name="step">The step of how far you want to go back.</param>
        public void ReturnToPreviousScene(int step)
        {
            
        }
    }
}
