using EscapeMines.Models;
using System;
using System.Collections.Generic;

namespace EscapeMines.Services
{
    public class GameLogicService : IGameLogicService
    {
        IGameSettingsService _gameSettingsService;
        GameSettings _gameSettings;

        public GameLogicService(IGameSettingsService gameSettingsService)
        {
            _gameSettingsService = gameSettingsService;
        }

        public List<string> Run()
        {
            var result = new List<string>();

            try
            {
                _gameSettings = _gameSettingsService.GetGameSettings();
                foreach (var moveSequence in _gameSettings.MoveSequences)
                {
                    result.Add(DoMoveSequence(moveSequence));
                }
            }
            catch (Exception ex)
            {
                result.Add(ex.Message);
            }
            
            return result;
        }

        private string DoMoveSequence(List<string> moveSequnece)
        {   
            var turtle = new Turtle(_gameSettings.Turtle.X, _gameSettings.Turtle.Y, _gameSettings.Turtle.Direction);
            foreach (var move in moveSequnece)
            {               
                turtle.Move(move);
                if (CheckIfOutOfBounds(turtle.X, turtle.Y))
                    return Constants.OutOfBounds;
                if (CheckIfMineHit(turtle.X, turtle.Y))
                    return Constants.MineHit;
                if (CheckIfAtExit(turtle.X, turtle.Y))
                    return Constants.Success;
            }
            return Constants.StillInDanger;
        }

        private bool CheckIfOutOfBounds(int x, int y)
        {
            if (x > _gameSettings.Board.Width
                   || y > _gameSettings.Board.Height
                   || x < 0
                   || y < 0)
            {
                return true;
            }
            return false;
        }

        private bool CheckIfMineHit(int x, int y)
        {
            foreach (var mine in _gameSettings.Mines)
            {
                if (mine.X == x && mine.Y == y)
                    return true;          
            }
            return false;
        }

        private bool CheckIfAtExit(int x, int y)
        {
            if (_gameSettings.Board.ExitPointX == x &&
                _gameSettings.Board.ExitPointY == y)
            {
                return true;
            }
            return false;
        }
    }
}
