using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Classes;
using System.Windows.Forms;

namespace JeylabTests
{
    [TestClass]
    public class clsPolygontest
    {
        [TestMethod]
        public void DrawOctagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objPolygon.DrawOctagon(gP,p,objPolygon);
        }


        [TestMethod]
        public void DrawParallelogram()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objPolygon.DrawParallelogram(gP,p,objPolygon);
        }

        [TestMethod]
        public void DrawPentagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objPolygon.DrawPentagon(gP,p,objPolygon);
        }

        [TestMethod]
        public void Drawhexagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objPolygon.Drawhexagon(gP,p,objPolygon);
        }

        [TestMethod]
        public void Drawheptagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            //Graphics gP = pnlCanvas.CreateGraphics();
            //Pen p = new Pen(Color.Red, 5);
            //objPolygon.Drawheptagon(gP,p,objPolygon);
        }
    }
}
