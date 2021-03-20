using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    /// <summary>
    ///     
    /// </summary>
    public class Maze
    {
        public MazeCell[][] Cells { get; }
        public MazePath[] Paths { get; }

        public Maze(int width, int height)
        {
            // Create cells.
            Cells = new MazeCell[width][];
            for (int x = 0; x < width; x++)
            {
                MazeCell[] column = new MazeCell[height];
                for (int y = 0; y < height; y++)
                {
                    column[x] = new MazeCell(x, y);
                }
                Cells[x] = column;
            }

            // Create paths.
            List<MazePath> paths = new();
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    // Connect to right cell.
                    if (x < width - 1)
                    {
                        paths.Add(new MazePath(Cells[x][y], Cells[x + 1][y]));
                    }
                    // Connect to lower cell.
                    if (y < height - 1)
                    {
                        paths.Add(new MazePath(Cells[x][y], Cells[x][y + 1]));
                    }
                }
            }
        }
    }
}
