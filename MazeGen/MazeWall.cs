namespace MazeGen
{
    /// <summary>
    ///     
    /// </summary>
    public class MazeWall
    {
        /// <summary>
        ///     Gets the position on the minor axis.
        /// </summary>
        public int Position { get; }
        
        /// <summary>
        ///     Gets the start position on the major axis.
        /// </summary>
        public int Start { get; }
        /// <summary>
        ///     Gets the end position on the major axis.
        /// </summary>
        public int End { get; }
        /// <summary>
        ///     Gets the length of the wall along the major axis.
        /// </summary>
        public int Length => End - Start;

        //
        // LINE RENDERING VALUES
        //
        public int X1 =>  Vertical ? Position : Start;
        public int X2 =>  Vertical ? Position : End;
        public int Y1 => !Vertical ? Position : Start;
        public int Y2 => !Vertical ? Position : End;

        //
        // RECTANGLE RENDERING VALUES
        //
        public float CenterX => (X1 + X2) / 2f;
        public float CenterY => (Y1 + Y2) / 2f;
        public int Width =>  Vertical ? -1 : Length;
        public int Height => Vertical ? Length : -1;

        /// <summary>
        ///     Gets whether the wall is vertical.
        /// </summary>
        public bool Vertical { get; }
        /// <summary>
        ///     Gets whether the wall is horizontal
        /// </summary>
        public bool Horizontal
        {
            get => !Vertical;
        }

        public MazeWall(bool vertical, int position, int start, int end) 
            => (Vertical, Position, Start, End) = (vertical, position, start, end);

        /// <summary>
        ///     Shorthand method for creating vertical walls.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y1"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        public static MazeWall Vert(int x, int y1, int y2)
        {
            return new MazeWall(true, x, y1, y2);
        }
        /// <summary>
        ///     Shorthand method for creating horizontal walls.
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x1"></param>
        /// <param name="x2"></param>
        /// <returns></returns>
        public static MazeWall Horz(int y, int x1, int x2)
        {
            return new MazeWall(false, y, x1, x2);
        }
    }
}
