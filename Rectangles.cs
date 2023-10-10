using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InnerRectangles
{
    internal class Rectangle
    {
        public int Width { get; set; }
        public int Height { get; set; }

        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public override string ToString()
        {
            return $"Rectangle Width: {Width},Height: {Height}";
        }

        public IEnumerable<Rectangle> GetInnerRetangles()
        {
            var iterWidth = Width;
            var iterHeight = Height;

            while (true)
            {
                if (iterWidth == 0 || iterHeight == 0)
                {
                    yield break;
                }
                if (iterWidth < iterHeight)
                {
                    yield return new Rectangle(iterWidth, iterWidth);

                    iterHeight -= iterWidth;
                }
                else
                {
                    yield return new Rectangle(iterHeight, iterHeight);

                    iterWidth -= iterHeight;
                }
            }
        }
    }
}
