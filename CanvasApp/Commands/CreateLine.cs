using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Commands
{
    public class CreateLine : ICommand
    {
        ICanvas _canvas;

        public CreateLine(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public ICanvas ExecuteCommand(string[] args)
        {
            if (args.Length < 4)
                throw new ArgumentException($"{Constants.Command_Expect_Four_Arguments} {args.Length}");

            if (!uint.TryParse(args[0], out uint x1)
                     || !uint.TryParse(args[1], out uint y1)
                     || !uint.TryParse(args[2], out uint x2)
                     || !uint.TryParse(args[3], out uint y2)
                    )
                throw new ArgumentException($"{Constants.Command_Expect_Four_Positive_Arguments}");

            if (_canvas == null)
                throw new ArgumentException($"{Constants.Command_Canvas_Not_Exists}");

            var P1 = new Point(x1, y1);
            var P2 = new Point(x2, y2);

            var line = new Line(P1, P2);
            _canvas.DrawLine(line);
            return _canvas;
        }
    }
}
