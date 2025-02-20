using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public class InputManager
    {
        GamePadState previousGamePadState;
        GamePadState currentGamePadState;

        KeyboardState previousKeyboardState;
        KeyboardState currentKeyboardState;

        MouseState previousMouseState;
        MouseState currentMouseState;


        public bool Escape { get; private set; } = false;

        public bool Right { get; private set; } = false;

        public bool Left { get; private set; } = false;

        public bool Up { get; private set; } = false;

        public bool Down { get; private set; } = false;

        public void Update(GameTime gameTime)
        {
            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            previousGamePadState = currentGamePadState;
            currentGamePadState = GamePad.GetState(0);

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            Escape = currentGamePadState.Buttons.Back == ButtonState.Pressed && previousGamePadState.Buttons.Back == ButtonState.Released
                || currentKeyboardState.IsKeyDown(Keys.Escape) && !previousKeyboardState.IsKeyDown(Keys.Escape);
        }
    }
}
