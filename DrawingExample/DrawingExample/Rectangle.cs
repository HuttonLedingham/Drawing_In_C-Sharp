using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingExample
{
    class Rectangle
    {
        /*
        Name: Hutton Ledingham
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: To make a rectangle shape.
        */
        Points cornerPoint;
        int h;
        int w;

        public Rectangle()
        {
            //temp point
            cornerPoint = new Points(5, 10);
        }

        public Rectangle (Points startingPoint)
        {
            cornerPoint = startingPoint;
        }

        public void drawRectangle(int height, int width, SolidBrush brush)
        {
            //The height and width of rectange.
            w = width;
            h = height;
            SolidBrush newBrush = new SolidBrush(Color.Black);
            //Starting location.
            int startingLocationX = cornerPoint.getX();
            int startingLocationY = cornerPoint.getY();

            //Fill in the rectangle line by lin
            for (int i = 0; i < w; i++)
            {
                //Starts from the origin y value. 
                Points newPoint = new Points(i + startingLocationX, startingLocationY);
                //Goes to the max height of the rectangle.
                Points newPoint2 = new Points(i + startingLocationX, startingLocationY + h);
                //Draws the line.
                MyLine newLine = new MyLine(newPoint, newPoint2);
                newLine.drawLine(brush);
            }
        }

        //3D cube
        public void drawRectangle(int height, int width, int depth, SolidBrush brush)
        {
            w = width;
            h = height;
            SolidBrush alternateBrush;

            //Starting location.
            int startingLocationX = cornerPoint.getX();
            int startingLocationY = cornerPoint.getY();

            for (int i = 0; i < depth / 2; i++)
            {
                //Make new rectangles and move them down left and do that over and over to have an 3d effect.
                Points newPoint = new Points(startingLocationX + i, startingLocationY + i);

                Rectangle newRect = new Rectangle(newPoint);

                //Have alternating colours every third rectangle.
                if (i % 3 == 0)
                {
                    alternateBrush = new SolidBrush(Color.DarkRed);
                }
                else
                {
                    alternateBrush = brush;
                }

                //Draw new shape at the new points.
                newRect.drawRectangle(height,width,alternateBrush);
            }
        }
    }
}
