using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Commands
{
    public class CreateCanvas : ICommand
    {
        public CreateCanvas()
        {
        }

        public ICanvas ExecuteCommand(string[] args)
        {
            if (args.Length < 2)
                throw new ArgumentException($"This command expects 2 arguments but only received {args.Length}");

            if (!uint.TryParse(args[0], out uint width)
                    || !uint.TryParse(args[1], out uint height))
                throw new ArgumentException("There is some invalid arguments. Both arguments should be positive integers");

            width = width + 2;
            height = height + 2;

            return new Canvas(width, height);
        }
    }
}
