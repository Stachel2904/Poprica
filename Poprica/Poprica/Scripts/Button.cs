using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Poprica
{
    public struct Button
    {
        /// <summary>
        /// Holds the type of this Button. Is element of ButtonType enum.
        /// </summary>
        public ButtonType Type { get; set; }

        /// <summary>
        /// Holds the Rectangle of this Button.
        /// </summary>
        public Rectangle Rect { get; set; }

        public Button(ButtonType type, Rectangle rect)
        {
            Type = type;
            Rect = rect;
        }
    }
}
