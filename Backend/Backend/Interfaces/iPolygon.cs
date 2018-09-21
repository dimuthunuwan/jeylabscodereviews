using Backend.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface iPolygon
    {
        #region Method signatures
        void DrawOctagon(Graphics g, Pen pen, clsPolygon objOctagon);

        void DrawParallelogram(Graphics g, Pen pen, clsPolygon objParallelogram);

        void DrawPentagon(Graphics g, Pen pen, clsPolygon objPentagon);

        void Drawhexagon(Graphics g, Pen pen, clsPolygon objHexagon);

        void Drawheptagon(Graphics g, Pen pen, clsPolygon objHeptagon); 
        #endregion
    }
}
