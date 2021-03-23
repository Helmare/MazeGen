using System;
using System.Collections.Generic;

namespace MazeGen
{
    /// <summary>
    ///     A simple 
    /// </summary>
    public class MazeCell
    {
        public Maze Maze { get; }
        public int X { get; }
        public int Y { get; }

        public MazeCellFlag Flags { get; set; } = MazeCellFlag.Unvisited;

        public bool TopWall { get; set; } = true;
        public bool LeftWall { get; set; } = true;

        public MazeCell(Maze maze, int x, int y)
        {
            this.Maze = maze;
            this.X = x;
            this.Y = y;
        }

        public Direction[] MovementOptions 
        {
            get
            {
                List<Direction> options = new List<Direction>();
                if (Right != null && !Right.LeftWall) options.Add(Direction.Right);
                if (Top != null && !TopWall) options.Add(Direction.Top);
                if (Left != null && !LeftWall) options.Add(Direction.Left);
                if (Bottom != null && !Bottom.TopWall) options.Add(Direction.Bottom);

                return options.ToArray();
            }
        }

        public MazeCell Left => (X == 0) ? null : Maze.Cells[X - 1, Y];
        public MazeCell Top => (Y == 0) ? null : Maze.Cells[X, Y - 1];
        public MazeCell Right => (X == Maze.Width - 1) ? null : Maze.Cells[X + 1, Y];
        public MazeCell Bottom => (Y == Maze.Height - 1) ? null : Maze.Cells[X, Y + 1];
    }
    
    [Flags]
    public enum MazeCellFlag
    {
        Unvisited = 0, Visited = 1, Solution = 2,
        All = Visited | Solution
    }
    public enum Direction
    {
        Right = 0, Top = 1, Left = 2, Bottom = 3
    }
}
