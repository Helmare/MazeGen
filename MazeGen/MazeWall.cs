namespace MazeGen
{
    /// <summary>
    ///     
    /// </summary>
    public record MazeWall
    {
        /// <summary>
        ///     Gets the position on the minor axis.
        /// </summary>
        public int Position { get; init; }
        
        /// <summary>
        ///     Gets the start position on the major axis.
        /// </summary>
        public int Start { get; init; }
        /// <summary>
        ///     Gets the end position on the major axis.
        /// </summary>
        public int End { get; init; }
        /// <summary>
        ///     Gets the length of the wall along the major axis.
        /// </summary>
        public int Length => End - Start;

        public int X1 =>  Vertical ? Position : Start;
        public int X2 =>  Vertical ? Position : End;
        public int Y1 => !Vertical ? Position : Start;
        public int Y2 => !Vertical ? Position : End;

        /// <summary>
        ///     Gets whether the wall is vertical.
        /// </summary>
        public bool Vertical { get; init; }
        /// <summary>
        ///     Gets whether the wall is horizontal
        /// </summary>
        public bool Horizontal
        {
            get => !Vertical;
            init => Vertical = !value;
        }

        public MazeWall() { }
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
            return new MazeWall
            {
                Vertical = true,
                Position = x,
                Start = y1,
                End = y2
            };
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
            return new MazeWall
            {
                Horizontal = true,
                Position = y,
                Start = x1,
                End = x2
            };
        }
    }
}
