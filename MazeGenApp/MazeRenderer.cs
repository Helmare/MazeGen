﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace MazeGen.App
{
    public partial class MazeRenderer : UserControl
    {
        public MazeBuilder MazeBuilder { get; set; }
        public Maze Maze => MazeBuilder.Maze;

        /// <summary>
        ///     Gets or sets the color for the current MazeCell.
        /// </summary>
        public Color CurrentCellColor { get; set; } = Color.Magenta;
        /// <summary>
        ///     Gets or sets the color for MazeCells with the intersection flag.
        /// </summary>
        public Color IntersectionColor { get; set; } = Color.Lime;
        /// <summary>
        ///     Gets or sets the color for MazeCells with the endpoint flag.
        /// </summary>
        public Color EndpointColor { get; set; } = Color.Blue;
        /// <summary>
        ///     Gets or sets the color for MazeCells with the solution flag.
        /// </summary>
        public Color SolutionColor { get; set; } = Color.DarkRed;

        public MazeRenderer()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);
            if (MazeBuilder == null) return;

            // Find scale and offset.
            float xOff = 0, yOff = 0, k;
            if (Width >= Maze.Width * (Height / (float) Maze.Height))
            {
                k = Height / (float) Maze.Height;
                xOff = (Width - Maze.Width * k) / 2;
            }
            else
            {
                k = Width / (float) Maze.Width;
                yOff = (Height - Maze.Height * k) / 2;
            }

            // Setup rendering tools.
            using Brush intersectionBrush = new SolidBrush(IntersectionColor);
            using Brush endpointBrush = new SolidBrush(EndpointColor);
            using Brush solutionBrush = new SolidBrush(SolutionColor);
            using Brush currentCellBrush = new SolidBrush(CurrentCellColor);
            using Pen wallPen = new Pen(ForeColor);

            // Render cells.
            for (int x = 0; x < Maze.Width; x++)
            {
                for (int y = 0; y < Maze.Height; y++)
                {
                    MazeCell cell = Maze.Cells[x, y];
                    Direction[] options = cell.MovementOptions;

                    float xx = x * k + xOff, yy = y * k + yOff;

                    // Decide brush.
                    Brush brush = null;
                    if (!MazeBuilder.IsFinished && cell.X == MazeBuilder.Current.X && cell.Y == MazeBuilder.Current.Y)
                    {
                        brush = currentCellBrush;
                    }
                    else if (cell.Flags.HasFlag(MazeCellFlag.Solution))
                    {
                        brush = solutionBrush;
                    }
                    else if (options.Length == 1)
                    {
                        brush = endpointBrush;
                    }
                    else if (options.Length > 2)
                    {
                        brush = intersectionBrush;
                    }

                    // Fill cell.
                    if (brush != null)
                    {
                        g.FillRectangle(brush, xx, yy, k, k);
                    }
                }
            }

            // Render Walls
            MazeWall[] walls = Maze.CalcWalls();
            Debug.WriteLine(walls.Length);
            foreach (MazeWall wall in walls)
            {
                g.DrawLine(wallPen, wall.X1 * k + xOff, wall.Y1 * k + yOff, wall.X2 * k + xOff, wall.Y2 * k + yOff);
            }
        }
        private void MazeRenderer_SizeChanged(object sender, System.EventArgs e)
        {
            Refresh();
        }
    }
}
