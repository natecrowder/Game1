using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Xml;

namespace Game1
{
    public class Game1 : Game
    {
        // Initialize fields
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private ISprite Sprite;
        private TextSprite TextSprite;
        private Vector2 Offset;
        Vector2 CharacterLocation;
        List<IController> controllerList;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        public void SetSprite(ISprite newSprite)
        {
            this.Sprite = newSprite;
        }

        public Vector2 GetOffset()
        {
            return Offset;     
        }

        // Add controllers to list of controllers to update and call rest of Game1
        protected override void Initialize()
        {
            controllerList = new List<IController>();
            controllerList.Add(new KeyboardController(this));
            controllerList.Add(new MouseController(this));
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            Texture2D LinkSprite = Content.Load<Texture2D>("linksprite");
            this.Sprite = new MotionlessInanimantSprite(LinkSprite, 1, 6, Offset);
            SpriteFont Font = Content.Load<SpriteFont>("Font");
            this.TextSprite = new TextSprite("Credits\nMade By: Nate Crowder\nSprites From:\nhttps://www.spriters-resource.com/nes/legendofzelda/sheet/8366/", Font);

        }

        protected override void UnloadContent()
        {
            base.UnloadContent();
        }

        // Update sprite, controllers, and sprite location
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            foreach(IController controller in controllerList)
            {
                controller.Update();
            }

            Sprite.Update();
            base.Update(gameTime);

            // Update location of sprite
            Offset = this.Sprite.GetOffset();
            CharacterLocation.X = GraphicsDevice.Viewport.Width / 2 + Offset.X;
            CharacterLocation.Y = GraphicsDevice.Viewport.Height / 2 + Offset.Y;

        }

        protected override void Draw(GameTime gameTime)
        {
            _graphics.GraphicsDevice.Clear(Color.CornflowerBlue);
            Sprite.Draw(_spriteBatch, CharacterLocation);

            TextSprite.Draw(_spriteBatch, new Vector2(5, 355));
            base.Draw(gameTime);
        }
    }
}