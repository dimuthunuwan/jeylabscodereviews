using System;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Backend.Classes;
using System.Drawing;

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
            objTriangle.width = 100;
            objTriangle.height = 200;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objTriangle.DrawisoscelesTriangle(gP, p, objTriangle);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawScaleneTriangle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsTriangle objTriangle = new clsTriangle();
            objTriangle.sidelength1 = 250;
            objTriangle.sidelength2 = 100;
            objTriangle.sidelength3 = 250;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objTriangle.DrawScaleneTriangle(gP, p, objTriangle);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawEquilateralTriangle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsTriangle objTriangle = new clsTriangle();
            objTriangle.sidelength1 = 100;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objTriangle.DrawEquilateralTriangle(gP, p, objTriangle);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }
    }
}
