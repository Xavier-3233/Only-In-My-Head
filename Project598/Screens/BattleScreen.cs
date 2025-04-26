using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Project598.TileMapData;

namespace Project598.Screens
{
    public class BattleScreen : GameScreen
    {
        private ContentManager _content;

        private Texture2D _menuBox;

        private Texture2D _attack;

        private Texture2D _guard;

        private Texture2D _item;

        private Texture2D _flee;

        private Enemy _enemy;

        private Player _player;

        private Effect _shader;

        private Dictionary<int, Texture2D> _menuOption = new Dictionary<int, Texture2D>();

        private Vector2[] _locations = new Vector2[4];

        private int _option = 0;

        private bool _playerTurn = true;

        private int timer = 0;

        private Action _exit;

        public BattleScreen(Player player, Enemy enemy, Effect shader, Action exit)
        {
            _player = player;
            _enemy = enemy;
            _shader = shader;
            _exit = exit;
            //_optionSelect = new Rectangle[4];
        }

        public override void Activate()
        {
            
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            _enemy.LoadContent(_content);
            _menuBox = _content.Load<Texture2D>("Battle_Menu_Upscale");
            _attack = _content.Load<Texture2D>("Attack_Button");
            _guard = _content.Load<Texture2D>("Guard_Button");
            _flee = _content.Load<Texture2D>("Flee_Button");
            _item = _content.Load<Texture2D>("Item_Button");

            _menuOption.Add(0, _attack);
            _menuOption.Add(1, _guard);
            _menuOption.Add(2, _item);
            _menuOption.Add(3, _flee);
            _locations[0] = new Vector2(136, 373);
            _locations[1] = new Vector2(623, 373);
            _locations[2] = new Vector2(136, 506);
            _locations[3] = new Vector2(623, 506);
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

            if (!_playerTurn)
            {
                int damage;
                if (_player.Defense < _enemy.GetStrength())
                {
                    damage = _enemy.GetStrength() - _player.Defense;
                }
                else
                {
                    damage = _player.Defense - _enemy.GetStrength();
                }
                
                if (damage < 0) damage = 0;
                _player.HP -= damage;
                _playerTurn = true;
                if (_option == 1) _player.Defense -= 5;
            }

            if (_player.HP <= 0)
            {

            }
            /*if (_enemy.GetHP() <= 0)
            {
                if (timer >= 100)
                {
                    Exit();
                }
                timer++;
            }*/
        }

        public override void HandleInput(GameTime gameTime, InputManager input)
        {
            if (input.B && _enemy.GetHP() <= 0)
            {
                //Unload();
                _player.Money += _enemy.GetMoney();
                Exit();
            }
            if (_playerTurn && (_enemy.GetHP() > 0 && _player.HP > 0))
            {
                if (input.Left && _option > 0)
                {
                    // _optionSelect[_option];
                    _option--;
                    //options[screenIndex].IsSelected = true;
                }
                if (input.Right && _option < 3)
                {
                    //options[screenIndex].IsSelected = false;
                    _option++;
                    //options[screenIndex].IsSelected = true;
                }
                if (input.Up && (_option == 2 || _option == 3))
                {
                    _option -= 2;
                }
                if (input.Down && (_option == 0 || _option == 1))
                {
                    _option += 2;
                }

                if (input.C)
                {
                    switch (_option)
                    {
                        case 0:
                            int damage = _player.Strength - _enemy.GetDefense();
                            if (damage <= 0) damage = 0;
                            _enemy.SetHP(_enemy.GetHP() - damage);
                            _enemy.Hit = true;
                            break;
                        case 1:
                            _player.Defense += 5;
                            break;
                        case 2:
                            _player.HP += 5;
                            break;
                        case 3:
                            int flee = RNG.GetInt(0, 10);
                            if (flee >= 5)
                            {
                                _player.DepressedMeter += 20;
                                Exit();
                            }
                            break;
                    }
                    _playerTurn = false;
                }
                
            }
            //else
            //{

                

                /*int enemyChoice = RNG.GetInt(0, 4);
                switch (enemyChoice)
                {
                    case 0:
                        int damage = _enemy.GetStrength() - _player.Defense;
                        if (damage < 0) damage = 0;
                        _player.HP -= damage;
                        
                        break;
                    case 1:
                        _player.Defense *= 2;
                        break;
                    case 2:
                        _player.HP += 5;
                        break;
                    case 3:
                        int flee = RNG.GetInt(0, 10);
                        if (flee >= 5)
                        {
                            _player.Mental = MentalCondition.Depressed;
                            Exit();
                        }
                        break;
                }*/
            //}
            

        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Black);

            var spriteBatch = ScreenManager.SpriteBatch;
            if (_player.Mental == MentalCondition.Depressed)
            {
                spriteBatch.Begin(effect: _shader);
                _enemy.Draw(gameTime, spriteBatch);
                if (_player.HP <= 0 || _enemy.GetHP() <= 0)
                {
                    if (_player.HP <= 0)
                    {
                        spriteBatch.DrawString(FontManager.DefaultFont, "You Lose....", new Vector2(480, 320), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(_menuBox, new Vector2(0, 340), Color.White);
                    for (int i = 0; i < 4; i++)
                    {
                        Color selected = (i == _option) ? Color.Yellow : Color.White;
                        spriteBatch.Draw(_menuOption.GetValueOrDefault(i), _locations[i], null, selected, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                    }
                }
                
            }
            else
            {
                
                spriteBatch.Begin();
                _enemy.Draw(gameTime, spriteBatch);
                if (_player.HP <= 0 || _enemy.GetHP() <= 0)
                {
                    if (_player.HP <= 0)
                    {
                        spriteBatch.DrawString(FontManager.DefaultFont, "You Lose....", new Vector2(480, 320), Color.White);
                    }
                }
                else
                {
                    spriteBatch.Draw(_menuBox, new Vector2(0, 340), Color.White);
                    for (int i = 0; i < 4; i++)
                    {
                        Color selected = (i == _option) ? Color.Yellow : Color.White;
                        spriteBatch.Draw(_menuOption.GetValueOrDefault(i), _locations[i], null, selected, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                    }
                }
                
                
                /*switch (_option)
                {
                    case 0:
                        spriteBatch.Draw(_attack, new Vector2(136, 373), null, Color.Navy, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case 1:
                        spriteBatch.Draw(_guard, new Vector2(623, 373), null, Color.Navy, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case 2:
                        spriteBatch.Draw(_item, new Vector2(136, 506), null, Color.Navy, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                    case 3:
                        spriteBatch.Draw(_flee, new Vector2(623, 506), null, Color.Navy, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                        break;
                }
                if (_option != )
                spriteBatch.Draw(_attack, new Vector2(136, 373), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0); 
                spriteBatch.Draw(_guard, new Vector2(623, 373), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                spriteBatch.Draw(_item, new Vector2(136, 506), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
                spriteBatch.Draw(_flee, new Vector2(623, 506), null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);*/

                //136.67f, 373.33f, 623.34f, 506.66f
            }


            spriteBatch.End();

        }

        public void Exit()
        {
            _exit?.Invoke();
            base.ExitScreen();
        } 
    }
}
