using System;
using Xunit;

namespace MazeGen.Tests
{
    public class MazeWallTests
    {
        [Theory]
        [InlineData(false, 1, 2, 5, 2)]
        [InlineData(false, 2, 5, 3, 3)]
        [InlineData(true, 3, 2, 1, 3)]
        [InlineData(true, -2, 1, 2, -2)]
        public void WallShouldHaveCorrectX1(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.X1);
        }
        [Theory]
        [InlineData(false, 1, 2, 5, 5)]
        [InlineData(false, 2, 5, 3, 5)]
        [InlineData(true, 3, 2, 1, 3)]
        [InlineData(true, -2, 1, 2, -2)]
        public void WallShouldHaveCorrectX2(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.X2);
        }
        [Theory]
        [InlineData(false, 1, 2, 5, 1)]
        [InlineData(false, 2, 5, 3, 2)]
        [InlineData(true, 3, 2, 1, 1)]
        [InlineData(true, -2, 1, 2, 1)]
        public void WallShouldHaveCorrectY1(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.Y1);
        }
        [Theory]
        [InlineData(false, 1, 2, 5, 1)]
        [InlineData(false, 2, 5, 3, 2)]
        [InlineData(true, 3, 2, 1, 2)]
        [InlineData(true, -2, 1, 2, 2)]
        public void WallShouldHaveCorrectY2(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.Y2);
        }

        [Theory]
        [InlineData(true, 3, 5, 7, 3)]
        [InlineData(true, 5, 7, 4, 5)]
        [InlineData(false, 2, 8, 20, 14)]
        [InlineData(false, 6, 15, 4, 9.5f)]
        public void WallShouldHaveCorrectCenterX(bool vert, int pos, int start, int end, float result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.CenterX);
        }
        [Theory]
        [InlineData(true, 3, 5, 7, 6)]
        [InlineData(true, 5, 7, 4, 5.5f)]
        [InlineData(false, 2, 8, 20, 2)]
        [InlineData(false, 6, 15, 4, 6)]
        public void WallShouldHaveCorrectCenterY(bool vert, int pos, int start, int end, float result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.CenterY);
        }
        [Theory]
        [InlineData(true, 1, 2, 3, -1)]
        [InlineData(false, 1, 2, 3, 1)]
        [InlineData(false, 2, 3, 1, 2)]
        public void WallShouldHaveCorrectWidth(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.Width);
        }

        [Theory]
        [InlineData(false, 1, 2, 3, -1)]
        [InlineData(true, 1, 2, 3, 1)]
        [InlineData(true, 2, 3, 1, 2)]
        public void WallShouldHaveCorrectHeight(bool vert, int pos, int start, int end, int result)
        {
            MazeWall wall = new MazeWall(vert, pos, start, end);
            Assert.Equal(result, wall.Height);
        }

        [Theory]
        [InlineData(1, 2, 1)]
        [InlineData(-1, 5, 6)]
        [InlineData(5, 1, 4)]
        [InlineData(-3, -2, 1)]
        public void WallShouldHaveCorrectLength(int start, int end, int result)
        {
            MazeWall wall = new MazeWall(true, 0, start, end);
            Assert.Equal(result, wall.Length);
        }

        [Fact]
        public void WallShouldBeHorizontal()
        {
            MazeWall wall = new MazeWall(false, 0, 1, 2);
            Assert.True(wall.Horizontal);
        }
        [Fact]
        public void WallShouldNotBeHorizontal()
        {
            MazeWall wall = new MazeWall(true, 0, 1, 2);
            Assert.False(wall.Horizontal);
        }

        [Fact]
        public void ShouldCreateHorizontalWall()
        {
            Assert.True(MazeWall.Horz(1, 2, 3).Horizontal);
        }
        [Fact]
        public void ShouldCreateVerticalWall()
        {
            Assert.True(MazeWall.Vert(1, 2, 3).Vertical);
        }
    }
}
