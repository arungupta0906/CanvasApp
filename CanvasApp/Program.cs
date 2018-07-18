using System;
using CanvasApp.Commands;
using CanvasApp.Models;

namespace CanvasApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanvas canvas = null;
            ICommand command;
            while (true)
            {
                Console.Write("enter command : ");
                var userInput = Console.ReadLine();
                var input = InputParser.ParseInput(userInput);                
                switch(input.Command.ToUpper())
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
                                canvas.DrawCanvas();
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Error: {e.Message}");
                            }
                        }
                }                
            }
        }
    }
}
