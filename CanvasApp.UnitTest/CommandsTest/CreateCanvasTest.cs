using CanvasApp.Commands;
using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.UnitTest.CommandsTest
{
    public class CreateCanvasTest
    {
        [Fact]
        public void ExecuteCommand_Invalid_No_Of_Arguments_Exception_Null()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args = new string[0];
            var exception = Record.Exception(() => createCanvas.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Two_Arguments} {args.Length}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_Invalid_No_Of_Arguments_Exception_One()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args = new string[1] { "4" };
            var exception = Record.Exception(() => createCanvas.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Two_Arguments} {args.Length}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_Invalid_Argument_One()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args = new string[2] { "-4", "3" };
            var exception = Record.Exception(() => createCanvas.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Two_Positive_Arguments}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_Invalid_Argument_Two()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args = new string[2] { "4", "-3" };
            var exception = Record.Exception(() => createCanvas.ExecuteCommand(args));
            Assert.NotNull(exception);
            Assert.IsType<ArgumentException>(exception);
            Assert.Equal($"{Constants.Command_Expect_Two_Positive_Arguments}", exception.Message);
        }

        [Fact]
        public void ExecuteCommand_CreateCanvas()
        {
            CreateCanvas createCanvas = new CreateCanvas();
            string[] args = new string[2] { "20", "4" };
            ICanvas canvas = createCanvas.ExecuteCommand(args);
            Assert.NotNull(canvas);
            for (int i = 0; i < 22; i++)
            {
                Assert.Equal('-', canvas.Cells[i, 0]);
                Assert.Equal('-', canvas.Cells[i, 5]);
            }
            for (int i = 1; i < 5; i++)
            {
                Assert.Equal('|', canvas.Cells[0, i]);
                Assert.Equal('|', canvas.Cells[21, i]);
            }   
        }
    }
}
