using EscapeMines.Services;
using System;

namespace EscapeMines
{
    class Program
    {
        static void Main(string[] args)
        {
            var gameSettingsService = new GameSettingsService(new SettingsReaderService());
            var gameLogicService = new GameLogicService(gameSettingsService);
            foreach (var result in gameLogicService.Run())
            {
                Console.WriteLine(result);
            }            
        }
    }
}
