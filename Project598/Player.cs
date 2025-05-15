using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598
{
    public class Player
    {
        //private KeyboardState keyboardState;
        //private KeyboardState previous;
        private Texture2D _texture;
        public Vector2 Position { get; set; } = new Vector2(0, 13 * 32);

        public int HP { get; set; } = 50;

        public int Strength { get; set; } = 10;

        public int Defense { get; set; } = 10;

        public int Magic { get; set; } = 10;

        public decimal Money { get; set; } = 30.00M;

        public MentalCondition Mental { get; set; } = MentalCondition.Normal;

        public bool Hit { get; set; } = false;

        private int _depressedMeter = 0;

        public int DepressedMeter
        {
            get
            {
                return _depressedMeter;
            }
            set
            {
                _depressedMeter += value;
                //_depressedMeter 
                if (_depressedMeter >= 100)
                {
                    Mental = MentalCondition.Depressed;
                }
            }
        } 


        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Test_Person-1");

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, Position, Color.White);
        }

        public void Move(Vector2 direction)
        {
            Position += direction * 32;
        }
    }
}
