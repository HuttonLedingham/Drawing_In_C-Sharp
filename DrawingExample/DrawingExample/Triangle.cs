using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace DrawingExample
{
    class Triangle
    {
        /*
        Name: Hutton Ledingham
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: To make a triangle shape.
        */

        Points cornerPoint;

        public Triangle()
        {
            //temp point
            cornerPoint = new Points(100, 10);
        }

        public Triangle(Points startingPoint)
        {
            cornerPoint = startingPoint;
        }

        public void drawTriangle(float width, int height,int rotation, SolidBrush brush)
        {
            Points endCorner;
            //Grab the incline of the triangle sides.
            float slope = height / width;
            float goToNextLevel = 0;
            int flipped;
            int yValue;

            //If there is a rotation of the triangle is point to the right or to the left.
            if (rotation == 2 || rotation == 4)
            {
                //The end corner goes to the opposite side of the triangle so we can make a line.
                endCorner = new Points(cornerPoint.getX(), cornerPoint.getY() + Convert.ToInt32(width), brush);

                yValue = cornerPoint.getX();
            }
            //If the rotation is pointing up or down.
            else
            {
                endCorner = new Points(cornerPoint.getX() + Convert.ToInt32(width), cornerPoint.getY(), brush);

                yValue = cornerPoint.getY();
            }

            //Help with reflecting the triangle vertically or horizontal.
            if(rotation == 2 || rotation == 3)
            {
                flipped = -1;
            }
            else
            {
                flipped = 1;
            }

            for (int i = 0; i < width/2; i++)
            {
                //When goToNextLevel gets over 1 we can go the next level of line. So we can get a accurate angle of the sides.
                while (Math.Abs(goToNextLevel) >= 1)
                {
                    //To to get the yValvue to the next step so we can get a triangle shape. Flipped is for reflections.
                    yValue -= Convert.ToInt32(slope / Math.Abs(slope)) * flipped;

                    //If the triangle is pointing left or right.
                    if (rotation == 2 || rotation == 4)
                    {
                        //Make new points of the ends of the triangle.
                        Points first = new Points(yValue, cornerPoint.getY() + i, brush);
                        Points second = new Points(yValue, endCorner.getY() - i, brush);
                        //Draw the line to fill the triangle in.
                        MyLine newLine = new MyLine(first, second);
                        newLine.drawLine(brush);
                    }
                    else
                    {
                        //Same as above but pointing up or down.
                        Points first = new Points(cornerPoint.getX() + i, yValue, brush);
                        Points second = new Points(endCorner.getX() - i, yValue, brush);
                        MyLine newLine = new MyLine(first, second);
                        newLine.drawLine(brush);
                    }

                    //So the yvalue doesn't continue to go up infinitely. 
                    goToNextLevel--;
                }
                
                //If below 0 the place another block on the same y value but a different x value.
                if (goToNextLevel < 1)
                {
                    
                    if (rotation == 2 || rotation == 4)
                    {
                        Points first = new Points(yValue, cornerPoint.getY() + i, brush);
                        Points second = new Points(yValue, endCorner.getY() - i, brush);
                        MyLine newLine = new MyLine(first, second);
                        newLine.drawLine(brush);
                    }
                    else
                    {
                        Points first = new Points(cornerPoint.getX() + i, yValue, brush);
                        Points second = new Points(endCorner.getX() - i, yValue, brush);
                        MyLine newLine = new MyLine(first, second);
                        newLine.drawLine(brush);
                    }
                    
                }

                //Add the slope to goToNextLevel, so we can get an accurate angle for the triangle sides. So we only go to the next yValue when it is time to do so.
                goToNextLevel += Math.Abs(slope);

            }
        }

        //Same as other drawTriangle function but without a rotation on the triangle.
        public void drawTriangle(float width, float height, SolidBrush brush)
        {
            Points endCorner = new Points(cornerPoint.getX() + Convert.ToInt32(width), cornerPoint.getY(), brush);

            int yValue = cornerPoint.getY();

            float slope = height / width;
            float goToNextLevel = 0;

            for (int i = 0; i < width / 2; i++)
            {

                while (Math.Abs(goToNextLevel) >= 1)
                {
                    yValue -=  Convert.ToInt32(slope/ Math.Abs(slope));

                    Points first = new Points(cornerPoint.getX() + i, yValue, brush);
                    Points second = new Points(endCorner.getX() - i, yValue, brush);

                    MyLine newLine = new MyLine(first, second);
                    newLine.drawLine(brush);

                    goToNextLevel--;
                }

                if (goToNextLevel < 1)
                {

                    Points first = new Points(cornerPoint.getX() + i, yValue, brush);
                    Points second = new Points(endCorner.getX() - i, yValue, brush);

                    MyLine newLine = new MyLine(first, second);
                    newLine.drawLine(brush);

                }

                goToNextLevel += Math.Abs(slope);

            }
        }

        //3d triangle
        public void drawTriangle(float width, float height, SolidBrush brush, int depth)
        {
            //Alternate colour.
            SolidBrush alternateBrush;

            //Starting location.
            int startingLocationX = cornerPoint.getX();
            int startingLocationY = cornerPoint.getY();

            //Make new triangles and move them down left and do that over and over to have an 3d effect.
            for (int i = 0; i < depth / 2; i++)
            {
                Points newPoint = new Points(startingLocationX + i, startingLocationY + i);

                Triangle newTrian = new Triangle(newPoint);

                //Alternating colours every third rectangle.
                if (i % 3 == 0)
                {
                    alternateBrush = new SolidBrush(Color.DarkRed);
                }
                else
                {
                    alternateBrush = brush;
                }

                //Draw new shape at the new points.
                newTrian.drawTriangle(width, height, alternateBrush);
            }
        }
    }
}
