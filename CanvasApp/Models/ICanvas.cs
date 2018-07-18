using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Models
{
    public interface ICanvas
    {
        void DrawCanvas();
        void DrawLine(Line lines);
        void DrawRectangle(Rectangle rectangle);
        void BucketFill(Point target, char colour);
    }
}
