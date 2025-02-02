using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingExample
{
    public partial class Form1 : Form
    {

        /*
        Name: Hutton Ledingham 
        Assignment: Drawing Shapes
        Due Date: March 21 2022
        Purpose: Call all the code to get the shapes to appear on the screen.
        */

        public Form1()
        {
            InitializeComponent();
        }

        //create a rectangle and a cube.
        private void button1_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points myFirstPoint = new Points(100, 100, myBrush);
            Points mySecondPoint = new Points(250, 100, myBrush);

            //2D Rectangle
            Rectangle newRect = new Rectangle(myFirstPoint);
            newRect.drawRectangle(100, 100, myBrush);

            //3D Rectangle
            newRect = new Rectangle(mySecondPoint);
            newRect.drawRectangle(100, 100,50, myBrush);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Create a 2d triangle and a 3d triangle.
        private void button2_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points myFirstPoint = new Points(400, 200, myBrush);
            Points mySecondPoint = new Points(550, 200, myBrush);

            //2D triangle
            Triangle newTrian = new Triangle(myFirstPoint);
            newTrian.drawTriangle(100, 200, myBrush);

            //3D Triangle
            newTrian = new Triangle(mySecondPoint);
            newTrian.drawTriangle(100, 200, myBrush, 50);
        }

        //Create a 2d star and a star with a 3d effect.
        private void button3_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points myFirstPoint = new Points(100, 450, myBrush);
            Points mySecondPoint = new Points(250, 450, myBrush);

            //2D star
            Star newStar = new Star(myFirstPoint);
            newStar.drawStar(100, myBrush);

            //3D star
            newStar = new Star(mySecondPoint);
            newStar.drawStar(100, 27, myBrush);

        }

        //create both a diamond and an eye shape.
        private void button4_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points myFirstPoint = new Points(400, 350, myBrush);
            Points mySecondPoint = new Points(600, 350, myBrush);

            //Diamond
            Spike newSpike = new Spike(myFirstPoint);
            newSpike.drawSpike(100, myBrush);

            //Eyeshape
            newSpike = new Spike(mySecondPoint);
            newSpike.drawSpike(200, 100, myBrush);

        }

        //create a 3d diamond.
        private void button5_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points myFirstPoint = new Points(900, 350, myBrush);
            Points mySecondPoint = new Points(1000, 350, myBrush);

            Spike newSpike = new Spike(myFirstPoint);
            newSpike.drawSpike(50, 50, 51, myBrush);
        }

        //create a 3d eyeshape.
        private void button6_Click(object sender, EventArgs e)
        {
            SolidBrush myBrush = new SolidBrush(Color.Crimson);

            Points mySecondPoint = new Points(1000, 350, myBrush);
            Spike  newSpike = new Spike(mySecondPoint);
            newSpike.drawSpike(100, 50, 51, myBrush);
        }
    }
}
