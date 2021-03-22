using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace MazeGen
{
    public partial class MazeRenderer : UserControl
    {
        public Maze Maze { get; set; }
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
            if (Maze == null) return;

            Graphics g = e.Graphics;
            g.Clear(BackColor);

            // Find scale and offset.
            float xOff = 0, yOff = 0, k;
            bool verticalOuterWall = true;
            if (Width >= Maze.Width * (Height / (float) Maze.Height))
            {
                k = Height / (float) Maze.Height;
                xOff = (Width - Maze.Width * k) / 2;
            }
            else
            {
                k = Width / (float) Maze.Width;
                yOff = (Height - Maze.Height * k) / 2;
                verticalOuterWall = false;
            }

            // Setup rendering tools.
            using Brush unvisitedBrush = new SolidBrush(ForeColor);
            using Brush intersectionBrush = new SolidBrush(IntersectionColor);
            using Brush endpointBrush = new SolidBrush(EndpointColor);
            using Brush solutionBrush = new SolidBrush(SolutionColor);
            using Pen wallPen = new Pen(ForeColor);

            // Render cells.
            for (int x = 0; x < Maze.Width; x++)
            {
                for (int y = 0; y < Maze.Height; y++)
                {
                    MazeCell cell = Maze.Cells[x, y];
                    Direction[] options = cell.MovementOptions;

                    float xx = x * k + xOff, yy = y * k + yOff;
                    if (cell.Flags.HasFlag(MazeCellFlag.Solution))
                    {
                        g.FillRectangle(solutionBrush, xx, yy, k, k);
                    }
                    else if (options.Length == 1)
                    {
                        g.FillRectangle(endpointBrush, xx, yy, k, k);
                    }
                    else if (options.Length > 2)
                    {
                        g.FillRectangle(intersectionBrush, xx, yy, k, k);
                    }
                    else if (!cell.Flags.HasFlag(MazeCellFlag.Visited))
                    {
                        g.FillRectangle(unvisitedBrush, xx, yy, k, k);
                    }

                    if (y > 0 && cell.TopWall) g.DrawLine(wallPen, xx, yy, xx + k, yy);
                    if (x > 0 && cell.LeftWall) g.DrawLine(wallPen, xx, yy, xx, yy + k);
                }
            }

            // Render outerwall.
            if (verticalOuterWall)
            {
                g.DrawLine(wallPen, xOff, k, xOff, Height);
                g.DrawLine(wallPen, xOff + Maze.Width * k, 0, xOff + Maze.Width * k, Height - k);
            }
            else
            {
                g.DrawLine(wallPen, k, yOff, Width, yOff);
                g.DrawLine(wallPen, 0, yOff + Maze.Height * k, Width - k, yOff + Maze.Height * k);
            }
        }

        private void MazeRenderer_SizeChanged(object sender, System.EventArgs e)
        {
            Refresh();
        }
    }
}
