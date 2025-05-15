using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project598.Screens
{
    public class MainMenu : GameScreen
    {
        private ContentManager _content;

        //private List<MenuOption> options;

        private string[] _options = new string[2];

        private int screenIndex = 0;


        public MainMenu()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            _options[0] = "Start";
            _options[1] = "Credits";
            /*options = new List<MenuOption>()
            {
                new MenuOption("Start", new WorldScreen()) {IsSelected = true},
                new MenuOption("Credits", new Credits()) {IsSelected = false }
            };*/
            

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
            if (input.Escape)
            {
                ScreenManager.Game.Exit();
            }
            if (input.A)
            {
                if (screenIndex == 0)
                {
                    ScreenManager.AddScreen(new WorldScreen(input));
                }
            }
            if (input.C)
            {
                ScreenManager.AddScreen(new WorldScreen(input));
            }
            if ((input.Up || input.Left) && screenIndex > 0)
            {
                //options[screenIndex].IsSelected = false;
                screenIndex--;
                //options[screenIndex].IsSelected = true;
            }
            if ((input.Down || input.Right) && screenIndex < _options.Length)
            {
                //options[screenIndex].IsSelected = false;
                screenIndex++;
                //options[screenIndex].IsSelected = true;
            }

        }
        
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Black);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            var textAdjustment = FontManager.DefaultFont.MeasureString("Only in my Head");
            spriteBatch.DrawString(FontManager.DefaultFont, "Only in my Head", new Vector2((ScreenManager.GraphicsDevice.Viewport.Width - textAdjustment.X) / 2, 100), Color.White);
            for (int i = 0; i < _options.Length; i++)
            {
                var textSize = FontManager.DefaultFont.MeasureString(_options[i]);
                if (i == screenIndex)
                {
                    spriteBatch.DrawString(FontManager.DefaultFont, _options[i], new Vector2((ScreenManager.GraphicsDevice.Viewport.Width - textSize.X) / 2, 
                        (ScreenManager.GraphicsDevice.Viewport.Height - textSize.Y) / 3 + (100 * (i + 1))), Color.LimeGreen);
                }
                else
                {
                    spriteBatch.DrawString(FontManager.DefaultFont, _options[i], new Vector2((ScreenManager.GraphicsDevice.Viewport.Width - textSize.X) / 2, 
                        (ScreenManager.GraphicsDevice.Viewport.Height - textSize.Y) / 3 + (100 * (i + 1))), Color.White);
                }
            }
            /*foreach (MenuOption option in options)
            {
                //size = FontText.SizeOf(option.Name, "PublicPixelMedium");
                option.Draw(spriteBatch, new Vector2(ScreenManager.GraphicsDevice.Viewport.Width / 3, (100 * i * 2)));
                //spriteBatch.DrawString(FontManager.DefaultFont, option.Name, new Vector2(200, 200 + (i * 50)), Color.White);
                i++;
                
            }*/
            spriteBatch.End();
            
        }
    }
}
