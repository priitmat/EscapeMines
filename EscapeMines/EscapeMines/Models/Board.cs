namespace EscapeMines.Models
{
    public class Board
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public int ExitPointX { get; set; }
        public int ExitPointY { get; set; }

        public Board(int height, int width, int exitPointX, int exitPointY)
        {
            Height = height;
            Width = width;
            ExitPointX = exitPointX;
            ExitPointY = exitPointY;
        }        
    }
}
