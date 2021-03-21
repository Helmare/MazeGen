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

        public MazeCellFlag Flags { get; set; } = MazeCellFlag.Unvisited;

        public bool TopWall { get; set; } = true;
        public bool LeftWall { get; set; } = true;

        public MazeCell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    
    [Flags]
    public enum MazeCellFlag
    {
        Unvisited = 0, Visited = 1, Solution = 2, EndPoint = 4,
        All =  Visited | Solution | EndPoint
    }
}
