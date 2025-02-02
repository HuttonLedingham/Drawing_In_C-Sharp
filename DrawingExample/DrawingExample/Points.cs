using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace DrawingExample
{
    class Points
    {
        /*
        Name: Hutton Ledingham
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: To make a point that you can draw or reference in other files to help make shapes. As it serves as coordinates for the other shapes.
        */

        private int xValue;
        private int yValue;
        private SolidBrush theBrush;
        
        public Points()
        {
            xValue = 400;
            yValue = 100;

            theBrush = new SolidBrush(Color.Aqua);
        }

        public Points(int x, int y, SolidBrush myBrush)
        {
            xValue = x;
            yValue = y;
            theBrush = myBrush;
        }

        public Points(int x, int y)
        {
            xValue = x;
            yValue = y;
            theBrush = new SolidBrush(Color.MediumVioletRed);
        }

        public SolidBrush getBrush()
        {
            return theBrush;
        }

        public int getX()
        {
            return xValue;
        }

        public int getY()
        {
            return yValue;
        }

        public void setBrush(SolidBrush b)
        {
            theBrush = b;
        }

        public void drawPoint()
        {
            Graphics grapgicsObj = Form1.ActiveForm.CreateGraphics();
            //draws point.
            grapgicsObj.FillEllipse(theBrush, xValue, yValue, 10,10);
        }

        public void drawPoint(SolidBrush b)
        {
            Graphics grapgicsObj = Form1.ActiveForm.CreateGraphics();

            grapgicsObj.FillEllipse(b, xValue, yValue, 3, 3);
        }
    }
}
