using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598.Screens
{
    public class Credits : GameScreen
    {
        private ContentManager _content;
        
        public Credits()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
        }

        public override void Unload()
        {
            _content.Unload();
        }

        public override void Update(GameTime gameTime, bool unfocused, bool covered)
        {
            base.Update(gameTime, unfocused, covered);

            if (IsActive)
            {

            }
        }

        public override void HandleInput(GameTime gameTime, InputManager input)
        {
            if (input.Escape)
            {
                ScreenManager.Game.Exit();
            }

            if (input.A)
            {
                ScreenManager.RemoveScreen(this);
            }
            
        }
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Yellow);
            var spritebatch = ScreenManager.SpriteBatch;
            spritebatch.Begin();
            spritebatch.DrawString(FontManager.DefaultFont, "Credits?", new Vector2(240, 300), Color.AliceBlue);
            spritebatch.End();
        }
    }
}
