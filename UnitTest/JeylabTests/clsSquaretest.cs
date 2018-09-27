using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Backend.Classes;
using System.Drawing;

namespace JeylabTests
{
    [TestClass]
    public class clsSquaretest
    {
        [TestMethod]
        public void DrawSquare()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsSquare objSquare = new clsSquare();
            objSquare.width = 200;
            objSquare.height = 200;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objSquare.DrawSquare(gP, p, objSquare);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }


    }
}
