using Microsoft.Xna.Framework;
using Pong.Collision;
using Pong.Graphics;
using Pong.Screens;
using System.Collections.Generic;
using System.Timers;

namespace Pong.GameModes
{
    public class HockeyMode : PongMode
    {
        public Paddle LeftOuterPaddle { get; private set; }
        public Paddle LeftInnerPaddle { get; private set; }
        public Paddle RightOuterPaddle { get; private set; }
        public Paddle RightInnerPaddle { get; private set; }

        public HockeyMode(GameplayScreen game, Timer timer, CollisionManager collision, List<ISprite> gameSprites)
            : base(game, timer, collision, gameSprites)
        {

        }

        public override void CreateLevel()
        {
            LoadPaddleSprites();
            LoadLevelSprites();

            GameBall.GenerateBallDirection();
        }

        public override Paddle GetPaddle(int whichOne)
        {
            switch (whichOne)
            {
                case (int)PaddlesEnum.LeftOuter:
                    {
                        return LeftOuterPaddle;
                    }
                case (int)PaddlesEnum.LeftInner:
                    {
                        return LeftInnerPaddle;
                    }
                case (int)PaddlesEnum.RightOuter:
                    {
                        return RightOuterPaddle;
                    }
                case (int)PaddlesEnum.RightInner:
                    {
                        return RightInnerPaddle;
                    }
                default:
                    return LeftOuterPaddle;
            }
        }

        public override void SpriteUpdate(GameTime gameTime)
        {
            foreach (Sprite sprite in GameSprites.ToArray())
            {
                sprite.Update(gameTime);
            }
        }

        protected override void LoadPaddleSprites()
        {
            LeftOuterPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 70, 150);
            GameSprites.Add(LeftOuterPaddle);

            LeftInnerPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 140, 150);
            GameSprites.Add(LeftInnerPaddle);

            RightOuterPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 710, 150);
            GameSprites.Add(RightOuterPaddle);

            RightInnerPaddle = new Paddle(GameStructures, Game.ScreenManager.GraphicsDevice, 640, 150);
            GameSprites.Add(RightInnerPaddle);
        }
    }
}
