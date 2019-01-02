﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public sealed class AnimationManager
    {
        #region Singleton
        private static AnimationManager main;

        public static AnimationManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new AnimationManager();
                }
                return main;
            }
        }
        #endregion

        private AnimationManager()
        {

        }
    }
}
