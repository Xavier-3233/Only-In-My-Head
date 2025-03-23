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

        public bool A { get; private set; } = false;

        public bool B { get; private set; } = false;

        public bool C { get; private set; } = false;

        public bool Right { get; private set; } = false;

        public bool Left { get; private set; } = false;

        public bool Up { get; private set; } = false;

        public bool Down { get; private set; } = false;

        public bool Q { get; private set; } = false;

        public bool E { get; private set; } = false;

        public bool Enter { get; private set; } = false;

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

            A = currentGamePadState.Buttons.A == ButtonState.Pressed && previousGamePadState.Buttons.A == ButtonState.Released
                || currentKeyboardState.IsKeyDown(Keys.A) && !previousKeyboardState.IsKeyDown(Keys.A);

            B = currentGamePadState.Buttons.B == ButtonState.Pressed && previousGamePadState.Buttons.B == ButtonState.Released
                || currentKeyboardState.IsKeyDown(Keys.B) && !previousKeyboardState.IsKeyDown(Keys.B);

            C = currentKeyboardState.IsKeyDown(Keys.C) && !previousKeyboardState.IsKeyDown(Keys.C);

            Left = currentKeyboardState.IsKeyDown(Keys.Left) && !previousKeyboardState.IsKeyDown(Keys.Left);

            Right = currentKeyboardState.IsKeyDown(Keys.Right) && !previousKeyboardState.IsKeyDown(Keys.Right);

            Up = currentKeyboardState.IsKeyDown(Keys.Up) && !previousKeyboardState.IsKeyDown(Keys.Up);

            Down = currentKeyboardState.IsKeyDown(Keys.Down) && !previousKeyboardState.IsKeyDown(Keys.Down);

            Q = currentKeyboardState.IsKeyDown(Keys.Q) && !previousKeyboardState.IsKeyDown(Keys.Q);

            E = currentKeyboardState.IsKeyDown(Keys.E) && !previousKeyboardState.IsKeyDown(Keys.E);

            Enter = currentKeyboardState.IsKeyDown(Keys.Enter) && !previousKeyboardState.IsKeyDown(Keys.Enter);
        }
    }
}
