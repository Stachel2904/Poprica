using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class Slider
    {

        private Rectangle barRect;
        public Rectangle needleRect;
        private Rectangle initBarRect;
        private Rectangle initNeedleRect;
        private Image barImg;
        private Image needleImg;
        private int min;
        private int max;
        private float stepSize;
        public bool isMoved;

        public Point Location
        {
            get
            {
                return barRect.Location;
            }
            set
            {
                barRect.Location = value;
            }
        }
        public Point Size
        {
            get
            {
                return barRect.Size;
            }
            set
            {
                barRect.Size = value;
            }
        }
        public int Value { get; set; }

        public event EventHandler<ScrollEventArgs> Scroll;
        
        public Slider(int rectX, int rectY, int rectW, int rectH)
        {

            Vector2 scale = PopricaGame.Main.CalcCurrentScale();

            min = 0;
            max = 100;
            Value = (max - min) / 2;
            stepSize = (rectW * scale.X) / max;

            initBarRect = new Rectangle(rectX, rectY, rectW, rectH);
            initNeedleRect = new Rectangle(rectX, rectY - (int)(rectH / 2) + 40, 20, 20);

            barRect = new Rectangle((int) (rectX * scale.X), (int) (rectY * scale.Y), rectW, rectH);
            needleRect = new Rectangle((int) (barRect.X + (Value * stepSize)) - 10, (int) (barRect.Y + barRect.Height/2) + 40, 20 , 20 );
            
            barImg = new Image(ImageType.UI, (int)UIImageType.BAR, barRect);
            needleImg = new Image(ImageType.UI, (int)UIImageType.NEEDLE, needleRect);
        }

        public Image[] GetImages()
        {
            return new Image[]
            {
                barImg,
                needleImg
            };
        }

        public void OnMouseDown()
        {
            isMoved = true;
        }

        public void OnMouseMove(Point mouse)
        {
            if (isMoved)
            {
                if (mouse.X > barRect.X  && mouse.X < (barRect.X + ( barRect.Width * PopricaGame.Main.CalcCurrentScale().X)))
                {
                    Vector2 scale = PopricaGame.Main.CalcCurrentScale();
                    
                    needleRect.Location = new Point((int) mouse.X, needleRect.Location.Y);
                    needleImg.Rect = needleRect;

                    Value = (int) ((needleRect.X  - barRect.X) / stepSize);

                    Console.WriteLine(Value);
                }
            }
        }

        public void OnMouseUp()
        {
            isMoved = false;
        }

        public void Scale(Vector2 scale)
        {
            stepSize = (initBarRect.Width * scale.X) / max;

            barRect = new Rectangle((int) (initBarRect.X * scale.X), (int) (initBarRect.Y * scale.Y), initBarRect.Width , initBarRect.Height);
            needleRect = new Rectangle((int) ((initNeedleRect.X * scale.X) + Value * stepSize) - 10, (int) (initNeedleRect.Y * scale.Y), 20, 20);
            
            barImg.Rect = barRect;
            needleImg.Rect = needleRect;
        }

    }

    public class ScrollEventArgs : EventArgs
    {
        public int Amount { get; set; }

    }
}
