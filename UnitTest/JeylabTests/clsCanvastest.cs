using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Classes;
using System.Drawing;
using Frontend;
using System.Windows.Forms;

namespace JeylabTests
{
    [TestClass]
    public class clsCanvastest
    {
        
        [TestMethod]
        public void ClearCanvas()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsCanvas objCanvas = new clsCanvas();
            Graphics gP = pnlCanvas.CreateGraphics(); ;
            objCanvas.ClearCanvas(gP);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }
    }
}
