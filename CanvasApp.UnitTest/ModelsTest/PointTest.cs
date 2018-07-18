using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.ModelsTest
{
    public class PointTest
    {
        [Fact]
        public void Point_Create_Object()
        {
            uint x = 1;
            uint y = 5;
            Point point = new Point(x, y);
            Assert.Equal(x, point.X);
            Assert.Equal(y, point.Y);
        }
    }
}
