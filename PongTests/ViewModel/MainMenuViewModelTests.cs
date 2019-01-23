using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using Pong;
using Pong.ViewModels;
using Pong.Screens.Controls;
using Pong.Helpers;

namespace PongTests.ViewModel
{
    public class MainMenuViewModelTests
    {
        [Fact]
        public void MainMenuReturnsGameTitleTrue()
        {
            // Arrange.
            const string title = "David's Magic Games!";
            var model = new MainMenuViewModel();

            // Act.

            // Assert.
            Assert.Equal(model.GetGameTitle(), title);
        }

        [Fact]
        public void MainMenuReturnsGamesTitleFalse()
        {
            // Arrange.
            const string title = "Garbage Title!";
            var model = new MainMenuViewModel();

            // Act.

            // Assert.
            Assert.NotEqual(model.GetGameTitle(), title);
        }

        [Fact]
        public void MainMenuGetGameMenuEntriesReturnsCorrectList()
        {
            // Arrange.
            List<MenuEntry> entries = new List<MenuEntry>()
            {
                new MenuEntry(Constants.PlayTitle, true),
                new MenuEntry(Constants.OptionsTitle, true),
                new MenuEntry(Constants.PlayerTitles, true),
                new MenuEntry(Constants.ExitTitles, true)
            };
            var model = new MainMenuViewModel();

            // Act.
            model.CreateListOfEntries();
            var results = model.GetGameMenuEntries();

            // Assert.
            Assert.ReferenceEquals(results, entries);
        }

        [Fact]
        public void MainMenuGetGameEntriesReturnsWrongList()
        {
            // Arrange.
            var mockList = new Mock<List<MenuEntry>>();
            var model = new MainMenuViewModel();

            // Act.
            model.CreateListOfEntries();
            var results = model.GetGameMenuEntries();

            // Assert.
            Assert.NotSame(results, mockList.Object);
        }

        [Fact]
        public void MainMenuGetListOFEntriesReturnsCorrectList()
        {
            // Arrange.
            var list = new List<string>
            {
                Constants.PlayTitle,
                Constants.OptionsTitle,
                Constants.PlayerTitles,
                Constants.ExitTitles
            };
            var model = new MainMenuViewModel();

            // Act.

            // Assert.
            Assert.ReferenceEquals(model.ListOfMenuEntries(), list);
        }

        [Fact]
        public void MainMenuListOfEntriesReturnsWrongList()
        {
            // Arrange.
            var list = new List<string>
            {
                "One",
                "Two",
                "Three",
                "Four"
            };
            var model = new MainMenuViewModel();

            // Act.

            // Assert.
            Assert.NotSame(model.ListOfMenuEntries(), list);
        }

        [Fact]
        public void MainMenuGetOptionsReturnsCorrect()
        {
            // Arrange.
            OptionsSelected options = new OptionsSelected
            {
                AmountOfPlayers = "1",
                FirstTo = "3",
                GameModeType = "Pong",
                PlayerName = "Fred",
                UpKey = 'q',
                DownKey = 'a',
                LeftKey = 'z',
                RightKey = 'x'
            };
            var model = new MainMenuViewModel();
 
            // Act.

            // Assert.
            Assert.ReferenceEquals(model.GetOptions(), options);
        }

        [Fact]
        public void MainMenuGetOptionsReturnsWrong()
        {
            // Arrange.
            var mockOptions = new Mock<OptionsSelected>();
            var model = new MainMenuViewModel();

            // Act.

            // Assert.
            Assert.NotSame(model.GetOptions(), mockOptions.Object);
        }
    }
}
