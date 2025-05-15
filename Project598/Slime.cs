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

        private const float HIT_DURATION = 1f;

        private Texture2D _texture;

        private int _timer = 0;

        private double _animationTimer;

        private int _animationFrame;

        private bool _pause = false;

        private double _pauseTimer;

        public Slime()
        {
            HP = 20;
            Strength = 10;
            Magic = 7;
            Defense = 5;
            Money = 20.00M;
            Position = new Vector2(480 - 32, 220 - 32);
            Hit = false;
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
            if (!_pause)
            {
                _animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

                if (_animationTimer > ANIMATION_SPEED)
                {
                    _animationFrame++;
                    if (_animationFrame >= 2) _animationFrame = 0;
                    _animationTimer -= ANIMATION_SPEED;
                }


            }
            else
            {
                _pauseTimer += gameTime.ElapsedGameTime.TotalSeconds;
                if (_pauseTimer >= HIT_DURATION)
                {
                    _pause = false;
                    _pauseTimer = 0;
                    Hit = false;
                }
            }

            int currentRow = _animationFrame / 2;
            int currentColumn = _animationFrame % 2;

            var source = new Rectangle(currentColumn * 32, currentRow * 32, 32, 32);
            if (Hit)
            {
                _animationFrame = 2;
                _pause = true;
                
            }
            if (HP <= 0)
            {
                _animationFrame = 3;
                _pause = true;
                if (_pauseTimer >= HIT_DURATION)
                {
                    return;
                }
                _timer += 1;
            }

            spriteBatch.Draw(_texture, Position, source, Color.White, 0f, Vector2.Zero, 3f, SpriteEffects.None, 0);
        }

        

        
    }
}
