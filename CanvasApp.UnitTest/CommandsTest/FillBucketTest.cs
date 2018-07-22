using CanvasApp.Commands;
using CanvasApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.CommandsTest
{
    public class FillBucketTest
    {
        Mock<ICanvas> _canvas;
        public FillBucketTest()
        {
            _canvas = new Mock<ICanvas>();
        }

        [Theory]
        [InlineData("B", new string[] { })]
        [InlineData("B", new string[] { "1" })]
        [InlineData("B", new string[] { "6", "3" })]
        public void ExecuteCommand_Invalid_No_Of_Arguments_Exception(string CommandName, string[] args)
        {
            FillBucket fillBucket = new FillBucket(_canvas.Object);
            var exception = Record.Exception(() => fillBucket.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Three_Arguments} {args.Length}", exception.Message);
            Assert.Equal("B", CommandName);
        }

        [Theory]
        [InlineData("B", new string[] { "-1", "2", "o" })]
        [InlineData("B", new string[] { "1", "-2", "o" })]
        [InlineData("B", new string[] { "1", "2", "-6" })]
        public void ExecuteCommand_Invalid_Argument(string CommandName, string[] args)
        {
            FillBucket fillBucket = new FillBucket(_canvas.Object);
            var exception = Record.Exception(() => fillBucket.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Two_Positive_One_Alphanumeric_Arguments}", exception.Message);
            Assert.Equal("B", CommandName);
        }

        [Fact]
        public void ExecuteCommand_Canvas_Not_Exists()
        {
            string[] args = new string[] { "1", "2", "o" };
            FillBucket fillBucket = new FillBucket(null);
            var exception = Record.Exception(() => fillBucket.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Canvas_Not_Exists}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_Fill_Bucket_Success()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args1 = new string[] { "20", "4" };
            var canvas = createCanvas.ExecuteCommand(args1);
            string[] args = new string[] { "10", "2", "o" };
            FillBucket fillBucket = new FillBucket(canvas);
            var result = fillBucket.ExecuteCommand(args);
            Assert.NotNull(result);
            for (int i = 1; i < 21; i++)
                for(int j = 1; j < 5; j++)
                    Assert.Equal('o', canvas.Cells[i, j]);
        }
    }
}
