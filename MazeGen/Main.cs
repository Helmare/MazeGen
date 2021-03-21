using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MazeGen
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            btnStep.Text = "\u25b6";
            btnFinish.Text = "\u23ed";

            renderer.Maze = new Maze(10, 10);
        }
    }
}
