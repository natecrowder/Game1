using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    internal class MovingAnimatedSprite : ISprite
    {
        // Fields needed for sprite
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int CurrentFrame;
        private int FinalFrame;
        private Vector2 Offset;
        private SpriteEffects Effect;

        // Sprite constructor
        public MovingAnimatedSprite(Texture2D texture, int rows, int columns, Vector2 offset)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            
            // Specific frames needed for this animation
            CurrentFrame = 2;
            FinalFrame = 4;
            
            // Distance from center of game
            Offset = offset;
        }

        // Updates sprite's animation
        public void Update()
        {
            CurrentFrame++;
            if (CurrentFrame == FinalFrame)
            {
                CurrentFrame = 2;
            }

            // Determines if sprite moves left or right
            if (Effect == SpriteEffects.None)
            {
                Offset.X++;
            } else
            {
                Offset.X--;
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

            // Determines whether the sprite should be facing right of left
            GetEffect(destinationRectangle);
            
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White, 0, new Vector2(0,0), Effect, 1);
            spriteBatch.End();
        }

        private void GetEffect(Rectangle destinationRectangle)
        {
            if (destinationRectangle.Right >= 800)
            {
                Effect = SpriteEffects.FlipHorizontally;
            }
            else if (destinationRectangle.Left <= 0)
            {
                Effect = SpriteEffects.None;
            }
        }
        public Vector2 GetOffset()
        {
            return Offset;
        }
    }
}
