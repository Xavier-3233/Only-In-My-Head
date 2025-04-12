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
    public class Slime : Enemy
    {
        private const float ANIMATION_SPEED = 0.5f;

        private Texture2D _texture;

        private int _timer = 0;

        public bool Hit { get; set; }

        private double _animationTimer;

        private int _animationFrame;
        public Slime()
        {
            HP = 20;
            Strength = 7;
            Magic = 7;
            Defense = 5;
            Money = 20.00M;
            Position = new Vector2(480 - 32, 320 - 32);
        }

        public override void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("SlimeSheet");
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (_animationTimer > ANIMATION_SPEED)
            {
                _animationFrame++;
                if (_animationFrame >= 2) _animationFrame = 0;
                _animationTimer -= ANIMATION_SPEED;
            }

            int currentRow = _animationFrame / 2;
            int currentColumn = _animationFrame % 2;

            var source = new Rectangle(currentColumn * 32, currentRow * 32, 32, 32);
            if (Hit)
            {
                _animationFrame = 3;
                Hit = false;
            }
            if (HP == 0)
            {
                _animationFrame = 4;
                if (_timer >= 3)
                {
                    return;
                }
                _timer += 1;
            }

            spriteBatch.Draw(_texture, Position, source, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0);
        }

        

        
    }
}
