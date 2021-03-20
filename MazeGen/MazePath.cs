using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGen
{
    public class MazePath
    {
        public MazeCell Cell0 { get; }
        public MazeCell Cell1 { get; }
        public bool Blocked { get; set; } = true;

        public MazePath(MazeCell cell0, MazeCell cell1)
        {
            this.Cell0 = cell0;
            this.Cell1 = cell1;
        }
    }
}
