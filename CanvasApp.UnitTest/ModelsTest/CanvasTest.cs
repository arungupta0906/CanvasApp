using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.ModelsTest
{
    public class CanvasTest
    {
        uint width;
        uint height;
        Canvas canvas = null;

        public CanvasTest()
        {
            width = 20;
            height = 10;
            canvas = new Canvas(width, height);
        }
        [Fact]
        public void Canvas_CreateObject()
        {
            Assert.NotNull(canvas);
            Assert.Equal((22 * 12), canvas.Cells.Length);
        }

        [Fact]
        public void DrawLine_InvalidLineException()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(10, 3);
            Line line = new Line(origin, end);
            var exception = Record.Exception(() => canvas.DrawLine(line));
            Assert.NotNull(exception);
            Assert.IsType<InvalidLineException>(exception);
        }

        [Fact]
        public void DrawLine_OutOfBoundsException()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(30, 2);
            Line line = new Line(origin, end);
            var exception = Record.Exception(() => canvas.DrawLine(line));
            Assert.NotNull(exception);
            Assert.IsType<OutOfBoundsException>(exception);
            Assert.Equal(Constants.Line_Out_Of_Canvas_Boundaries, exception.Message);
        }

        [Fact]
        public void DrawLine_SamePoint()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 2);
            Line line = new Line(origin, end);
            var result = canvas.DrawLine(line);
            Assert.NotNull(canvas);
            Assert.Equal('x', canvas.Cells[2,2]);
            Assert.True(result);
        }

        [Fact]
        public void DrawLine_Horizontal()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(5, 2);
            Line line = new Line(origin, end);
            var result = canvas.DrawLine(line);
            Assert.NotNull(canvas);
            for(int i = 2; i <= 5; i++)
                Assert.Equal('x', canvas.Cells[i, 2]);
            Assert.True(result);
        }

        [Fact]
        public void DrawLine_Vertical()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 6);
            Line line = new Line(origin, end);
            var result = canvas.DrawLine(line);
            Assert.NotNull(canvas);
            for (int i = 2; i <= 6; i++)
                Assert.Equal('x', canvas.Cells[2, i]);
            Assert.True(result);
        }

        [Fact]
        public void DrawRectangle_UpperRight_OutOfBoundsException()
        {
            Point upperleft = new Point(1, 1);
            Point lowerright = new Point(25, 2);
            Rectangle rectangle = new Rectangle(upperleft, lowerright);
            var exception = Record.Exception(() => canvas.DrawRectangle(rectangle));
            Assert.NotNull(exception);
            Assert.IsType<OutOfBoundsException>(exception);
            Assert.Equal(Constants.Rectangle_Out_Of_Canvas_Boundaries, exception.Message);
        }

        [Fact]
        public void DrawRectangle_LowerRight_OutOfBoundsException()
        {
            Point upperleft = new Point(1, 1);
            Point lowerright = new Point(15, 20);
            Rectangle rectangle = new Rectangle(upperleft, lowerright);
            var exception = Record.Exception(() => canvas.DrawRectangle(rectangle));
            Assert.NotNull(exception);
            Assert.IsType<OutOfBoundsException>(exception);
            Assert.Equal(Constants.Rectangle_Out_Of_Canvas_Boundaries, exception.Message);
        }

        [Fact]
        public void DrawRectangle_Test()
        {
            Point upperleft = new Point(5, 3);
            Point lowerright = new Point(12, 8);
            Rectangle rectangle = new Rectangle(upperleft, lowerright);
            var result = canvas.DrawRectangle(rectangle);
            Assert.NotNull(canvas);
            for (int i = 5; i <= 12; i++)
                Assert.Equal('x', canvas.Cells[i, 3]);
            for (int i = 3; i <= 8; i++)
                Assert.Equal('x', canvas.Cells[12, i]);
            for (int i = 12; i >= 5; i--)
                Assert.Equal('x', canvas.Cells[i, 8]);
            for (int i = 8; i >= 3; i--)
                Assert.Equal('x', canvas.Cells[5, i]);
            Assert.True(result);
        }

        [Fact]
        public void BucketFill_OutOfBoundsException()
        {
            Point target = new Point(25, 25);
            var exception = Record.Exception(() => canvas.BucketFill(target, 'o'));
            Assert.NotNull(exception);
            Assert.IsType<OutOfBoundsException>(exception);
            Assert.Equal(Constants.Point_Out_Of_Canvas_Boundaries, exception.Message);
        }

        [Fact]
        public void BucketFill_FillFullCanvas()
        {
            Point target = new Point(10, 5);
            var result = canvas.BucketFill(target, 'o');
            Assert.NotNull(canvas);
            for (int i = 1; i <= 10; i++)
                for (int j = 1; j <= 20; j++)
                    Assert.Equal('o', canvas.Cells[j,  i]);
            Assert.True(result);
        }

        [Fact]
        public void BucketFill_ReplaceRectangle()
        {
            Point upperleft = new Point(5, 3);
            Point lowerright = new Point(12, 8);
            Rectangle rectangle = new Rectangle(upperleft, lowerright);
            var result = canvas.DrawRectangle(rectangle);
            Point target = new Point(12, 8);
            canvas.BucketFill(target, 'o');
            Assert.NotNull(canvas);
            for (int i = 5; i <= 12; i++)
                Assert.Equal('o', canvas.Cells[i, 3]);
            for (int i = 3; i <= 8; i++)
                Assert.Equal('o', canvas.Cells[12, i]);
            for (int i = 12; i >= 5; i--)
                Assert.Equal('o', canvas.Cells[i, 8]);
            for (int i = 8; i >= 3; i--)
                Assert.Equal('o', canvas.Cells[5, i]);
            Assert.True(result);
        }

        [Fact]
        public void BucketFill_ReplaceHorizontalLine()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(5, 2);
            Line line = new Line(origin, end);
            var result = canvas.DrawLine(line);
            Point target = new Point(4, 2);
            canvas.BucketFill(target, 'o');
            Assert.NotNull(canvas);
            for (int i = 2; i <= 5; i++)
                Assert.Equal('o', canvas.Cells[i, 2]);
            Assert.True(result);
        }

        [Fact]
        public void BucketFill_ReplaceVerticalLine()
        {
            Point origin = new Point(2, 2);
            Point end = new Point(2, 6);
            Line line = new Line(origin, end);
            var result = canvas.DrawLine(line);
            Point target = new Point(2, 4);
            canvas.BucketFill(target, 'o');
            Assert.NotNull(canvas);
            for (int i = 2; i <= 6; i++)
                Assert.Equal('o', canvas.Cells[2, i]);
            Assert.True(result);
        }
    }
}
