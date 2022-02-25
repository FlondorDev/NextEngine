using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NextEngine;

namespace GameTest
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;

        public Player player;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Utils.Init(Content, GraphicsDevice, _graphics);

            player = new Player(new Vector2(0, 0));
            new Wall(new Vector2(50, 60));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            LoaderManager.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            Utils.UpdateDelta((float)gameTime.ElapsedGameTime.TotalSeconds);
            Window.Title = $"{1.0f / Utils.DeltaTime}";

            UpdateManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            DrawManager.Draw();

            base.Draw(gameTime);
        }
    }
}
