using Pong.Graphics;

namespace Pong.Players
{
    public abstract class PlayerBase
    {
        public string PlayerName { get; set; }
        public int Difficulty { get; set; }
        public Paddle PlayerPaddle { get; set; }
        public Paddle PlayerSecondPaddle { get; set; }
        public int Score { get; set; }

        protected PlayerBase(string playerName, int difficulty, int score)
        {
            PlayerName = playerName;
            Difficulty = difficulty;
            Score = score;
        }

    }
}
