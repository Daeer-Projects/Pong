using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Microsoft.Xna.Framework;
using Pong.Helpers;

namespace PongTests
{
    public class AngleCalculatorTests
    {
        [Fact]
        public void AngleToVectorReturnsCorrectVector()
        {
            // Arrange.
            const float radAngle = 58.0f;
            const float xCoord = 0.9928726480845371181650881644254f;
            const float yCoord = -0.11918013544881928543584361076696f;
            Vector2 result = new Vector2(xCoord, yCoord);

            // Act.
            Vector2 test = AngleCalculator.RadianAngleToVector(radAngle);

            // Assert.
            Assert.Equal(result, test);
        }

        [Fact]
        public void AngleToVectorWithNegtiveAngle()
        {
            // Arrange.
            const float radAngle = -179.0f;
            const float xCoord = -0.07072216723899124390583425402211f;
            const float ycoord = 0.99749605265435519597856522546801f;
            Vector2 result = new Vector2(xCoord, ycoord);

            // Act.
            Vector2 test = AngleCalculator.RadianAngleToVector(radAngle);

            // Assert.
            Assert.Equal(result, test);
        }

        [Fact]
        public void VectorToRadianReturnsCorrectRadianAngle()
        {
            // Arrange.
            var vector = new Vector2(0.987632335f, 0.23223232f);
            float test = 1.80174136f;

            // Act.
            var result = AngleCalculator.VectorToRadianAngle(vector);

            // Assert.
            Assert.Equal(test, result);
        }

        [Fact]
        public void VectorToRadianWithNegativesInVector()
        {
            // Arrange.
            var vector = new Vector2(-0.987632335f, -0.23223232f);
            float test = -1.33985126f;

            // Act.
            var result = AngleCalculator.VectorToRadianAngle(vector);

            // Assert.
            Assert.Equal(test, result);
        }

        [Fact]
        public void RadianToDegreesReturnsCorrectAngle()
        {
            // Arrange.
            float test = 244.41749314635046653804719080941f;

            // Act.
            var result = AngleCalculator.RadianToDegrees(4.26589f);

            // Assert.
            Assert.Equal(test, result);
        }

        [Fact]
        public void RadianToDegreesWithNegativeValues()
        {
            // Arrange.
            float test = -204.42503900052096187581798677814f;

            // Act.
            var result = AngleCalculator.RadianToDegrees(-3.56789f);

            // Assert.
            Assert.Equal(test, result);
        }

        [Fact]
        public void DegreesToRadianReturnsCorrectAngle()
        {
            // Arrange.
            float test = 6997.1519700365991116002897447573f;

            // Act.
            var result = AngleCalculator.DegreesToRadian(122.12334f);

            // Assert.
            Assert.Equal(test, result);
        }

        [Fact]
        public void DegreesToRadiansWithNegativeValues()
        {
            // Arrange.
            float test = -3718.4960946480442014021136699565f;

            // Act.
            var result = AngleCalculator.DegreesToRadian(-64.9f);

            // Assert.
            Assert.Equal(test, result);
        }
    }
}
