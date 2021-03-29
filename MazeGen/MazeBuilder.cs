using System;
using System.Collections.Generic;
using System.Linq;

namespace MazeGen
{
    public class MazeBuilder
    {
        /// <summary>
        ///     Gets the Maze which is being created.
        /// </summary>
        public Maze Maze { get; }
        /// <summary>
        ///     Gets the current cell.
        /// </summary>
        public MazeCell Current => (Stack.Count > 0) ? Stack.Peek() : null;
        /// <summary>
        ///     Gets whether the maze has finished building.
        /// </summary>
        public bool IsFinished => Stack.Count == 0;

        private Random Random { get; } = new Random();
        private Stack<MazeCell> Stack { get; } = new Stack<MazeCell>();

        public MazeBuilder(int width, int height)
        {
            Maze = new Maze(width, height);

            Maze.Cells[0, 0].Flags = MazeCellFlag.Visited;
            Stack.Push(Maze.Cells[0, 0]);
        }

        /// <summary>
        ///     Takes a single step in the maze building process.
        /// </summary>
        public void Step()
        {
            // Grab current cell.
            MazeCell cell = Current;
            if (cell == null) return;

            // Determain a random neighbor.
            int dir = RandomUnvisitedNeighbor(cell, out MazeCell next);
            if (dir < 0)
            {
                Stack.Pop();
            }
            else
            {
                if (dir == 0) next.LeftWall = false;
                else if (dir == 1) cell.TopWall = false;
                else if (dir == 2) cell.LeftWall = false;
                else if (dir == 3) next.TopWall = false;

                next.Flags = MazeCellFlag.Visited;
                Stack.Push(next);
            }
        }
        private int RandomUnvisitedNeighbor(MazeCell cell, out MazeCell next)
        {
            // Find unvisited neighbors.
            Dictionary<int, MazeCell> neighbors = new Dictionary<int, MazeCell>();
            for (int i = 0; i < 4; i++)
            {
                MazeCell n = null;
                switch (i)
                {
                    case 0:
                        n = cell.Right;
                        break;

                    case 1:
                        n = cell.Top;
                        break;

                    case 2:
                        n = cell.Left;
                        break;

                    case 3:
                        n = cell.Bottom;
                        break;
                }
                if (n != null && n.Flags == 0) neighbors.Add(i, n);
            }

            // Random neighbor.
            if (neighbors.Count == 0)
            {
                next = null;
                return -1;
            }
            else
            {
                int r = Random.Next(neighbors.Count);
                KeyValuePair<int, MazeCell> rand = neighbors.ToList()[r];
                next = rand.Value;
                return rand.Key;
            }
        }

        /// <summary>
        ///     Finishes the maze (steps until finished).
        /// </summary>
        /// <returns>The finished maze.</returns>
        public Maze Finish()
        {
            while (!IsFinished)
            {
                Step();
            }
            return Maze;
        }
    }
}
