using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;

namespace Poprica
{
    public sealed class InputManager
    {
        #region Singleton
        private static InputManager main;

        public static InputManager Main
        {
            get
            {
                if (main == null)
                {
                    main = new InputManager();
                }
                return main;
            }
        }
        #endregion
        
        private Dictionary<InputType, System.Action> inputMap;

        private InputManager()
        {

        }

        /// <summary>
        /// The InputManager checks if any InputType is triggered and calls the Actions.
        /// </summary>
        public void CheckInput()
        {
            #region MouseInput
            MouseState mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                ButtonManager.Main.CheckButtonClick(mouseState.Position);
            }
            #endregion

            #region KeyboardInput
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();
            

            for (int i = 0; i < pressedKeys.Length; i++)
            {
                if (Maps.InputMaps[(int)SceneManager.Main.CurrentScene.SceneCategory].ContainsKey(pressedKeys[i]))
                {
                    ActionEvent triggeredEvent = Maps.InputMaps[(int)SceneManager.Main.CurrentScene.SceneCategory][pressedKeys[i]];

                    triggeredEvent.method.Invoke(triggeredEvent.args);
                }
            }
            #endregion
        }

        /// <summary>
        /// Overrides the old inputkey with a new.
        /// </summary>
        /// <param name="inputType">The InputType you want to override.</param>
        public void MapInput(InputType inputType)
        {

        }

    }
}
