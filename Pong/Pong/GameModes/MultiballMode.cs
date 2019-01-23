using Microsoft.Xna.Framework;
using Pong.Collision;
using Pong.Graphics;
using Pong.Screens;
using System.Collections.Generic;
using System.Timers;

namespace Pong.GameModes
{
    public class MultiballMode : GameModeBase
    {
        public Paddle LeftPaddle;
        public Paddle RightPaddle;
        public Ball GameBall { get; private set; }
        private Wall TopLeftWall { get; set; }
        private Wall TopWall { get; set; }
        private Wall TopRightWall { get; set; }
        private Wall BottomLeftWall { get; set; }
        private Wall BottomWall { get; set; }
        private Wall BottomRightWall { get; set; }

        public MultiballMode(GameplayScreen game, Timer timer, CollisionManager collision, List<ISprite> gameSprites)
            : base(game, timer, collision, gameSprites)
        {

        }

        public override void CreateLevel()
        {
            LoadPaddleSprites();
            LoadLevelSprites();

            //GameBall.GenerateBallDirection();
        }

        public override Paddle GetPaddle(int whichOne)
        {
            return (whichOne == (int)PaddlesEnum.LeftOuter) ? LeftPaddle : RightPaddle;
        }

        public override Ball GetGameBall()
        {
            return GameBall;
        }

        public override void SpriteUpdate(GameTime gameTime)
        {
            foreach (Sprite sprite in GameSprites.ToArray())
            {
                sprite.Update(gameTime);
            }
        }

        protected virtual void LoadPaddleSprites()
        {
            LeftPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 70, 150);
            GameSprites.Add(LeftPaddle);

            RightPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 710, 150);
            GameSprites.Add(RightPaddle);
        }

        protected virtual void LoadLevelSprites()
        {
            //GameBall = new Ball(GameStructures, Game.ScreenManager.GraphicsDevice, 0, 0, Color.Orange);
            //GameSprites.Add(GameBall);

            TopLeftWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 60, 60, 10, 80);
            GameSprites.Add(TopLeftWall);

            TopWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 70, 60, 650, 10);
            GameSprites.Add(TopWall);

            TopRightWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 720, 60, 10, 80);
            GameSprites.Add(TopRightWall);

            BottomLeftWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 60, 380, 10, 80);
            GameSprites.Add(BottomLeftWall);

            BottomWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 70, 450, 650, 10);
            GameSprites.Add(BottomWall);

            BottomRightWall = new Wall(GameStructures, Game.ScreenManager.GraphicsDevice, 720, 380, 10, 80);
            GameSprites.Add(BottomRightWall);
        }

        public override void StartTimer(int intervalInMilliSeconds)
        {
            TimerMode.Elapsed += TimerHandler;
            TimerMode.Interval = intervalInMilliSeconds;
            TimerMode.Enabled = true;
        }

        public override void TimerHandler(object sender, ElapsedEventArgs eventFired)
        {
            // ToDo - randomise the colour of the new ball.
            GameBall = new Ball(GameStructures, Game.ScreenManager.GraphicsDevice, 0, 0, Color.SkyBlue);
            GameSprites.Add(GameBall);
            GameBall.GenerateBallDirection();
        }

        public override void GoalReset()
        {
            GameSprites.Remove(GameBall);
        }
    }
}
