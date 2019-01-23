using Microsoft.Xna.Framework;
using Pong.Screens;
using Pong.StateManager;

namespace Pong
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameManager : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private readonly ScreenManager _screenManager;

        public GameManager()
        {
            _graphics = new GraphicsDeviceManager(this)
                {
                    PreferredBackBufferWidth = 800,
                    PreferredBackBufferHeight = 480
                };

            _screenManager = new ScreenManager(this);

            Content.RootDirectory = "Content";

            Components.Add(_screenManager);

            // Activate the first screens.
            _screenManager.AddScreen(new MainMenuScreen(), null);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }
    }
}
