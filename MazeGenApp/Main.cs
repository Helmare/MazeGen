using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGen.App
{
    public partial class Main : Form
    {
        public MazeBuilder MazeBuilder { get; } = new MazeBuilder(20, 4);
        public Main()
        {
            InitializeComponent();
            btnStep.Text = "\u25b6";
            btnFinish.Text = "\u23ed";
            renderer.Maze = MazeBuilder.Maze;
        }

        private void btnStep_Click(object sender, EventArgs e)
        {
            MazeBuilder.Step();
            renderer.Refresh();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            MazeBuilder.Finish();
            renderer.Refresh();
        }
    }
}
