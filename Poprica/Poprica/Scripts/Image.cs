using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public struct Image<T>
    {

        /// <summary>
        /// Holds the type of this Image. Is element of ImageType enum.
        /// </summary>
        public T Type { get;}

        /// <summary>
        /// Holds a rectangle, which is from MonoGame
        /// </summary>
        public Rectangle Rect { get; set; }

        public Image(T type, Rectangle rect)
        {
            Type = type;
            Rect = rect;
        }
    }
}
