using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Game1
{
    public class KeyboardController : IController
    {
        private KeyboardState KeyState;

        public Game1 MyGame { get; }

        public KeyboardController(Game1 game1)
        {
            MyGame = game1;
        }
        public void Update()
        {
            // Get information necessary for sprites
            KeyState = Keyboard.GetState();
            Texture2D Texture = MyGame.Content.Load <Texture2D> ("linksprite");
            Vector2 Offset = MyGame.GetOffset();
            int Rows = 1;
            int Cols = 6;

            // Determine the action to take
            if (KeyState.IsKeyDown(Keys.D0))
            {
                MyGame.Exit();
            }
            else if (KeyState.IsKeyDown(Keys.D1))
            {
                MyGame.SetSprite(new MotionlessInanimantSprite(Texture, Rows, Cols, Offset));
            }
            else if (KeyState.IsKeyDown(Keys.D2))
            {
                MyGame.SetSprite(new MotionlessAnimatedSprite(Texture, Rows, Cols, Offset));
            }
            else if (KeyState.IsKeyDown(Keys.D3))
            {
                MyGame.SetSprite(new MovingInanimantSprite(Texture, Rows, Cols, Offset));
            }
            else if (KeyState.IsKeyDown(Keys.D4))
            {
                MyGame.SetSprite(new MovingAnimatedSprite(Texture, Rows, Cols, Offset));
            }
        }
    }
}
