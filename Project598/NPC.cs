using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public class NPC
    {
        public string Name { get; private set; }

        private Texture2D _texture;

        private string _textureName;

        public Dialogue Dialogue { get; private set; }

        public Vector2 Position { get; set; }

        public string Map { get; private set; }

        private int _timer = 0;

        private double _animationTimer;

        private int _animationFrame;

        private const float ANIMATION_SPEED = 0.5f;

        public bool Encourager { get; private set; }

        public NPC(string name, Vector2 position, string map, string texture, bool encourager)
        {
            Name = name;
            Position = position;
            Map = map;
            _textureName = texture;
            Encourager = encourager;
        }

        public void AddDialogue()
        {
            var temp = new Dictionary<string, List<string>>
            {
                { "Normal", new List<string> { "Welcome, Traveler!", "Having trouble finding something you want?", "Nothing really happens in this town of ours."} },
                { "Depressed", new List<string> { "Oh.....Another Traveler.......", "Still here?", "A foolish j ourney you are on."} },
                { "Encouragement", new List<string> { "Hope you have a Great Day!", "Life g ets better, so don't give up.", "You got this!"} }

            };
            Dialogue = new Dialogue(temp);
        }

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>(_textureName);
            Dialogue.LoadContent(content);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            int columns = _texture.Width / 32;
            int row = _texture.Height / 32;
            int totalFrames = columns * row;
            
            //if (_texture.Width > 32 || _texture.Height > 32)
            //{
                _animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (_animationTimer > ANIMATION_SPEED)
                {
                    _animationFrame = (_animationFrame + 1) % totalFrames;
                if (_animationFrame >= 3) _animationFrame = 0;
                    /*if (_texture.Height <= 64 && _texture.Width <= 32)
                    {
                        if (_animationFrame >= 2) _animationFrame = 0;
                    }
                    else
                    {
                        if (_animationFrame >= 3) _animationFrame = 0;
                    }*/
                    _animationTimer -= ANIMATION_SPEED;
                }
                int currentRow = _animationFrame / columns;
                int currentColumn = _animationFrame % columns;

                var source = new Rectangle(currentColumn * 32, currentRow * 32, 32, 32);
                spriteBatch.Draw(_texture, Position, source, Color.White);
            //}
            //else
            //{
             //   spriteBatch.Draw(_texture, Position, Color.White);
            //}
            
        }
    }
}
