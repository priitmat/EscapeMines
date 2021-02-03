using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using EscapeMines.Models;
using FluentAssertions;
using Moq;

namespace EscapeMines.Services.Tests
{
    [TestClass()]
    public class GameSettingsServiceTests
    {   
        [TestMethod()]
        public void GetGameSettings_ShouldReturnCorrectGameSettings()
        {
            //Arrange
            var listOfLines = new List<string>()
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "1 0 N",
                "M R M M R M M M M",
                "M R R M R M M M M"
            };

            var expectedboard = new Board(5, 4, 4, 2);
            var expectedMines = new List<Mine>
            {
                new Mine(x: 1, y:1) ,
                new Mine(x: 1, y:3) ,
                new Mine(x: 3, y:3)
            };
            var expectedTurtle = new Turtle(1, 0, Direction.N);
            var expectedMoveSequences = new List<List<string>>
            {
                new List<string> { "M", "R", "M", "M", "R", "M", "M", "M", "M" },
                new List<string> { "M", "R", "R", "M", "R", "M", "M", "M", "M" }
            };

            var expectedGameSettings = new GameSettings(expectedboard, expectedMines, expectedTurtle, expectedMoveSequences);

            var _settingsReaderServiceMock = new Mock<ISettingsReaderService>();
            _settingsReaderServiceMock.Setup(x => x.GetAllLines()).Returns(listOfLines);

            var gameSettingsService = new GameSettingsService(_settingsReaderServiceMock.Object);

            //Act
            var actualGameSettings = gameSettingsService.GetGameSettings();

            //Assert
            _settingsReaderServiceMock.Verify(x => x.GetAllLines(), Times.Once);
            expectedGameSettings.Should().BeEquivalentTo(actualGameSettings);
        }
    }
}