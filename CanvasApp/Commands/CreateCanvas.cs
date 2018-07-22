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
                throw new ArgumentException($"{Constants.Command_Expect_Two_Arguments} {args.Length}");

            if (!uint.TryParse(args[0], out uint width)
                    || !uint.TryParse(args[1], out uint height))
                throw new ArgumentException($"{Constants.Command_Expect_Two_Positive_Arguments}");

            return new Canvas(width, height);
        }
    }
}
