using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Project598
{
    public static class FontManager
    {
        public static SpriteFont DefaultFont { get; private set; }

        public static void LoadContent(ContentManager content)
        {
            DefaultFont = content.Load<SpriteFont>("NothingYouCouldDo");
        }
    }
}
