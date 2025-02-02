using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace DrawingExample
{
    class MyLine
    {
        /*
Name: Hutton Ledingham
Assignment: Drawing Shapes
Due Date: March 21 2022
Purpose: To make a straight and diagonal line.
*/

        //variables
        Points one;
        Points two;

        //Constructors
        public MyLine()
        {
            //temp point
            one = new Points(5,10);
            two = new Points(50,10);
        }

        public MyLine(Points startingPoints, Points endingPoints)
        {
            one = startingPoints;
            two = endingPoints;
        }

        public void drawLine(SolidBrush currentBrush)
        {
            //If the x or y are not equal, the line is diagonal.
            if (one.getY() != two.getY() && one.getX() != two.getX())
            {
                //Grab the difference of the x and y.
                float differenceX = two.getX() - one.getX();
                float differenceY = two.getY() - one.getY();

                //Grab the base y value.
                int yValue = one.getY();

                //Grab the slope of the line.
                float slope = (differenceY / differenceX);
                float yLevelUp = Math.Abs(slope);

                //Reflected horizontal.
                if (one.getX() < two.getX())
                {
                    for (int i = one.getX(); i < two.getX(); i++)
                    {
                        //If the yLevelUp is greater than zero we can go to the next y value to place a block. So we can get an accurate line.
                        while (Math.Abs(yLevelUp) >= 1)
                        {
                            //Update the yValue
                            yValue += Convert.ToInt32(slope / Math.Abs(slope));

                            Points newPoint = new Points(i, yValue);
                            newPoint.drawPoint(currentBrush);

                            //To make sure the yValue doesn't keep going up.
                            yLevelUp--;
                        }

                        //If yLevelUp is below 1 place a block on the same yValue but a different xValue.
                        if(yLevelUp < 1)
                        {
                            Points newPoint = new Points(i, yValue);
                            newPoint.drawPoint(currentBrush);
                        }

                        //Add the slope top yLevelUp, so we can get an accurate slope for the line. As we only go to the next yValue when it is time to.
                        yLevelUp += Math.Abs(slope);
                    }
                }
                else
                {
                    //Same thing as above but it starts at the second point if it's smaller than the first point.
                    yValue = two.getY();

                    for (int i = two.getX(); i < one.getX(); i++)
                    {
                        while (Math.Abs(yLevelUp) >= 1)
                        {
                            yValue += Convert.ToInt32(slope / Math.Abs(slope));

                            Points newPoint = new Points(i, yValue);
                            newPoint.drawPoint(currentBrush);
                            yLevelUp--;
                        }

                        if (yLevelUp < 1)
                        {
                            Points newPoint = new Points(i, yValue);
                            newPoint.drawPoint(currentBrush);

                        }

                        yLevelUp += Math.Abs(slope);
                    }
                }
            }
            //If the line is horizontal.
            else if(one.getX() > two.getX())
            {
                //To make it fill each spot between the two points.
                for (int i = two.getX(); i < one.getX(); i++)
                {
                    Points newPoint = new Points(i, one.getY());

                    newPoint.drawPoint(currentBrush);
                }
            }
            else if(one.getX() < two.getX())
            {
                for (int i = one.getX(); i < two.getX(); i++)
                {
                    Points newPoint = new Points(i, one.getY());

                    newPoint.drawPoint(currentBrush);
                }
            }
            //If the line is vertical.
            else if (one.getY() > two.getY())
            {
                for (int i = two.getY(); i < one.getY(); i++)
                {
                    Points newPoint = new Points(one.getX(), i);

                    newPoint.drawPoint(currentBrush);
                }
            }
            else if (one.getY() < two.getY())
            {
                for (int i = one.getY(); i < two.getY(); i++)
                {
                    Points newPoint = new Points(one.getX(), i);

                    newPoint.drawPoint(currentBrush);
                }
            }
        }
    }
}
