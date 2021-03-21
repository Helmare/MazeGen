using System.Drawing;
using System.Windows.Forms;

namespace MazeGen
{
    public partial class MazeRenderer : UserControl
    {
        public Maze Maze { get; set; }

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

            // Render cells.
            for (int x = 0; x < Maze.Width; x++)
            {
                for (int y = 0; y < Maze.Height; y++)
                {
                    MazeCell cell = Maze.Cells[x, y];
                    float xx = x * k + xOff, yy = y * k + yOff;
                    if (cell.Flags.HasFlag(MazeCellFlag.EndPoint))
                    {
                        g.FillRectangle(Brushes.Blue, xx, yy, k, k);
                    }
                    else if (!cell.Flags.HasFlag(MazeCellFlag.Visited))
                    {
                        g.FillRectangle(Brushes.White, xx, yy, k, k);
                    }

                    if (y > 0 && cell.TopWall) g.DrawLine(Pens.White, xx, yy, xx + k, yy);
                    if (x > 0 && cell.LeftWall) g.DrawLine(Pens.White, xx, yy, xx, yy + k);
                }
            }
        }
    }
}
