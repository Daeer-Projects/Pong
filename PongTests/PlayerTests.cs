using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Pong;
using Pong.Players;

namespace PongTests
{
    public class PlayerTests
    {
        [Fact]
        public void TestPlayerReturnsCorrectName()
        {
            // Arrange.
            var player = new PlayerName("Norman");
            const string testName = "Norman";
            // Act.

            // Assert.
            Assert.Equal(testName, player.Name);
        }

        [Fact]
        public void TestPlayerDoesNotReturnCorrectName()
        {
            // Arrange.
            var player = new PlayerName("Fred");
            const string testName = "Norman";
            // Act.

            // Assert.
            Assert.NotEqual(testName, player.Name);
        }

        [Fact]
        public void TestPlayerThrowsErrorIfNumberUsed()
        {
            // Arrange.

            // Act.

            // Assert.
            Assert.Throws<FormatException>(() => new PlayerName("1234"));
        }

        [Fact]
        public void TestPlayerThrowsErrorIfSymbolsUsed()
        {
            // Arrange.

            // Act.

            // Assert.
            Assert.Throws<FormatException>(() => new PlayerName("!£$%%^%&"));
        }
    }
}
