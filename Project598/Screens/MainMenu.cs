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

        List<MenuOption> options;

        private int screenIndex = 0;


        public MainMenu()
        {

        }

        public override void Activate()
        {
            if (_content == null) _content = new ContentManager(ScreenManager.Game.Services, "Content");
            options = new List<MenuOption>()
            {
                new MenuOption("Start", new Credits()) {IsSelected = true},
                new MenuOption("Credits", new Credits()) {IsSelected = true }
            };
            

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
                if (options[screenIndex].IsScreenSelection)
                {
                    ScreenManager.AddScreen(options[screenIndex].Screen);
                    GameScreen[] mm = ScreenManager.GetScreens();
                    int a = mm.Length;

                }
            }
            if (input.C)
            {
                ScreenManager.AddScreen(new WorldScreen(input));
            }
            if ((input.Up || input.Left) && screenIndex > 0)
            {
                options[screenIndex].IsSelected = false;
                screenIndex--;
                options[screenIndex].IsSelected = true;
            }
            if ((input.Down || input.Right) && screenIndex < options.Count - 1)
            {
                options[screenIndex].IsSelected = false;
                screenIndex++;
                options[screenIndex].IsSelected = true;
            }

        }
        
        public override void Draw(GameTime gameTime)
        {
            ScreenManager.GraphicsDevice.Clear(Color.Black);

            var spriteBatch = ScreenManager.SpriteBatch;

            spriteBatch.Begin();
            spriteBatch.DrawString(FontManager.DefaultFont, "Hi!", new Vector2(200, 200), Color.White);
            

            int i = 0;
            foreach (MenuOption option in options)
            {
                //size = FontText.SizeOf(option.Name, "PublicPixelMedium");
                option.Draw(spriteBatch, new Vector2(240, (200 * i * 2)));
                //spriteBatch.DrawString(FontManager.DefaultFont, option.Name, new Vector2(200, 200 + (i * 50)), Color.White);
                i++;
                
            }
            spriteBatch.End();
            
        }
    }
}
