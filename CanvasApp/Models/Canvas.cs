using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Models
{
    public class Canvas : ICanvas
    {
        public char[,] Cells { get; private set; }
        uint width;
        uint height;

        public Canvas(uint width, uint height)
        {
            this.width = width;
            this.height = height;
            Initialize(width, height);
        }

        private void Initialize(uint width, uint height)
        {
            Cells = new char[width, height];

            for (int i = 0; i < width; i++)
            {
                Cells[i, 0] = '-';
                Cells[i, height - 1] = '-';
            }
            for (int i = 1; i < height - 1; i++)
            {
                Cells[0, i] = '|';
                Cells[width - 1, i] = '|';
            }
        }

        public void DrawCanvas()
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    Console.Write(Cells[j, i]);
                }
                Console.WriteLine();
            }
        }

        public void DrawLine(Line line)
        {
            if (!line.IsHorizontal && !line.IsVertical)
                throw new InvalidLineException();

            if (PointIsOutOfBounds(line.Origin) || PointIsOutOfBounds(line.End))
                throw new OutOfBoundsException("This line is out of canvas boundaries and cannot be drawn");

            InnerDrawLine(line);
        }

        private void InnerDrawLine(Line line)
        {
            var points = line.GetPoints();
            foreach (var point in points)
                DrawPoint(point);
        }

        public void DrawRectangle(Rectangle rectangle)
        {
            if (PointIsOutOfBounds(rectangle.UpperLeft)
                 || PointIsOutOfBounds(rectangle.UpperRight)
                 || PointIsOutOfBounds(rectangle.LowerLeft)
                 || PointIsOutOfBounds(rectangle.LowerRight)
                 )
                throw new OutOfBoundsException("This rectangle is out of canvas boundaries and cannot be drawn");

            var lines = rectangle.GetLines();

            foreach (var line in lines)
                InnerDrawLine(line);
        }

        private bool PointIsOutOfBounds(Point point)
        {
            return point.X >= width || point.Y >= height;
        }

        private void DrawPoint(Point point)
        {
            Cells[point.X, point.Y] = 'x' ;
        }

        public void BucketFill(Point target, char colour)
        {
            if (PointIsOutOfBounds(target))
                throw new OutOfBoundsException("The target point is out of the canvas boundaries");

            InnerBucketFill(target, colour);
        }

        private void InnerBucketFill(Point target, char colour)
        {

            var contentTypeToFill = Cells[target.X, target.Y];

            var processed = new HashSet<Point>();
            var toProcess = new Queue<Point>();

            toProcess.Enqueue(target);

            //Func<Point, bool> CanProcessCell = (c) => !processed.Contains(c) && !toProcess.Contains(c) && !PointIsOutOfBounds(c);

            bool CanProcessCell(Point c ) => !processed.Contains(c) && !toProcess.Contains(c) && !PointIsOutOfBounds(c);

            while (toProcess.Count > 0)
            {
                var currentPoint = toProcess.Dequeue();

                processed.Add(currentPoint);

                if (Cells[currentPoint.X, currentPoint.Y] == contentTypeToFill)
                {
                    Cells[currentPoint.X, currentPoint.Y] = colour;

                    var leftNeighbour = new Point(currentPoint.X - 1, currentPoint.Y);
                    if (CanProcessCell(leftNeighbour))
                        toProcess.Enqueue(leftNeighbour);

                    var rightNeighbour = new Point(currentPoint.X + 1, currentPoint.Y);
                    if (CanProcessCell(rightNeighbour))
                        toProcess.Enqueue(rightNeighbour);

                    var topNeighbour = new Point(currentPoint.X, currentPoint.Y - 1);
                    if (CanProcessCell(topNeighbour))
                        toProcess.Enqueue(topNeighbour);

                    var bottomNeighbour = new Point(currentPoint.X, currentPoint.Y + 1);
                    if (CanProcessCell(bottomNeighbour))
                        toProcess.Enqueue(bottomNeighbour);
                }
            }
        }
    }

    public class InvalidLineException : Exception
    {
        public InvalidLineException()
            : base("Only horizontal and vertical lines can be drawn")
        { }
    }

    public class OutOfBoundsException : Exception
    {
        public OutOfBoundsException(string msg)
            : base(msg)
        { }
    }
}
