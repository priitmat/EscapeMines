using System.Collections.Generic;

namespace EscapeMines.Models
{
    public class GameSettings
    {
        public Board Board { get; }
        public List<Mine> Mines { get; }
        public Turtle Turtle { get; }
        public List<List<string>> MoveSequences { get; }

        public GameSettings(Board board, List<Mine> mines, Turtle turtle, List<List<string>> moveSequences)
        {
            Board = board;
            Mines = mines;
            Turtle = turtle;
            MoveSequences = moveSequences;
        }
    }
}
