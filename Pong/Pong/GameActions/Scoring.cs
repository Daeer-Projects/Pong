using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong.GameActions
{
    public class Scoring
    {
        public int CurrentScore { get; private set; }
        public int MaxScore { get; private set; }

        public Scoring(int maxScore)
        {
            CurrentScore = 0;
            MaxScore = maxScore;
        }

        public void IncrementScore()
        {
            if (CurrentScore < MaxScore)
            {
                CurrentScore++;
            }
            else
            {
                throw new ApplicationException(String.Format("Max score reached: {0}.", CurrentScore));
            }
        }

        public void DecrementScore()
        {
            if (CurrentScore > 0)
            {
                CurrentScore--;
            }
        }
    }
}
