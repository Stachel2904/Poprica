using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public class Slider
    {

        private Rectangle rectBar;
        private Rectangle rectNeedle;
        private Image barImg;
        private Image needleImg;
        private int min;
        private int max;
        private float stepSize;

        public Point Location
        {
            get
            {
                return rectBar.Location;
            }
            set
            {
                rectBar.Location = value;
            }
        }
        public Point Size
        {
            get
            {
                return rectBar.Size;
            }
            set
            {
                rectBar.Size = value;
            }
        }
        public int Value { get; set; }

        public event EventHandler<ScrollEventArgs> Scroll;

        public Slider(Point loc, Point size)
        {
            Value = (max - min) / 2;
            stepSize = 100 / size.X;

            rectBar = new Rectangle(loc, size);
            rectNeedle = new Rectangle(loc.X + (int) (Value*stepSize), loc.Y - (int) (size.Y / 2 + 10), 20, 20);

            barImg = new Image( ImageType.UI, (int) UIImageType.BAR, rectBar);
            needleImg = new Image(ImageType.UI, (int) UIImageType.NEEDLE, rectNeedle);
        }

        public Slider(int rectX, int rectY, int rectW, int rectH)
        {
            Value = (max - min) / 2;
            stepSize = 100 / rectH;

            rectBar = new Rectangle(rectX, rectY, rectW, rectH);
            rectNeedle = new Rectangle(rectX + (int)(Value * stepSize), rectY - (int)(rectH / 2 + 10), 20, 20);

            barImg = new Image(ImageType.UI, (int)UIImageType.BAR, rectBar);
            needleImg = new Image(ImageType.UI, (int)UIImageType.NEEDLE, rectNeedle);
        }

        public Image[] GetImages()
        {
            return new Image[]
            {
                barImg,
                needleImg
            };
        }



    }

    public class ScrollEventArgs : EventArgs
    {
        public int Amount { get; set; }

    }
}


//            if (SceneManager.Main.CurrentScene.SceneCategory == SceneType.MENU && (SceneManager.Main.CurrentScene as Menu).Type == MenuType.OPTIONS)
//            {
//                bar = new TrackBar();
//                this.Window.

//                this.ClientSize = new System.Drawing.Size(400, 400);
//                this.Controls.AddRange(new System.Windows.Forms.Control[] { this.bar });

//                bar.Location = new System.Drawing.Point(50, 10);
//                bar.Size = new System.Drawing.Size(224, 45);
//                bar.Scroll += new System.EventHandler(this.trackBar_Scroll);
//}
