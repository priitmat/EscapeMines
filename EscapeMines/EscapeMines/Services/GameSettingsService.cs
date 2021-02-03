using EscapeMines.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EscapeMines.Services
{
    public class GameSettingsService : IGameSettingsService
    {
        private List<string> _gameSettings { get; set; }
        private ISettingsReaderService _settingsReaderService;
        public GameSettingsService(ISettingsReaderService settingsReaderService)
        {
           _settingsReaderService = settingsReaderService;
           _gameSettings = ReadGameSettings();
        }

        public GameSettings GetGameSettings()
        {                       
            try
            {
                var gameSettings = new GameSettings(GetBoard(), GetMines(), GetTurtle(), GetMoveSequences());
                return gameSettings;
            }
            catch (Exception)
            {
                throw new Exception(Constants.ProblemWithInput);
            }
        }

        private List<string> ReadGameSettings()
        {            
           return _settingsReaderService.GetAllLines();           
        }

        private List<Mine> GetMines()
        {            
            var mineLine = _gameSettings[1].Split(" ");
            var mines = new List<Mine>();
            foreach (var mine in mineLine)
            {
                var tempMine = mine.Split(",");
                Mine newMine = new Mine(int.Parse(tempMine[0]), int.Parse(tempMine[1]));
                mines.Add(newMine);
            }
            return mines;
        }

        private Turtle GetTurtle()
        {
            var turtle = _gameSettings[3].Split(" ");
            return new Turtle(int.Parse(turtle[0]),
                   int.Parse(turtle[1]),
                   (Direction)Enum.Parse(typeof(Direction), turtle[2]));
        }

        private Board GetBoard()
        {
            var size = _gameSettings[0].Split(" ");
            var exitPoint = _gameSettings[2].Split(" ");

            var board = new Board(
                int.Parse(size[0]),
                int.Parse(size[1]),
                int.Parse(exitPoint[0]),
                int.Parse(exitPoint[1]));

            return board;
        }

        private List<List<string>> GetMoveSequences()
        {
            var line = 4;
            var moveSequences = new List<List<string>>();
            while (true)
            {
                try
                {
                    moveSequences.Add(_gameSettings[line].Split(" ").ToList());
                    line++;
                }
                catch (Exception)
                {
                    break;
                }
            }
            return moveSequences;
        }
    }
}
