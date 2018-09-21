using System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Backend.Classes;

namespace JeylabTests
{
    [TestClass]
    public class clsTriangletest
    {
        [TestMethod]
        public void DrawisoscelesTriangle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsTriangle objTriangle = new clsTriangle();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objTriangle.DrawisoscelesTriangle(gP,p,objTriangle);
        }

        [TestMethod]
        public void DrawScaleneTriangle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsTriangle objTriangle = new clsTriangle();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objTriangle.DrawScaleneTriangle(gP,p,objTriangle);
        }

        [TestMethod]
        public void DrawEquilateralTriangle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsTriangle objTriangle = new clsTriangle();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objTriangle.DrawEquilateralTriangle(gP,p,objTriangle);
        }
    }
}
