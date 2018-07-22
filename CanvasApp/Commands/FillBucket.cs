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
                throw new ArgumentException($"{Constants.Command_Expect_Three_Arguments} {args.Length}");

            if (!uint.TryParse(args[0], out uint x)
                     || !uint.TryParse(args[1], out uint y)
                     || !char.TryParse(args[2], out char colour))
                throw new ArgumentException($"{Constants.Command_Expect_Two_Positive_One_Alphanumeric_Arguments}");

            if (_canvas == null)
                throw new ArgumentException($"{Constants.Command_Canvas_Not_Exists}");

            var adjustedTarget = new Point(x, y);

            _canvas.BucketFill(adjustedTarget, colour);
            return _canvas;
        }
    }
}
