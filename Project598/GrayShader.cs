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
    public class GrayShader
    {
        private Effect grayscaleEffect;
        private GraphicsDevice graphicsDevice;

        public GrayShader(GraphicsDevice graphicsDevice, ContentManager content, string effectFile)
        {
            this.graphicsDevice = graphicsDevice;
            grayscaleEffect = content.Load<Effect>(effectFile);
        }

        public void Apply(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend, null, null, null, grayscaleEffect);
        }

        public void End(SpriteBatch spriteBatch)
        {
            spriteBatch.End();
        }
    }
}
