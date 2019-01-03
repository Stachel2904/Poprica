using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poprica
{
    public struct Animation
    {
        /// <summary>
        /// HOld the current AnimationState. Is element of AnimationState enum.
        /// </summary>
        public AnimationState CurrentState;

        /// <summary>
        /// Holds the next AnimationState. Is element of AnimationState enum. 
        /// </summary>
        public AnimationState NextState;

        /// <summary>
        /// Is the maximum of frames for this animation.
        /// </summary>
        public int MaxFrames;

        /// <summary>
        /// Holds the index of the current frame.
        /// </summary>
        public double CurrentFrame;

        public Animation(AnimationState currentState, AnimationState nextState, int max, double current)
        {
            CurrentState = currentState;
            NextState = nextState;
            MaxFrames = max;
            CurrentFrame = current;
        }
    }
}
