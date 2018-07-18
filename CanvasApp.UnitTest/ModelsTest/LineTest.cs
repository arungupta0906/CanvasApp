using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.ModelsTest
{
    public class LineTest
    {
        [Fact]
        public void Line_Create_Object_Horizontal()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(10, 2);
            Line line = new Line(origin, end);
            Assert.True(line.IsHorizontal);
            Assert.False(line.IsVertical);
            Assert.Equal(origin, line.Origin);
            Assert.Equal(end, line.End);
        }

        [Fact]
        public void Line_Create_Object_Vertical()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 5);
            Line line = new Line(origin, end);
            Assert.False(line.IsHorizontal);
            Assert.True(line.IsVertical);
            Assert.Equal(origin, line.Origin);
            Assert.Equal(end, line.End);
        }

        [Fact]
        public void GetPoints_SinglePoint()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 2);
            Line line = new Line(origin, end);
            var points = line.GetPoints().ToHashSet();
            Assert.Single(points);
            Assert.Contains(origin, points); 
        }

        [Fact]
        public void GetPoints_HorizontalLine()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(5, 2);
            Point point1 = new Point(3, 2);
            Point point2 = new Point(4, 2);
            Line line = new Line(origin, end);
            var points = line.GetPoints().ToHashSet();
            Assert.Equal(4, points.Count);
            Assert.Contains(origin, points);
            Assert.Contains(point1, points);
            Assert.Contains(point2, points);
            Assert.Contains(end, points);
        }

        [Fact]
        public void GetPoints_VerticalLine()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 5);
            Point point1 = new Point(2, 3);
            Point point2 = new Point(2, 4);
            Line line = new Line(origin, end);
            var points = line.GetPoints().ToHashSet();
            Assert.Equal(4, points.Count);
            Assert.Contains(origin, points);
            Assert.Contains(point1, points);
            Assert.Contains(point2, points);
            Assert.Contains(end, points);
        }
    }
}
