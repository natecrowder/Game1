using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class TextSprite : ISprite
    {
        private readonly string Text;
        private readonly SpriteFont Font;
        public TextSprite(string text, SpriteFont font)
        {
            Text = text;
            Font = font;
        }
        public void Update()
        {
            // Do nothing here
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
     
            spriteBatch.Begin();
            spriteBatch.DrawString(Font, Text, location, Color.White);
            spriteBatch.End();
        }
        
        public Vector2 GetOffset()
        {
            return new Vector2(0, 0);
        }

    }
}
