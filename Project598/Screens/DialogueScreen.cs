using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using System.Runtime.CompilerServices;

namespace Project598.Screens
{
    public class DialogueScreen : GameScreen
    {
        private ContentManager _content;

        private Texture2D _box;

        private Texture2D _depressedBox;

        private NPC _npc;

        private Player _player;

        private bool _rolled = false;

        private int textOption = 0;

        public DialogueScreen(Player player, NPC npc)
        {
            _player = player;
            _npc = npc;
        }
        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");

            
            _box = _content.Load<Texture2D>("Dialogue_Box_Normal");
            _depressedBox = _content.Load<Texture2D>("Dialogue_Box_Distorted");
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
                Unload();
                ScreenManager.RemoveScreen(this);
                _rolled = false;
            }

            /*if (input.C)
            {
                ScreenManager.AddScreen(new WorldScreen(input));
            }*/
        }

        public override void Draw(GameTime gameTime)
        {
            //ScreenManager.GraphicsDevice.Clear(Color.);

            var spriteBatch = ScreenManager.SpriteBatch;
            List<string> temp;
            
            if (!_rolled)
            {
                textOption = RNG.GetInt(0, 3);
                _rolled = true;
            }
            spriteBatch.Begin();

            if (_npc.Encourager)
            {
                temp = _npc.Dialogue.GetDialogue()["Encouragement"];
                string format = WrapText(FontManager.DefaultFont, temp[textOption], 600);
                spriteBatch.Draw(_box, new Vector2(180, 0), Color.White);
                spriteBatch.DrawString(FontManager.DefaultFont, format, new Vector2(200, 20), Color.Aqua);
                if (_player.Mental == MentalCondition.Depressed)
                {
                    _player.Mental = MentalCondition.Normal;
                    _player.DepressedMeter = -_player.DepressedMeter;
                }
            }
            else if (_player.Mental == MentalCondition.Depressed)
            {
                temp = _npc.Dialogue.GetDialogue()["Depressed"];
                string format = WrapText(FontManager.DefaultFont, temp[textOption], 600);
                spriteBatch.Draw(_depressedBox, new Vector2(180, 0), Color.White);
                spriteBatch.DrawString(FontManager.DefaultFont, format, new Vector2(200, 20), Color.Red);
            }
            
            else
            {
                temp = _npc.Dialogue.GetDialogue()["Normal"];
                string format = WrapText(FontManager.DefaultFont, temp[textOption], 600);
                spriteBatch.Draw(_box, new Vector2(180, 0), Color.White);
                spriteBatch.DrawString(FontManager.DefaultFont, format, new Vector2(200, 20), Color.White);
            }
            
            
   

            spriteBatch.End();

        }
        private string WrapText(SpriteFont font, string text, float maxWidth)
        {
            string[] words = text.Split(' ');
            StringBuilder wrappedText = new StringBuilder();
            float lineWidth = 0;
            float spaceWidth = font.MeasureString(" ").X;

            foreach (string word in words)
            {
                Vector2 size = font.MeasureString(word);

                // Check if adding the word exceeds the maxWidth
                if (lineWidth + size.X > maxWidth - 10)
                {
                    wrappedText.Append("\n"); // New line
                    lineWidth = 0;
                }

                wrappedText.Append(word + " ");
                lineWidth += size.X + spaceWidth;
            }

            return wrappedText.ToString();
        }
    }
}
