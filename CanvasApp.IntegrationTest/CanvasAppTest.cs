using CanvasApp.Commands;
using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CanvasApp.IntegrationTest
{
    public class CanvasAppTest
    {
        [Fact]
        public void CanvasApp_Test()
        {
            List<string> commands = new List<string>
            {
                new string("C 20 4"),
                new string("L 1 2 6 2"),
                new string("L 6 3 6 4"),
                new string("R 14 1 18 3"),
                new string("B 10 3 o"),
            };

            ICanvas canvas = null;
            ICommand command;
            foreach (string com in commands)
            {
                var input = InputParser.ParseInput(com);
                switch (input.Command.ToUpper())
                {
                    case "C":
                        command = new CreateCanvas();
                        ExecuteCommandAndDrawCanvas();
                        break;
                    case "L":
                        command = new CreateLine(canvas);
                        ExecuteCommandAndDrawCanvas();
                        break;
                    case "R":
                        command = new CreateRectangle(canvas);
                        ExecuteCommandAndDrawCanvas();
                        break;
                    case "B":
                        command = new FillBucket(canvas);
                        ExecuteCommandAndDrawCanvas();
                        break;
                    case "Q":
                        command = new ExitCommand();
                        command.ExecuteCommand(input.Args);
                        break;
                    default:
                        break;
                        void ExecuteCommandAndDrawCanvas()
                        {
                            try
                            {
                                canvas = command.ExecuteCommand(input.Args);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                            }
                        }
                }
            }

            string[] expected = new string[6]
            {
                "----------------------",
                "|oooooooooooooxxxxxoo|",
                "|xxxxxxooooooox   xoo|",
                "|     xoooooooxxxxxoo|",
                "|     xoooooooooooooo|",
                "----------------------"
            };

            for (int i = 0; i < 6; i++)
            {
                StringBuilder sb = new StringBuilder();
                for (int j = 0; j < 22; j++)
                {
                    sb.Append(canvas.Cells[j, i]);
                }
                sb.Replace('\0', ' ');
                Assert.Equal(expected[i], sb.ToString());
            }
        }
    }
}
