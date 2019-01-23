using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Pong.Collision;
using Pong.Graphics;
using Pong.Helpers;
using Pong.Screens;
using System.Collections.Generic;
using System.Timers;

namespace Pong.GameModes
{
    public abstract class GameModeBase
    {
        public Timer TimerMode { get; protected set; }
        public GameplayScreen Game { get; protected set; }
        public SpriteBatch SpriteBatches { get; protected set; }
        public CollisionManager CollisionManagers { get; protected set; }
        public GameStructure GameStructures { get; protected set; }
        public List<ISprite> GameSprites { get; protected set; }

        public enum PaddlesEnum
        {
            LeftOuter,
            RightOuter,
            LeftInner,
            RightInner
        };

        protected GameModeBase(GameplayScreen game, Timer timer, CollisionManager collisionManager, List<ISprite> gameSprites)
        {
            TimerMode = timer;
            Game = game;
            CollisionManagers = collisionManager;
            GameStructures = new GameStructure(Game.ScreenManager.Game.Content, Game.ScreenManager.Game.Window, CollisionManagers);
            GameSprites = gameSprites;
            SpriteBatches = new SpriteBatch(Game.ScreenManager.GraphicsDevice);
        }

        public abstract void StartTimer(int intervalInMilliSeconds);
        public abstract void TimerHandler(object sender, ElapsedEventArgs eventFired);
        public abstract void CreateLevel();
        public abstract void GoalReset();
        public abstract Paddle GetPaddle(int whichOne);
        public abstract Ball GetGameBall();
        public abstract void SpriteUpdate(GameTime gameTime);

    }
}
