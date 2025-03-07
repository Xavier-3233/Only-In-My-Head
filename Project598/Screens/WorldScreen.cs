using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;

namespace Project598.Screens
{
    public class WorldScreen : GameScreen
    {
        private ContentManager _content;

        private Tiles _tiles;

        private Effect _shader;

        public WorldScreen()
        {

        }

        public override void Activate()
        {
            //ScreenManager.GraphicsDevice.Viewport.Preffered
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            _tiles = new Tiles("GrassMap.txt");
            _tiles.LoadContent(_content);
            _shader = _content.Load<Effect>("Test");

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

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Black);

            Matrix view = Matrix.Identity;

            int width = 960;
            int height = 640;
            Matrix projection = Matrix.CreateOrthographicOffCenter(0, width, height, 0, 0, 1);

            _shader.Parameters["view_projection"].SetValue(view * projection);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin(effect: _shader);
            _tiles.Draw(gameTime, ScreenManager.SpriteBatch);
            
            //spriteBatch.DrawString(FontManager.DefaultFont, "Boooooo!", new Vector2(200, 200), Color.White);

            spriteBatch.End();

        }
    }
}
