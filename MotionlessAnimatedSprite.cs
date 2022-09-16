using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class MotionlessAnimatedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int FinalFrame;
        private Vector2 Offset;

        public MotionlessAnimatedSprite(Texture2D texture, int rows, int columns, Vector2 offset)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            CurrentFrame = 0;
            FinalFrame = 2;
            Offset = offset;
        }

        // Updates the sprite animation
        public void Update()
        {
            CurrentFrame++;
            if(CurrentFrame == FinalFrame)
            {
                CurrentFrame = 0;
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int Width = Texture.Width / Columns;
            int Height = Texture.Height / Rows;
            int Row = CurrentFrame / Columns;
            int Col = CurrentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(Width * Col, Height * Row, Width, Height);
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
