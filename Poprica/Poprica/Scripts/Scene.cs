using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public abstract class Scene
    {
        public Scene()
        {

        }

        /// <summary>
        /// Updates this Scene and its components.
        /// </summary>
        public void Update()
        {

        }

        /// <summary>
        /// Renders the displayed images.
        /// </summary>
        public void Render()
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
