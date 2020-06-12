using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace Tic_tac_toe_csharp
{
    //this class is the engine, 
    //will used to take care of everything draws in our form panel 
    class GF
    {
        private Graphics m_graphic;

        public GF(Graphics graphic)
        {
            this.m_graphic = graphic;
            this.createBoxs();           
        }

        //this function for drawin boxes & lines
        public void createBoxs()
        {
            //for rectangle background color
            Brush background = new SolidBrush(Color.White);
            //for rectangle borders
            //first parameter is the color, second one is the width of the parameter
            Pen pen = new Pen(Color.Purple, 4);

            //now draw the rectangle with specified background & line
            this.m_graphic.FillRectangle(background, new Rectangle(0, 0, 500, 600));

            //now draw lines
            this.m_graphic.DrawLine(pen, new Point(167, 0), new Point(167, 600));
            this.m_graphic.DrawLine(pen, new Point(334, 0), new Point(334, 600));
            
            this.m_graphic.DrawLine(pen, new Point(0, 167), new Point(500, 167));
            this.m_graphic.DrawLine(pen, new Point(0, 334), new Point(500, 334));


        }

        public void jerry(Point point)
        {
            //create new image object
            Image newImage = Image.FromFile(@"E:\EMSI\POO\Projet\images\503-5035849_tom-and-jerry-cartoon-images-to-draw-pictures.png");

            //the form rectangle to put the image in the perfect place
            var rectangle = new Rectangle(point.X, point.Y, 167, 167);

            //now lets draw the image on the screen
            this.m_graphic.DrawImage(newImage, rectangle);
        }

        public void tom(Point point)
        {
            //create new image object
            Image newImage = Image.FromFile(@"E:\EMSI\POO\Projet\images\76657870f44b49e13d59cc2fdd52083f.png");
           
            //the form rectangle to put the image in the perfect place
            var rectangle = new Rectangle(point.X, point.Y, 167, 167);
            
            //now lets draw the image on the screen
            this.m_graphic.DrawImage(newImage, rectangle);

        }
    }
}
