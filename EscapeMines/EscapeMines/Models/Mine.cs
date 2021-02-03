using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeMines.Models
{
    public class Mine
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Mine(int x, int y)
        {
            X = x;
            Y = y;
        }        
    }
}
