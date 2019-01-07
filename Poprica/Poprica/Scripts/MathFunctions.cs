using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
