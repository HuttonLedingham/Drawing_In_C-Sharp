using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingExample
{
    class Spike
    {
        /*
        Name: Hutton Ledingham
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: To make a eye shape / diamond shape.
        */

        Points cornerPoint;

        public Spike()
        {
            //temp point

            cornerPoint = new Points(100, 100);
        }

        public Spike (Points first)
        {
            cornerPoint = first;
        }

        //Can create diamond or different shapes
        public void drawSpike(int width , int height , SolidBrush brush)
        {
            //Makes the center rectangle.
            Rectangle newRect = new Rectangle(cornerPoint);
            newRect.drawRectangle(height, width, brush);

            //Makes the top triangle.
            Triangle topTrian = new Triangle(cornerPoint);
            topTrian.drawTriangle(width, height,1, brush);

            //Left triangle.
            topTrian.drawTriangle(height , height, 4, brush);

            //Make a new point so we can place the right traingle there.
            Points rightTop = new Points(cornerPoint.getX() + width -1, cornerPoint.getY());
            Triangle rightTrian = new Triangle(rightTop);
            rightTrian.drawTriangle(height, height, 2, brush);

            //Make a new point so we can place the bortom traingle there.
            Points leftBottom = new Points(cornerPoint.getX(), cornerPoint.getY() + height - 1);
            Triangle bottomTrian = new Triangle(leftBottom);
            bottomTrian.drawTriangle(width, height, 3, brush);
        }

        //To make a diamond
        public void drawSpike(int width, SolidBrush brush)
        {
            //Same thing as above but for a diamond shape.
            Rectangle newRect = new Rectangle(cornerPoint);
            newRect.drawRectangle(width, width, brush);

            Triangle topTrian = new Triangle(cornerPoint);
            topTrian.drawTriangle(width, width, 1, brush);

            topTrian.drawTriangle(width, width, 4, brush);

            Points rightTop = new Points(cornerPoint.getX() + width - 1, cornerPoint.getY());
            Triangle rightTrian = new Triangle(rightTop);
            rightTrian.drawTriangle(width, width, 2, brush);

            Points leftBottom = new Points(cornerPoint.getX(), cornerPoint.getY() + width - 1);
            Triangle bottomTrian = new Triangle(leftBottom);
            bottomTrian.drawTriangle(width, width, 3, brush);
        }

        //3D diamond or eyeshape
        public void drawSpike(int width, int height, int depth, SolidBrush brush)
        {
            SolidBrush alternateBrush;

            //Grab the starting points
            int startingLocationX = cornerPoint.getX();
            int startingLocationY = cornerPoint.getY();

            //Make new spikes and move them down left and do that over and over to have an 3d like effect.
            for (int i = 0; i < depth / 2; i += 2)
            {
                Points newPoint = new Points(startingLocationX + i, startingLocationY + i);

                //Have a differet 3d effect if it's a diamond or eye shape
                if (width != height)
                {
                     newPoint = new Points(startingLocationX + i, startingLocationY + i);
                }
                else
                {
                    newPoint = new Points(startingLocationX, startingLocationY +i);
                }

                Spike newSpike = new Spike(newPoint);

                //Alternating colours every second spike.
                if (i % 4 == 0)
                {
                    alternateBrush = new SolidBrush(Color.DarkRed);
                }
                else
                {
                    alternateBrush = brush;
                }

                //Draw new shape at the new points.
                newSpike.drawSpike(width, height, alternateBrush);
            }
        }
    }
}
