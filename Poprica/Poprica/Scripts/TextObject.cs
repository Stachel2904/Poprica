using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class TextObject
    {
        public string Text;
        public int Size;
        public Rectangle Rect;
        public Color color;

        public TextObject(string text, Rectangle rect, int size = 1)
        {
            Rect = rect;
            Text = text;
            Size = size;
            color = Color.Black;
        }
    }
}
