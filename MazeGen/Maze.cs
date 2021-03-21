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
        public MazeCell[][] Cells { get; }

        public Maze(int width, int height)
        {
            this.Width = width;
            this.Height = height;

            // Create cells.
            this.Cells = new MazeCell[width][];
            for (int x = 0; x < width; x++)
            {
                MazeCell[] column = new MazeCell[height];
                for (int y = 0; y < height; y++)
                {
                    column[x] = new MazeCell(x, y);
                }
                Cells[x] = column;
            }
        }
    }
}
