using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class MouseController : IController
    {
        private Vector2 MousePosition;

        private MouseState MouseState;

        public Game1 MyGame { get; }

        public MouseController(Game1 game1)
        {
            MyGame = game1;
        }
        public void Update() {
            // Get necessary information for sprites
            MouseState = Mouse.GetState();
            MousePosition.X = MouseState.X;
            MousePosition.Y = MouseState.Y;
            Texture2D Texture = MyGame.Content.Load <Texture2D> ("linksprite");
            Vector2 Offset = MyGame.GetOffset();
            int Rows = 1;
            int Cols = 6;

            // Determine action to take
            if (MouseState.LeftButton == ButtonState.Pressed)
            {
                if (MousePosition.X > MyGame.GraphicsDevice.Viewport.Width / 2)
                {
                    if (MousePosition.Y > MyGame.GraphicsDevice.Viewport.Height / 2)
                    {
                        MyGame.SetSprite(new MovingAnimatedSprite(Texture, Rows, Cols, Offset));
                    }
                    else
                    {
                        MyGame.SetSprite(new MotionlessAnimatedSprite(Texture, Rows, Cols, Offset));
                    }
                } else {
                    if (MousePosition.Y > MyGame.GraphicsDevice.Viewport.Height / 2) 
                    {
                        MyGame.SetSprite(new MovingInanimantSprite(Texture, Rows, Cols, Offset));
                    }
                    else
                    {
                        MyGame.SetSprite(new MotionlessInanimantSprite(Texture, Rows, Cols, Offset));
                    }
                }
            }

            if (MouseState.RightButton == ButtonState.Pressed)
            {
                MyGame.Exit();
            }

        }
    }
}
