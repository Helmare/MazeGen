using System.Collections.Generic;

namespace MazeGen
{
    /// <summary>
    ///     
    /// </summary>
    public class Maze
    {
        public int Width { get; }
        public int Height { get; }
        public MazeCell[,] Cells { get; }

        public Maze(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            // Create cells.
            this.Cells = new MazeCell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Cells[x, y] = new MazeCell(this, x, y);
                }
            }
        }

        /// <summary>
        ///     Calculates all vertical walls for the maze.
        /// </summary>
        /// <returns>
        ///     An array of int array's which represents walls where 
        ///     each value is the height of a cell. The index of an int 
        ///     array is the X value for the walls. The ints in the array 
        ///     are line segment positions along the vertical axis.
        /// </returns>
        public int[][] CalcVerticalWalls()
        {
            // Setup vertical walls
            int[][] walls = new int[Width + 1][];
            walls[0] = new int[] { 1, Height };
            walls[Width] = new int[] { 0, Height - 1 };

            // Calculate vertical walls for each cell.
            for (int x = 1; x < Width; x++)
            {
                List<int> lines = new List<int>();
                bool empty = true;
                for (int y = 0; y < Height; y++)
                {
                    if (empty && Cells[x, y].LeftWall || !empty && !Cells[x, y].LeftWall)
                    {
                        empty = !empty;
                        lines.Add(y);
                    }
                }
                if (!empty) lines.Add(Height);
                walls[x] = lines.ToArray();
            }

            return walls;
        }
        /// <summary>
        ///     Calculates all horizontal walls for the maze.
        /// </summary>
        /// <returns>
        ///     An array of int array's which represents walls where 
        ///     each value is the width of a cell. The index of an int 
        ///     array is the Y value for the walls. The ints in the array 
        ///     are line segment positions along the horizontal axis.
        /// </returns>
        public int[][] CalcHorizontalWalls()
        {
            // Setup horizontal walls
            int[][] walls = new int[Height + 1][];
            walls[0] = new int[] { 0, Height };
            walls[Height] = new int[] { 0, Width };

            // Calculate horizontal walls for each cell.
            for (int y = 1; y < Height; y++)
            {
                List<int> lines = new List<int>();
                bool empty = true;
                for (int x = 0; x < Width; x++)
                {
                    if (empty && Cells[x, y].TopWall || !empty && !Cells[x, y].TopWall)
                    {
                        empty = !empty;
                        lines.Add(x);
                    }
                }
                if (!empty) lines.Add(Height);
                walls[y] = lines.ToArray();
            }

            return walls;
        }
    }
}
