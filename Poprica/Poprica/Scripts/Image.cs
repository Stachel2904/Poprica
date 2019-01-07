using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public struct Image
    {

        /// <summary>
        /// Holds the type of this Image. Is element of ImageType enum of specific Namespace.
        /// </summary>
        public ImageType Type { get;}

        /// <summary>
        /// Holds a rectangle, which is from MonoGame
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Holds a rectangle, which is from MonoGame
        /// </summary>
        public Rectangle Rect { get; set; }

        public Image(ImageType type, int index, Rectangle rect)
        {
            Type = type;
            Index = index;
            Rect = rect;

        }
    }
}
