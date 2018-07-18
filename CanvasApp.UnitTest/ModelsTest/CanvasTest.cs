using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.ModelsTest
{
    public class CanvasTest
    {
        [Fact]
        public void Canvas_CreateObject()
        {
            uint width = 20;
            uint height = 10;
            Canvas canvas = new Canvas(width, height);
            Assert.NotNull(canvas);
            Assert.Equal(200, canvas.Cells.Length);
        }
    }
}
