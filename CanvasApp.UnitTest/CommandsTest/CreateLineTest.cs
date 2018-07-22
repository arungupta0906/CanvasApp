using CanvasApp.Commands;
using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using Moq;

namespace CanvasApp.UnitTest.CommandsTest
{
    public class CreateLineTest
    {
        Mock<ICanvas> _canvas;
        public CreateLineTest()
        {
            _canvas = new Mock<ICanvas>();
        }

        [Theory]
        [InlineData("L", new string[] { })]
        [InlineData("L", new string[] { "1" })]
        [InlineData("L", new string[] { "6", "3" })]
        [InlineData("L", new string[] { "6", "3", "6" })]
        public void ExecuteCommand_Invalid_No_Of_Arguments_Exception(string CommandName, string[] args)
        {
            CreateLine createLine = new CreateLine(_canvas.Object);
            var exception = Record.Exception(() => createLine.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Four_Arguments} {args.Length}", exception.Message);
            Assert.Equal("L", CommandName);
        }

        [Theory]
        [InlineData("L", new string[] { "-1", "2", "6", "2" })]
        [InlineData("L", new string[] { "1", "-2", "6", "2" })]
        [InlineData("L", new string[] { "1", "2", "-6", "2" })]
        [InlineData("L", new string[] { "1", "2", "6", "-2" })]
        public void ExecuteCommand_Invalid_Argument(string CommandName, string[] args)
        {
            CreateLine createLine = new CreateLine(_canvas.Object);
            var exception = Record.Exception(() => createLine.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Four_Positive_Arguments}", exception.Message);
            Assert.Equal("L", CommandName);
        }

        [Fact]
        public void ExecuteCommand_Canvas_Not_Exists()
        {
            string[] args = new string[] { "1", "2", "6", "2" };
            CreateLine createLine = new CreateLine(null);
            var exception = Record.Exception(() => createLine.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Canvas_Not_Exists}", exception.Message);            
        }

        [Fact]
        public void ExecuteCommand_Create_Line_Success()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args1 = new string[] { "20", "4" };
            var canvas = createCanvas.ExecuteCommand(args1);
            string[] args = new string[] { "1", "2", "6", "2" };
            CreateLine createLine = new CreateLine(canvas);
            var result = createLine.ExecuteCommand(args);
            Assert.NotNull(result);
            for (int i = 1; i <= 6; i++)
                Assert.Equal('x', canvas.Cells[i, 2]);
        }

    }
}
