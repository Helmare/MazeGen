using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
                    Cells[x, y] = new MazeCell(x, y);
                }
            }
        }
    }
}
