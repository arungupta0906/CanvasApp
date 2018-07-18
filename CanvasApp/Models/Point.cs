using System;
using System.Collections.Generic;
using System.Text;

namespace CanvasApp.Models
{
    public struct Point
    {
        public uint X { get; private set; }
        public uint Y { get; private set; }

        public Point(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
