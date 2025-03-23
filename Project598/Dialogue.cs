using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public class Dialogue
    {
        Dictionary<string, List<string>> _dialogue;

        Texture2D _box;
        

        public Dialogue(Dictionary<string, List<string>> dialogue)
        {
            _dialogue = dialogue;
        }

        public Dictionary<string, List<string>> GetDialogue()
        {
            return _dialogue;
        }

        public void LoadContent(ContentManager content)
        {
            _box = content.Load<Texture2D>("Dialogue_Box_Normal");
            //_depressedBox = content.Load<Texture2D>("Dialogue_Box_distorted");
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_box, new Vector2(600, 200), Color.White);
        }
    }
}
