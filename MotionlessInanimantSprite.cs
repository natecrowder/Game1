using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class MotionlessInanimantSprite : ISprite
    {
        private Texture2D Texture { get; set; }
        private int Rows { get; set; }
        private int Columns { get; set; }
        private Vector2 Offset;


        public MotionlessInanimantSprite(Texture2D texture, int rows, int columns, Vector2 offset)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Offset = offset;

        }

        public void Update()
        {
            // Do nothing because this sprite has nothing to update.
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int Width = Texture.Width / Columns;
            int Height = Texture.Height / Rows;
            int Row = 0;
            int Col = 0;

            Rectangle sourceRectangle = new Rectangle(Width * Row, Height * Col, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X + (int)Offset.X - Width * 2, (int)location.Y + (int)Offset.Y - Height * 2, Width * 2, Height * 2);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Vector2 GetOffset()
        {
            return Offset;
        }


    }
}
