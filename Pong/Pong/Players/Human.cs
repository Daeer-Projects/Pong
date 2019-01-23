using System;
using Microsoft.Xna.Framework.Input;

namespace Pong.Players
{
    public class Human : PlayerBase
    {
        private Char UpKey { get; set; }
        private Char DownKey { get; set; }
        private Char LeftKey { get; set; }
        private Char RightKey { get; set; }

        public Human(string playerName, int difficulty, int score, Char up, Char down)
            : base(playerName, difficulty, score)
        {
            UpKey = up;
            DownKey = down;
        }

        public Human(string playerName, int difficulty, int score, Char up, Char down, Char left, Char right)
            : base(playerName, difficulty, score)
        {
            UpKey = up;
            DownKey = down;
            LeftKey = left;
            RightKey = right;
        }

        public void Update()
        {

        }

        public void HandleInput(KeyboardState keyboardState, bool hockeyMode)
        {
            if (keyboardState.IsKeyDown((Keys)Char.ToUpper(DownKey)))
            {
                PlayerPaddle.Position = PlayerPaddle.MovePaddleDown(PlayerPaddle);
                if (hockeyMode)
                {
                    PlayerSecondPaddle.Position = PlayerSecondPaddle.MovePaddleUp(PlayerSecondPaddle);
                }
            }
            else if (keyboardState.IsKeyDown((Keys)Char.ToUpper(UpKey)))
            {
                PlayerPaddle.Position = PlayerPaddle.MovePaddleUp(PlayerPaddle);
                if (hockeyMode)
                {
                    PlayerSecondPaddle.Position = PlayerSecondPaddle.MovePaddleDown(PlayerSecondPaddle);
                }
            }
            else if (keyboardState.IsKeyDown((Keys)Char.ToUpper(LeftKey)))
            {
                PlayerSecondPaddle.Position = PlayerSecondPaddle.MovePaddleLeft(PlayerSecondPaddle);
            }
            else if (keyboardState.IsKeyDown((Keys)Char.ToUpper(RightKey)))
            {
                PlayerSecondPaddle.Position = PlayerSecondPaddle.MovePaddleRight(PlayerSecondPaddle);
            }
        }
    }
}
