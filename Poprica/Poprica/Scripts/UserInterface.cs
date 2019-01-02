using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public abstract class UserInterface : Scene
    {
        /// <summary>
        /// Holds an List of images, which should be displayed in the scene.
        /// </summary>
        public List<Image> Images { get; set;}

        public UserInterface() : base()
        {

        }

    }
}
