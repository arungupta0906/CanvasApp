using CanvasApp.Commands;
using CanvasApp.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.CommandsTest
{
    public class CreateRectangleTest
    {
        Mock<ICanvas> _canvas;
        public CreateRectangleTest()
        {
            _canvas = new Mock<ICanvas>();
        }

        [Theory]
        [InlineData("R", new string[] { })]
        [InlineData("R", new string[] { "1" })]
        [InlineData("R", new string[] { "6", "3" })]
        [InlineData("R", new string[] { "6", "3", "6" })]
        public void ExecuteCommand_Invalid_No_Of_Arguments_Exception(string CommandName, string[] args)
        {
            CreateRectangle createRectangle = new CreateRectangle(_canvas.Object);
            var exception = Record.Exception(() => createRectangle.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Four_Arguments} {args.Length}", exception.Message);
            Assert.Equal("R", CommandName);
        }

        [Theory]
        [InlineData("R", new string[] { "-1", "2", "6", "2" })]
        [InlineData("R", new string[] { "1", "-2", "6", "2" })]
        [InlineData("R", new string[] { "1", "2", "-6", "2" })]
        [InlineData("R", new string[] { "1", "2", "6", "-2" })]
        public void ExecuteCommand_Invalid_Argument(string CommandName, string[] args)
        {
            CreateRectangle createRectangle = new CreateRectangle(_canvas.Object);
            var exception = Record.Exception(() => createRectangle.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Four_Positive_Arguments}", exception.Message);
            Assert.Equal("R", CommandName);
        }

        [Fact]
        public void ExecuteCommand_Canvas_Not_Exists()
        {
            string[] args = new string[] { "1", "2", "6", "2" };
            CreateRectangle createRectangle = new CreateRectangle(null);
            var exception = Record.Exception(() => createRectangle.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Canvas_Not_Exists}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_Create_Rectangle_Success()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args1 = new string[] { "20", "4" };
            var canvas = createCanvas.ExecuteCommand(args1);
            string[] args = new string[] { "14", "1", "18", "3" };
            CreateRectangle createRectangle = new CreateRectangle(canvas);
            var result = createRectangle.ExecuteCommand(args);
            Assert.NotNull(result);
            for (int i = 14; i <= 18; i++)
            {
                Assert.Equal('x', canvas.Cells[i, 1]);
                Assert.Equal('x', canvas.Cells[i, 3]);
            }
            for (int i = 2; i < 3; i++)
            {
                Assert.Equal('x', canvas.Cells[14, i]);
                Assert.Equal('x', canvas.Cells[18, i]);
            }
        }
    }
}
