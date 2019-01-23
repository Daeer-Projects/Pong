using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Pong.Screens.Controls;
using Pong.StateManager;
using Pong.Helpers;
using Pong.Constructors;
using Pong.Players;
using System.Collections.Generic;

namespace Pong.Screens
{
    /// <summary>
    ///     This screen implements the actual game logic. It is just a
    ///     placeholder to get the idea across: you'll probably want to
    ///     put some more interesting gameplay in here!
    /// </summary>
    public class GameplayScreen : GameScreen
    {
        private LevelConstructor _levelConstructor;
        private readonly OptionsSelected _gameOptions;
        private readonly GameOverlay _gameOverlay;
        private ContentManager _content;
        private int _firstTo;
        private bool _finished;
        private float _pauseAlpha;
        public List<PlayerBase> Players { get; private set; }


        #region Initialization

        /// <summary>
        ///     Constructor.
        /// </summary>
        public GameplayScreen(OptionsSelected gameOptions)
        {
            _gameOptions = gameOptions;
            if (_gameOptions.IfNull())
            {
                _gameOptions.AmountOfPlayers = "1";
                _gameOptions.FirstTo = "3";
                _gameOptions.GameModeType = "Pong";
                _gameOptions.PlayerName = "Fred";
                _gameOptions.UpKey = 'q';
                _gameOptions.DownKey = 'a';
                _gameOptions.LeftKey = 'z';
                _gameOptions.RightKey = 'x';
            }

            TransitionOnTime = TimeSpan.FromSeconds(1.5);
            TransitionOffTime = TimeSpan.FromSeconds(0.5);
            _gameOverlay = new GameOverlay();
        }


        /// <summary>
        ///     Load graphics content for the game.
        /// </summary>
        public override void LoadContent()
        {
            if (_content == null)
            {
                _content = new ContentManager(ScreenManager.Game.Services, "Content");
            }

            switch (_gameOptions.GameModeType)
            {
                case "Pong":
                    {
                        _levelConstructor = new PongConstructor(this, _gameOptions);
                        break;
                    }
                case "Hockey":
                    {
                        _levelConstructor = new HockeyConstructor(this, _gameOptions);
                        break;
                    }
                case "MultiBall":
                    {
                        _levelConstructor = new MultiballConstructor(this, _gameOptions);
                        break;
                    }
            }

            _levelConstructor.CreateLevel();
            _levelConstructor.StartTimer();

            _gameOverlay.LoadContent(_content, _levelConstructor);

            // ToDo: Get the Options Menu value.
            Int32.TryParse(_gameOptions.FirstTo, out _firstTo);
            _finished = false;

            // once the load has finished, we use ResetElapsedTime to tell the game's
            // timing mechanism that we have just finished a very long frame, and that
            // it should not try to catch up.
            ScreenManager.Game.ResetElapsedTime();
        }

        /// <summary>
        ///     Unload graphics content used by the game.
        /// </summary>
        public override void UnloadContent()
        {
            _content.Unload();
        }

        #endregion

        #region Update and Draw
        /// <summary>
        ///     Updates the state of the game. This method checks the GameScreen.IsActive
        ///     property, so the game will stop updating when the pause menu is active,
        ///     or if you tab away to a different application.
        /// </summary>
        public override void Update(GameTime gameTime, bool otherScreenHasFocus,
                                    bool coveredByOtherScreen)
        {
            base.Update(gameTime, otherScreenHasFocus, false);

            // Gradually fade in or out depending on whether we are covered by the pause screen.
            _pauseAlpha = coveredByOtherScreen ? Math.Min(_pauseAlpha + 1f / 32, 1) : Math.Max(_pauseAlpha - 1f / 32, 0);

            if (IsActive)
            {
                _levelConstructor.CollisionManagers.CheckForCollisions();
                _levelConstructor.CollisionManagers.CheckForScreenCollision();
                _levelConstructor.SpriteUpdate(gameTime);

                if (_levelConstructor.GetMaxScoreOfPlayers() == _firstTo)
                {
                    _finished = true;
                }

                _levelConstructor.Update();

                ScreenManager.GraphicsDevice.Clear(_levelConstructor.HeadingToWho() == (int)Team.Side.Left ? Color.Red : Color.Green);

                if (_finished)
                {
                    string winner = (_levelConstructor.LeftTeam.LeftScore == _firstTo)
                                        ? _levelConstructor.LeftTeam.TeamName
                                        : _levelConstructor.RightTeam.TeamName;
                    string message = "Yay! " + winner + " is the winner!";
                    LoadingScreen.Load(ScreenManager, message, 0, new WinnerScreen(message, true));
                    GameReset();
                }

            }
        }


        /// <summary>
        ///     Lets the game respond to player input. Unlike the Update method,
        ///     this will only be called when the gameplay screen is active.
        /// </summary>
        public override void HandleInput(InputState input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            // Look up inputs for the active player profile.
            if (ControllingPlayer != null)
            {
                var playerIndex = (int)ControllingPlayer.Value;

                KeyboardState keyboardState = input.CurrentKeyboardStates[playerIndex];
                GamePadState gamePadState = input.CurrentGamePadStates[playerIndex];

                // The game pauses either if the user presses the pause button, or if
                // they unplug the active gamepad. This requires us to keep track of
                // whether a gamepad was ever plugged in, because we don't want to pause
                // on PC if they are playing with a keyboard and have no gamepad at all!
                bool gamePadDisconnected = !gamePadState.IsConnected &&
                                           input.GamePadWasConnected[playerIndex];

                if (input.IsPauseGame(ControllingPlayer) || gamePadDisconnected)
                {
                    ScreenManager.AddScreen(new PauseMenuScreen(), ControllingPlayer);
                }
                else
                {
                    _levelConstructor.HandleInput(keyboardState);
                }
            }
        }


        /// <summary>
        ///     Draws the gameplay screen.
        /// </summary>
        public override void Draw(GameTime gameTime)
        {
            _levelConstructor.SpriteBatches.Begin();

            foreach (var sprite in _levelConstructor.Sprites)
            {
                sprite.Draw(_levelConstructor.SpriteBatches);
            }

            _gameOverlay.Draw(_levelConstructor.SpriteBatches, ScreenManager);
            _levelConstructor.SpriteBatches.End();

            // If the game is transitioning on or off, fade it out to black.
            if (TransitionPosition > 0 || _pauseAlpha > 0)
            {
                float alpha = MathHelper.Lerp(1f - TransitionAlpha, 1f, _pauseAlpha / 2);

                ScreenManager.FadeBackBufferToBlack(alpha);
            }
        }

        private void GameReset()
        {
            _levelConstructor.LeftTeam.LeftScore = 0;
            _levelConstructor.RightTeam.RightScore = 0;
            _finished = false;
        }

        #endregion
    }
}