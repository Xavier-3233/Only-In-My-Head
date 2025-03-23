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

        private Maps _tiles;

        private Maps _currentMap;

        private TileSetData _setData;

        private Effect _shader;

        private Player _player;

        private InputManager _input;

        private Dictionary<string, Maps> _maps;

        private Dictionary<string, TileSetData> _sets;

        //private List<>

        public WorldScreen(InputManager input)
        {
            _player = new Player();

            _setData = new TileSetData("GrassArea.tsj");
        }

        public override void Activate()
        {
            //ScreenManager.GraphicsDevice.Viewport.Preffered
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            

            _sets = new Dictionary<string, TileSetData>
            {
                {"Grass", new TileSetData("GrassArea.tsj") }
            };
            _maps = new Dictionary<string, Maps>
            {
                {"Field", new Maps("GrassArea.json", _sets["Grass"]) },
                {"Town",  new Maps("Town.json", _sets["Grass"]) }
            };
            //_tiles = new Maps("GrassMap.txt");
            _currentMap = _maps["Field"];
            foreach (Maps map in _maps.Values)
            {
                map.LoadContent(_content);
            }
            foreach (TileSetData set in _sets.Values)
            {
                set.LoadContent(_content);
            }
            //_maps["Field"].LoadContent(_content);
            //_tiles.LoadContent(_content);
            _shader = _content.Load<Effect>("Test");
            _player.LoadContent(_content);

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

            if(_player.Position.X >= 960)
            {
                _currentMap = _maps["Town"];
                _player.Position = new Vector2(0, _player.Position.Y);
            }
        }

        public override void HandleInput(GameTime gameTime, InputManager input)
        {
            if (input.Escape)
            {
                ScreenManager.Game.Exit();
            }

            if (input.Left)
            {
                _player.Position += new Vector2(-32, 0);
            }
            if (input.Right)
            {
                _player.Position += new Vector2(32, 0);
            }
            if (input.Up)
            {
                _player.Position += new Vector2(0, -32);
            }
            if (input.Down)
            {
                _player.Position += new Vector2(0, 32);
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

            spriteBatch.Begin();
            _currentMap.Draw(gameTime, ScreenManager.SpriteBatch);
            _player.Draw(gameTime, ScreenManager.SpriteBatch);
            
            //spriteBatch.DrawString(FontManager.DefaultFont, "Boooooo!", new Vector2(200, 200), Color.White);

            spriteBatch.End();

        }
    }
}
