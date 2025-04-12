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
    public class NPC
    {
        public string Name { get; private set; }

        private Texture2D _texture;

        public Dialogue Dialogue { get; private set; }

        public Vector2 Position { get; set; }

        public string Map { get; private set; }

        public NPC(string name, Vector2 position, string map)
        {
            Name = name;
            //Dialogue = dialogue;
            Position = position;
            Map = map;
        }

        public void AddDialogue()
        {
            var temp = new Dictionary<string, List<string>>
            {
                { "Normal", new List<string> { "Welcome, Traveler!", "Having trouble finding something you want?"} },
                { "Depressed", new List<string> { "Oh.....Another Traveler.......", "Still here?"} },

            };
            Dialogue = new Dialogue(temp);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Brick");
            Dialogue.LoadContent(content);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }
    }
}
