using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Backend.Classes;
using System.Windows.Forms;
using Backend.Enum;
using System.Drawing;

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
            objPolygon.sidelength = 100;
            objPolygon.NumOFsides = (int)clsEnum.NumberOfSidePerPolygon.octagon;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objPolygon.DrawPolygon(gP,p,objPolygon);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void DrawParallelogram()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            objPolygon.sidelength = 100;
            objPolygon.NumOFsides = (int)clsEnum.NumberOfSidePerPolygon.parallelogram;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objPolygon.DrawPolygon(gP, p, objPolygon);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DrawPentagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            objPolygon.sidelength = 100;
            objPolygon.NumOFsides = (int)clsEnum.NumberOfSidePerPolygon.pentagon;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objPolygon.DrawPolygon(gP, p, objPolygon);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drawhexagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            objPolygon.sidelength = 100;
            objPolygon.NumOFsides = (int)clsEnum.NumberOfSidePerPolygon.hexagon;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objPolygon.DrawPolygon(gP, p, objPolygon);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Drawheptagon()
        {
            Panel pnlCanvas = new System.Windows.Forms.Panel();
            clsPolygon objPolygon = new clsPolygon();
            objPolygon.sidelength = 100;
            objPolygon.NumOFsides = (int)clsEnum.NumberOfSidePerPolygon.heptagon;
            Graphics gP = pnlCanvas.CreateGraphics();
            Pen p = new Pen(Color.Red, 5);
            objPolygon.DrawPolygon(gP, p, objPolygon);

            //Assert.Fail();
            //Assert.AreEqual(expected, actual);
        }
    }
}
