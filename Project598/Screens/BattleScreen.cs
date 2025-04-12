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

        private Enemy _enemy;

        private Player _player;

        private Effect _shader;

        public BattleScreen(Player player, Enemy enemy, Effect shader)
        {
            _player = player;
            _enemy = enemy;
            _shader = shader;
        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            _enemy.LoadContent(_content);
            
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
            if (input.Enter)
            {
                //Unload();
                ScreenManager.RemoveScreen(this);
            }

            /*if (input.C)
            {
                ScreenManager.AddScreen(new WorldScreen(input));
            }*/
        }

        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Black);

            var spriteBatch = ScreenManager.SpriteBatch;
            //List<string> temp;
            if (_player.Mental == MentalCondition.Depressed)
            {
                spriteBatch.Begin(effect: _shader);
                _enemy.Draw(gameTime, spriteBatch);
            }
            else
            {
                spriteBatch.Begin();
                _enemy.Draw(gameTime, spriteBatch);
            }
            
            //spriteBatch.DrawString(FontManager.DefaultFont, "Insert Combat Here", new Vector2(480, 320), Color.White);
            /*if (_player.Mental == MentalCondition.Depressed)
            {
                temp = _npc.Dialogue.GetDialogue()["Depressed"];
                string format = WrapText(FontManager.DefaultFont, temp[0], 600);
                spriteBatch.Draw(_depressedBox, new Vector2(180, 0), Color.White);
                spriteBatch.DrawString(FontManager.DefaultFont, format, new Vector2(200, 20), Color.Red);
            }
            else
            {
                temp = _npc.Dialogue.GetDialogue()["Normal"];
                string format = WrapText(FontManager.DefaultFont, temp[0], 600);
                spriteBatch.Draw(_box, new Vector2(180, 0), Color.White);
                spriteBatch.DrawString(FontManager.DefaultFont, format, new Vector2(200, 20), Color.White);
            }*/






            spriteBatch.End();

        }
    }
}
