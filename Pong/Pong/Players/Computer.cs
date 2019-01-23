using Pong.Graphics;

namespace Pong.Players
{
    public class Computer : PlayerBase
    {
        public Computer(string computerName, int difficulty, int score)
            : base(computerName, difficulty, score)
        {

        }

        public void Update(Paddle computerPaddle, Ball gameBall)
        {
            var ballYPosition = gameBall.Position.Y;
            var paddleBase = computerPaddle.Position.Y;
            var paddleTop = computerPaddle.Position.Y + computerPaddle.Height;

            if (ballYPosition <= paddleBase)
            {
                computerPaddle.Position = computerPaddle.MovePaddleUp(computerPaddle);
            }
            if (ballYPosition >= paddleTop)
            {
                computerPaddle.Position = computerPaddle.MovePaddleDown(computerPaddle);
            }
        }

        public void Update(Paddle computerOuterPaddle, Paddle computerInnerPaddle, Ball gameBall)
        {
            var ballYPosition = gameBall.Position.Y;
            var paddleBase = computerOuterPaddle.Position.Y;
            var paddleTop = computerOuterPaddle.Position.Y + computerOuterPaddle.Height;

            if (ballYPosition <= paddleBase)
            {
                computerOuterPaddle.Position = computerOuterPaddle.MovePaddleUp(computerOuterPaddle);
                computerInnerPaddle.Position = computerInnerPaddle.MovePaddleDown(computerInnerPaddle);
            }
            if (ballYPosition >= paddleTop)
            {
                computerOuterPaddle.Position = computerOuterPaddle.MovePaddleDown(computerOuterPaddle);
                computerInnerPaddle.Position = computerInnerPaddle.MovePaddleUp(computerInnerPaddle);
            }
        }
    }
}
