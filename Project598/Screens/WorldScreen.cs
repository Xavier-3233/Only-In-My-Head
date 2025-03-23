using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework.Input;

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

        private bool battle = false;

        private int _timer = 0;

        //private Dictionary<string, List<NPC>> _npcs;

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

            _maps["Town"].AddNPC(new NPC("James", new Vector2(32 * 8, 32 * 9), "Town"));
            
            //_tiles = new Maps("GrassMap.txt");
            _currentMap = _maps["Field"];
            foreach (Maps map in _maps.Values)
            {
                map.LoadContent(_content);
                foreach (NPC npc in map.NPCs)
                {
                    npc.AddDialogue();
                    npc.LoadContent(_content);
                }
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

            if(_currentMap == _maps["Field"] && _maps["Field"].GetTileNumber((int)_player.Position.X, (int)_player.Position.Y) == 1)
            {
                int roll = RNG.GetInt(1, 5);
                if (roll == 4 && _timer <= 10)
                {
                    battle = true;
                    ScreenManager.AddScreen(new BattleScreen());
                }
            }
            _timer += 1;
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
            if (input.Q)
            {
                if (_player.Mental == MentalCondition.Normal)
                {
                    _player.Mental = MentalCondition.Depressed;
                }
                else
                {
                    _player.Mental = MentalCondition.Normal;
                }
            }

            foreach (NPC npc in _currentMap.NPCs)
            {
                if (input.E && Vector2.Distance(_player.Position, npc.Position) <= 32)
                {
                    ScreenManager.AddScreen(new DialogueScreen(_player, npc));
                }
            }
            
            /*foreach (var npc in _currentMap.NPCs)
            {
                if (Vector2.Distance(_player.Position, npc.Position) < 32) // 1-tile range
                {
                    Console.WriteLine($"Press 'E' to talk to {npc.Name}");

                    if (Keyboard.GetState().IsKeyDown(Keys.E))
                    {
                        
                        Console.WriteLine($"Talking to {npc.Name}...");
                        // Trigger dialogue system
                    }
                }
            }*/
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

            if (_player.Mental == MentalCondition.Depressed)
            {
                spriteBatch.Begin(effect: _shader);
                _currentMap.Draw(gameTime, ScreenManager.SpriteBatch);
                _player.Draw(gameTime, ScreenManager.SpriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                _currentMap.Draw(gameTime, ScreenManager.SpriteBatch);
                _player.Draw(gameTime, ScreenManager.SpriteBatch);
                /*foreach (var npc in _currentMap.NPCs)
                {
                    if (Vector2.Distance(_player.Position, npc.Position) <= 32) // 1-tile range
                    {
                        spriteBatch.DrawString(FontManager.DefaultFont, $"Press 'E' to talk to {npc.Name}", new Vector2(200, 200), Color.Black); 

                        if (Keyboard.GetState().IsKeyDown(Keys.E))
                        {
                            npc.Dialogue.Draw(gameTime, ScreenManager.SpriteBatch);
                            spriteBatch.DrawString(FontManager.DefaultFont, $"Talking to {npc.Name}", new Vector2(200, 200), Color.Black);
                            // Trigger dialogue system
                        }
                    }
                }*/
            }
            
            
            //spriteBatch.DrawString(FontManager.DefaultFont, "Boooooo!", new Vector2(200, 200), Color.White);

            spriteBatch.End();

        }
    }
}
