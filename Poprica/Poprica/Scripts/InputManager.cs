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

        private Keys[] lastPressedKeys = new Keys[] { };

        private bool mouseAlreadyPressed = false;
        private bool keyAlreadyPressed;

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
            
            if (mouseState.LeftButton == ButtonState.Pressed && !mouseAlreadyPressed)
            {
                ButtonManager.Main.CheckButtonClick(mouseState.Position);
                mouseAlreadyPressed = true;
            }

            if (mouseState.LeftButton == ButtonState.Released && mouseAlreadyPressed)
            {
                mouseAlreadyPressed = false;
            }
            
            #endregion

            #region KeyboardInput
            Keys[] pressedKeys = Keyboard.GetState().GetPressedKeys();

            

            for (int i = 0; i < pressedKeys.Length; i++)
            {
                keyAlreadyPressed = false;

                for (int j = 0; j < lastPressedKeys.Length; j++)
                {
                    if (pressedKeys[i] == lastPressedKeys[j])
                    {
                        keyAlreadyPressed = true;
                    }
                }
                if (!keyAlreadyPressed)
                {
                    if (Maps.InputMaps[(int)SceneManager.Main.CurrentScene.SceneCategory].ContainsKey(pressedKeys[i]))
                    {
                        ActionEvent triggeredEvent = Maps.InputMaps[(int)SceneManager.Main.CurrentScene.SceneCategory][pressedKeys[i]];

                        triggeredEvent.method.Invoke(triggeredEvent.args);
                    }
                }
            }

            lastPressedKeys = pressedKeys;
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
