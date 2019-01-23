using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Pong.GameActions;

namespace PongTests
{
    public class ScoringTests
    {
        [Fact]
        public void ScoringIncrementsCorrectlyByOne()
        {
            // Arrange.
            const int testValue = 1;
            Scoring score = new Scoring(5);

            // Act.
            score.IncrementScore();

            // Assert.
            Assert.Equal(testValue, score.CurrentScore);
        }

        [Fact]
        public void ScoringDecrementsCorrectlyByOne()
        {
            // Arrange.
            const int testValue = 2;
            Scoring score = new Scoring(5);

            // Act.
            score.IncrementScore();
            score.IncrementScore();
            score.IncrementScore();
            score.DecrementScore();

            // Assert.
            Assert.Equal(testValue, score.CurrentScore);
        }

        [Fact]
        public void ScoringStopsAtMaxScore()
        {
            // Arrange.
            Scoring score = new Scoring(2);

            // Act.
            score.IncrementScore();
            score.IncrementScore();

            // Assert.
            Assert.Throws<ApplicationException>(() => score.IncrementScore());
        }

        [Fact]
        public void ScoringCantGoBelowZero()
        {
            // Arrange.
            Scoring score = new Scoring(2);

            // Act.
            score.DecrementScore();

            // Assert.
            Assert.Equal(0, score.CurrentScore);
        }
    }
}
