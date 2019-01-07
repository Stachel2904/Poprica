using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public abstract class Scene
    {
        /// <summary>
        /// Holds an List of images, which should be displayed in the scene.
        /// </summary>
        public List<Image> Images { get; set; }

        public Scene()
        {

        }

        /// <summary>
        /// Updates this Scene and its components.
        /// </summary>
        public virtual void Update()
        {

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
