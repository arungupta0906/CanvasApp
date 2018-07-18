using CanvasApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Commands
{
    public class FillBucket : ICommand
    {
        ICanvas _canvas;

        public FillBucket(ICanvas canvas)
        {
            _canvas = canvas;
        }

        public ICanvas ExecuteCommand(string[] args)
        {
            if (args.Length < 3)
                throw new ArgumentException($"This command expects 3 arguments but only received {args.Length}");

            if (!uint.TryParse(args[0], out uint x)
                     || !uint.TryParse(args[1], out uint y)
                     || !char.TryParse(args[2], out char colour))
                throw new ArgumentException("There are some invalid arguments. The 2 first arguments should be positive integer and the last one should be an alphanumerical character");

            if (_canvas == null)
                throw new ArgumentException("Canvas does not exists. Please create one then try again.");

            var adjustedTarget = new Point(x, y);

            _canvas.BucketFill(adjustedTarget, colour);
            return _canvas;
        }
    }
}
