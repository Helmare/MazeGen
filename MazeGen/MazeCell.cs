using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    /// <summary>
    ///     A simple 
    /// </summary>
    public class MazeCell
    {
        public int X { get; }
        public int Y { get; }

        public bool Visited { get; set; }
        public bool Solution { get; set; }
        public bool Endpoint { get; set; }

        public MazeCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}
