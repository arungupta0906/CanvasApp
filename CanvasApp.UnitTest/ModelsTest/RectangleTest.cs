using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.ModelsTest
{
    public class RectangleTest
    {
        [Fact]
        public void Rectangle_Create_Object()
        {
            Point upperLeft = new Point(4, 5);
            Point upperRight = new Point(10, 5);
            Point lowerLeft = new Point(4, 10);
            Point lowerRight = new Point(10, 10);
            Rectangle rectangle = new Rectangle(upperLeft, lowerRight);
            Assert.Equal(upperLeft, rectangle.UpperLeft);
            Assert.Equal(upperRight, rectangle.UpperRight);
            Assert.Equal(lowerLeft, rectangle.LowerLeft);
            Assert.Equal(lowerRight, rectangle.LowerRight);
        }

        [Fact]
        public void GetLines_Test()
        {
            Point upperLeft = new Point(4, 5);
            Point upperRight = new Point(10, 5);
            Point lowerLeft = new Point(4, 10);
            Point lowerRight = new Point(10, 10);
            Line line1 = new Line(upperLeft, upperRight);
            Line line2 = new Line(upperRight, lowerRight);
            Line line3 = new Line(lowerRight, lowerLeft);
            Line line4 = new Line(lowerLeft, upperLeft);
            Rectangle rectangle = new Rectangle(upperLeft, lowerRight);
            var lines = rectangle.GetLines().ToHashSet();
            Assert.Contains(line1, lines);
            Assert.Contains(line2, lines);
            Assert.Contains(line3, lines);
            Assert.Contains(line4, lines);
        }
    }
}
