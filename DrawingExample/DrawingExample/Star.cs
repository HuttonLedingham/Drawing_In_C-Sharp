using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingExample
{
    class Star
    {
        /*
        Name: Hutton Ledingham
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: To make a star shape.
        */

        Points startingPoint;

        public Star()
        {
            //temp point
            startingPoint = new Points(100, 100);
        }

        public Star(Points start)
        {
            startingPoint = start;
        }

        public void drawStar(int height, SolidBrush brush)
        {
            //Goes to the top of the star.
            Points topPoint = new Points((height / 3) + startingPoint.getX(), startingPoint.getY() - height);
            MyLine line = new MyLine(startingPoint, topPoint);
            line.drawLine(brush);

            //Goes back down to the bottom right point.
            Points lowPoint = new Points((height / 3) + topPoint.getX(), topPoint.getY() + height);
            line = new MyLine(topPoint, lowPoint);
            line.drawLine(brush);

            //Goes to the left side.
            Points leftPoint = new Points(startingPoint.getX() - height / 4, topPoint.getY() + height / 3);
            line = new MyLine(leftPoint, lowPoint);
            line.drawLine(brush);

            //Goes to the right side.
            Points rightPoint = new Points(lowPoint.getX() + height / 4, leftPoint.getY());
            line = new MyLine(leftPoint, rightPoint);
            line.drawLine(brush);

            //Back to the origin, to complete the star.
            line = new MyLine(rightPoint, startingPoint);
            line.drawLine(brush);
        }

        //3D star
        public void drawStar(int height, int depth, SolidBrush brush)
        {
            SolidBrush alternateBrush;

            int startingLocationX = startingPoint.getX();
            int startingLocationY = startingPoint.getY();

            //Make new stars and move them down left and do that over and over to have an 3d effect.
            for (int i = 0; i < depth / 2; i++)
            {
                Points newPoint = new Points(startingLocationX + i, startingLocationY + i);

                Star newStar = new Star(newPoint);

                //Alternating colours every third star.
                if (i % 3 == 0)
                {
                    alternateBrush = new SolidBrush(Color.DarkRed);
                }
                else
                {
                    alternateBrush = brush;
                }

                //Draw new shape at the new points.
                newStar.drawStar(height, alternateBrush);
            }
        }
    }
}
