using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Classes;
using System.Drawing;
using Frontend;
using System.Windows.Forms;

namespace JeylabTests
{
    [TestClass]
    public class clsCircletest
    {
        

        [TestMethod]
        public void DrawCircle()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsCircle objCircle = new clsCircle();
            objCircle.Radius = 100;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objCircle.DrawCircle(gP,p,objCircle);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void DrawOval()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsCircle objCircle = new clsCircle();
            objCircle.width = 100;
            objCircle.height = 50;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objCircle.DrawOval(gP, p, objCircle);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);

        }
    }
}
