using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Models
{
    public struct Rectangle
    {
        public Point UpperLeft { get; private set; }
        public Point UpperRight { get; private set; }
        public Point LowerRight { get; private set; }
        public Point LowerLeft { get; private set; }

        public Rectangle(Point upperLeft, Point lowerRight)
        {
            UpperLeft = upperLeft;
            UpperRight = new Point(lowerRight.X, upperLeft.Y); 
            LowerRight = lowerRight;
            LowerLeft = new Point(upperLeft.X, lowerRight.Y);
        }

        public IEnumerable<Line> GetLines()
        {
            return new List<Line>
            {
                new Line (UpperLeft, UpperRight),
                new Line (UpperRight, LowerRight),
                new Line (LowerRight, LowerLeft),
                new Line (LowerLeft, UpperLeft)
            };
        }
    }
}
