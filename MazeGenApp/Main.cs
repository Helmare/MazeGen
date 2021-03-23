using System;
using System.Windows.Forms;

namespace MazeGen.App
{
    public partial class Main : Form
    {
        public MazeBuilder MazeBuilder { get; } = new MazeBuilder(25, 25);
        public Main()
        {
            InitializeComponent();
            btnStep.Text = "\u25b6";
            btnFinish.Text = "\u23ed";
            renderer.MazeBuilder = MazeBuilder;
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
