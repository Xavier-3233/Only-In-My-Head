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
    public abstract class Enemy
    {
        protected Texture2D Texture { get; set; }

        protected Vector2 Position { get; set; }

        protected int HP { get; set; } 

        protected int Strength { get; set; }

        protected int Magic { get; set; }

        protected int Defense { get; set; }

        protected Decimal Money { get; set; }

        public int GetHP()
        {
            return HP;
        }

        public int GetStrength()
        {
            return Strength;
        }

        public int GetMagic()
        {
            return Magic;
        }

        public int GetDefense()
        {
            return Defense;
        }

        public void SetHP(int hp)
        {
            HP = hp;
        }


        public abstract void LoadContent(ContentManager content);

        public abstract void Update(GameTime gameTime);

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
