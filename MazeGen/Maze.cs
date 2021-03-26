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
        ///     Calculates the optimal maze walls.
        /// </summary>
        /// <returns></returns>
        public MazeWall[] CalcWalls()
        {
            List<MazeWall> walls = new List<MazeWall>();
            walls.AddRange(CalcVerticalWalls());
            walls.AddRange(CalcHorizontalWalls());
            return walls.ToArray();
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
        public MazeWall[] CalcVerticalWalls()
        {
            // Setup vertical walls
            List<MazeWall> walls = new List<MazeWall>();
            walls.Add(MazeWall.Vert(0, 1, Height));
            walls.Add(MazeWall.Vert(Width, 0, Height - 1));

            // Calculate vertical walls for each cell.
            for (int x = 1; x < Width; x++)
            {
                int start = -1;
                for (int y = 0; y < Height; y++)
                {
                    if (start < 0 && Cells[x, y].LeftWall)
                    {
                        start = y;
                    }
                    else if (start >= 0 && !Cells[x, y].LeftWall)
                    {
                        walls.Add(MazeWall.Vert(x, start, y));
                        start = -1;
                    }
                }
                if (start >= 0) walls.Add(MazeWall.Vert(x, start, Height));
            }
            return walls.ToArray();
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
        public MazeWall[] CalcHorizontalWalls()
        {
            // Setup horizontal walls
            List<MazeWall> walls = new List<MazeWall>();
            walls.Add(MazeWall.Horz(0, 0, Width));
            walls.Add(MazeWall.Horz(Height, 0, Width));

            // Calculate horizontal walls for each cell.
            for (int y = 1; y < Height; y++)
            {
                int start = -1;
                for (int x = 0; x < Width; x++)
                {
                    if (start < 0 && Cells[x, y].TopWall)
                    {
                        start = x;
                    }
                    else if (start >= 0 && !Cells[x, y].TopWall)
                    {
                        walls.Add(MazeWall.Horz(y, start, x));
                        start = -1;
                    }
                }
                if (start >= 0) walls.Add(MazeWall.Horz(y, start, Width));
            }
            return walls.ToArray();
        }
    }
}
