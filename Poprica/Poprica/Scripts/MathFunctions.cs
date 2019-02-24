using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Poprica
{
    public static class MathFunctions
    {
        /// <summary>
        /// Calculates the x Position of a image.
        /// </summary>
        /// <param name="step">calculation step.</param>
        /// <returns>x Position of the image.</returns>
        public static int CalcPicturePosWidth(int step)
        {
            return (int) ((1920 / (Math.Pow(2, step))) * (Math.Pow(2, step) - 1)) / 2;
        }

        /// <summary>
        /// Calculates the y Position of a image.
        /// </summary>
        /// <param name="step">calculation step.</param>
        /// <returns>y Position of the image.</returns>
        public static int CalcPicturePosHeight(int step)
        {
            return (int)((1080 / (Math.Pow(2, step))) * (Math.Pow(2, step) - 1)) / 2;
        }
        
        public static Point CalcImageSize(Point old, int i, dynamic index = null)
        {
            if (index == null)
                return new Point((int)((old.X) / Math.Pow(2, i)), (int)((old.Y) / Math.Pow(2, i)));
            else
            {
                double scale = 1;
                
                if (Poprica.Maps.ImageScale.TryGetValue(index, out scale))
                    return new Point((int)((old.X * scale) / Math.Pow(2, i)), (int)((old.Y * scale) / Math.Pow(2, i)));
                
                return new Point((int)((old.X) / Math.Pow(2, i)), (int)((old.Y) / Math.Pow(2, i)));
            }
        }

        /// <summary>
        /// Returns the position to display a image.
        /// Parameter center, bottom and size must be used simultaneously.
        /// </summary>
        /// <param name="step">Int which represents the current step size.</param>
        /// <param name="side">Enum which represents the position to display the image.</param>
        /// <param name="size">Size of the picture.</param>
        /// <returns></returns>
        public static Point ImagePos(int step, PositionType side = PositionType.NONE, Point size = new Point())
        {
            //ToDo: Add display picture at the sides

            switch (side)
            {
                case PositionType.MIDDLE:
                    return new Point(960 - size.X / 2, 540 - size.Y / 2);
                case PositionType.BOTTOM:
                    return new Point(960 - size.X / 2, (int)(1080 - ((270 * Row1_5_13_29(step)) / Math.Pow(2, step + 1))) - size.Y);
                case PositionType.TOP:
                    return new Point(960 - size.X / 2, (int)((270 * Row1_5_13_29(step)) / Math.Pow(2, step + 1)) - size.Y);
                case PositionType.RIGHTBOTTOM:
                case PositionType.LEFTBOTTOM:
                case PositionType.RIGHT:
                case PositionType.LEFT:
                    return new Point(960 - size.X / 2, 540 - size.Y / 2);

                default:
                    return new Point(CalcPicturePosWidth(step), CalcPicturePosHeight(step));
            }
        }

        private static int Row1_5_13_29(int steps)
        {
            int res = 1;

            for (int i = 2; i < steps+2; i++)
            {
                res += (int) Math.Pow(2, i);
            }

            return res;
        }

    }
}
