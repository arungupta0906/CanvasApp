using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Models
{
    public interface ICanvas
    {
        char[,] Cells { get; set; }
        bool DrawCanvas();
        bool DrawLine(Line lines);
        bool DrawRectangle(Rectangle rectangle);
        bool BucketFill(Point target, char colour);
    }
}
