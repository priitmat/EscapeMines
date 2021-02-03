using Microsoft.VisualStudio.TestTools.UnitTesting;
using EscapeMines.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;

namespace EscapeMines.Services.Tests
{
    [TestClass()]
    public class GameLogicServiceTests
    {
        [TestMethod()]
        public void Run_ShouldReturnCorrectOutcomes()
        {
            //Arrange
            var listOfLines = new List<string>()
            {
                "5 4",
                "1,1 1,3 3,3",
                "4 2",
                "1 0 N",
                "M R M M R M M M M",
                "M R R M R M M M M",                
                "L L L M R M M M M",
                "L L",
            };
            var _settingsReaderServiceMock = new Mock<ISettingsReaderService>();
            _settingsReaderServiceMock.Setup(x => x.GetAllLines()).Returns(listOfLines);
            var gameSettingsService = new GameSettingsService(_settingsReaderServiceMock.Object);
            var gameLogicService = new GameLogicService(gameSettingsService);
            
            //Act
            var actual = gameLogicService.Run();

            //Assert
            _settingsReaderServiceMock.Verify(x => x.GetAllLines(), Times.Once);

            Assert.AreEqual(Constants.Success, actual[0]);
            Assert.AreEqual(Constants.OutOfBounds, actual[1]);
            Assert.AreEqual(Constants.MineHit, actual[2]);
            Assert.AreEqual(Constants.StillInDanger, actual[3]);
        }

        [TestMethod()]
        public void Run_ShouldReturnProblemWithInput()
        {
            //Arrange
            var listOfLines = new List<string>()
            {
                "5 4",
                "1 ,1 1,3 3,3",
                "4 2",
                "1 0 N",
                "M R M M R M M M M",
                "M R R M R M M M M",
                "L L L M R M M M M",
                "L L",
            };
            var _settingsReaderServiceMock = new Mock<ISettingsReaderService>();
            _settingsReaderServiceMock.Setup(x => x.GetAllLines()).Returns(listOfLines);
            var gameSettingsService = new GameSettingsService(_settingsReaderServiceMock.Object);
            var gameLogicService = new GameLogicService(gameSettingsService);

            //Act
            var actual = gameLogicService.Run();

            //Assert
            _settingsReaderServiceMock.Verify(x => x.GetAllLines(), Times.Once);
            Assert.AreEqual(Constants.ProblemWithInput, actual[0]);
        }
    }
}