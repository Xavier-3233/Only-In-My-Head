using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598.Screens
{
    public class MenuOption 
    {
        public string Name = "";

        public GameScreen Screen;

        public Keys Key;

        public bool IsScreenSelection = false;

        public bool IsControlSelection = false;

        public bool IsSelected = false;

        public MenuOption(string name, GameScreen screen)
        {
            Name = name;
            Screen = screen;
            IsScreenSelection = true;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            Color color = IsSelected ? Color.White : Color.LimeGreen;
            spriteBatch.DrawString(FontManager.DefaultFont, Name, position, color);
        }
    }
}
