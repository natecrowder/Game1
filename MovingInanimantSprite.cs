using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class MovingInanimantSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private Vector2 Offset;
        private bool MovingDown = true;

        public MovingInanimantSprite(Texture2D texture, int rows, int columns, Vector2 offset)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Offset = offset;
        }

        // Determines direction of sprite movement
        public void Update()
        {
            if (MovingDown)
            {
                Offset.Y++;
            }
            else
            {
                Offset.Y--;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int Width = Texture.Width / Columns;
            int Height = Texture.Height / Rows;
            int Row = 0;
            int Col = 0;

            Rectangle sourceRectangle = new Rectangle(Width * Row, Col * Row, Width, Height);
            Rectangle destinationRectangle = new Rectangle((int)location.X + (int)Offset.X - Width * 2, (int)location.Y + (int)Offset.Y - Height * 2, Width * 2, Height * 2);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            GetEffect(destinationRectangle);
            

            spriteBatch.End();
        }

        private void GetEffect(Rectangle destinationRectangle)
        {
            if (destinationRectangle.Bottom >= 480)
            {
                MovingDown = false;
            }
            else if (destinationRectangle.Top <= 0)
            {
                MovingDown = true;
            }
        }
        public Vector2 GetOffset()
        {
            return Offset;
        }
    }
}
