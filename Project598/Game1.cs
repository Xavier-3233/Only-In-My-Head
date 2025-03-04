using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Project598.Screens;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Project598
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Vector2 _brickPosition;
        private Texture2D _TestBrick;
        private Effect _grayscaleEffect;
        private Effect _testing;
        private ScreenManager _screenManager;
        //private GrayShader grayShader;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.GraphicsProfile = GraphicsProfile.HiDef;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _screenManager = new ScreenManager(this);
            Components.Add(_screenManager);

            _screenManager.AddScreen(new MainMenu());
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _brickPosition = new Vector2((_graphics.GraphicsDevice.Viewport.Width - 32) / 2, (_graphics.GraphicsDevice.Viewport.Height - 32) / 2);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _TestBrick = Content.Load<Texture2D>("Brick");
            _grayscaleEffect = Content.Load<Effect>("GrayscaleEffect");
            _testing = Content.Load<Effect>("Test");
            FontManager.LoadContent(Content);
            //_font = Content.Load<SpriteFont>("NothingYouCouldDo");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {

            GraphicsDevice.Clear(Color.CornflowerBlue);

            // Let the ScreenManager handle drawing the active screen
            _screenManager.Draw(gameTime);
            //_screenManager.Draw(gameTime);
            /*
            GraphicsDevice.Clear(Color.CornflowerBlue);
            Matrix view = Matrix.Identity;

            int width = GraphicsDevice.Viewport.Width;
            int height = GraphicsDevice.Viewport.Height;
            Matrix projection = Matrix.CreateOrthographicOffCenter(0, width, height, 0, 0, 1);

            _testing.Parameters["view_projection"].SetValue(view * projection);

            _spriteBatch.Begin(effect: _testing);
            _spriteBatch.DrawString(FontManager.DefaultFont, "Seymour!", new Vector2((width / 2), height / 2), Color.Black);
            _spriteBatch.Draw(_TestBrick, new Vector2(0, 0), Color.White);
            _spriteBatch.End();*/
            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null, _grayscaleEffect);
            //grayShader.Apply(_spriteBatch);
            // _spriteBatch.Begin();
            //  _spriteBatch.Draw(_TestBrick, _brickPosition, Color.Red);
            //grayShader.End(_spriteBatch);
            // _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
