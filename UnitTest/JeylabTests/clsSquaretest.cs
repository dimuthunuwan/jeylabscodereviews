using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Windows.Forms;
using Backend.Classes;

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
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objSquare.DrawSquare(gP,p,objSquare);
        }

        
    }
}
