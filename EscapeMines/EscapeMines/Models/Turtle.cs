using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Models
{
    public enum Direction
    {
        N,
        E,
        S,
        W
    }

    public class Turtle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public Turtle(int x, int y, Direction direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public void Move(string move)
        {
            switch (move)
            {
                case "R":
                    RotateRight();
                    break;
                case "L":
                    RotateLeft();
                    break;
                case "M":
                    DoMove();
                    break;
                default:
                    Console.WriteLine("Problem with input");
                    break;
            }
        }

        public void DoMove()
        {
            switch (Direction)
            {
                case Direction.E:
                    Y++;
                    break;
                case Direction.N:
                    X--;
                    break;
                case Direction.W:
                    Y--;
                    break;
                case Direction.S:
                    X++;
                    break;
            }
        }

        private void RotateRight()
        {
            switch (Direction)
            {
                case Direction.E:
                    Direction = Direction.S;
                    break;
                case Direction.N:
                    Direction = Direction.E;
                    break;
                case Direction.W:
                    Direction = Direction.N;
                    break;
                case Direction.S:
                    Direction = Direction.W;
                    break;
            }            
        }

        private void RotateLeft()
        {
            switch (Direction)
            {
                case Direction.E:
                    Direction = Direction.N;
                    break;
                case Direction.N:
                    Direction = Direction.W;
                    break;
                case Direction.W:
                    Direction = Direction.S;
                    break;
                case Direction.S:
                    Direction = Direction.E;
                    break;
            }            
        }
    }
}
