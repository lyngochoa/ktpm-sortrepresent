using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace SortRepresent
{
    class ElementProperties
    {
        private int _x;

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        private int _y;

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        private int _width;

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        private int _height;

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        private string _value;

        public string Value
        {
            get { return _value; }
            set { _value = value; }
        }
        private int _idxColor;

        public int IdxColor
        {
            get { return _idxColor; }
            set { _idxColor = value; }
        }

        public ElementProperties(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.IdxColor = 0;
        }

        private Point _location;

        public Point Location
        {
            get { return new Point(_x, _y); }
            set 
            { 
                _location = value;
                X = _location.X;
                Y = _location.Y;
            }
        }
    }
}
