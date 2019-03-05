using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public abstract class Scene
    {
        public SceneType SceneCategory;
        /// <summary>
        /// Holds an List of images, which should be displayed in the scene.
        /// </summary>
        public List<Image> Images { get; set; }
        public List<TextObject> Texts { get; set; }

        protected int height;
        protected int width;

        public Scene(SceneType sceneType)
        {
            height = PopricaGame.maxGameHeight;
            width = PopricaGame.maxGameWidth;

            Images = new List<Image>();
            Texts = new List<TextObject>();
            SceneCategory = sceneType;
        }

        /// <summary>
        /// Updates this Scene and its components.
        /// </summary>
        public virtual void Update()
        {
            //height = PopricaGame.Main.gameHeight;
            //width = PopricaGame.Main.gameWidth;
        }

        /// <summary>
        /// Renders the displayed images.
        /// </summary>
        public void Render()
        {

        }

        /// <summary>
        /// Loads images which have to been displayed.
        /// </summary>
        public virtual void LoadImages()
        {
            Rectangle rect = new Rectangle();
            Image playerInfo = new Image();

            Images.Add(playerInfo);
        }

        /// <summary>
        /// Tries to restart this Scene.
        /// </summary>
        /// <returns>Returns true if restart was succesful.</returns>
        public bool Restart()
        {
            return false;
        }
    }
}
