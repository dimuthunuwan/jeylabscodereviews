using Backend.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface iTriangle
    {
        #region Method signatures
        void DrawisoscelesTriangle(Graphics g, Pen pen, clsTriangle objTriangle);

        void DrawScaleneTriangle(Graphics g, Pen pen, clsTriangle objTriangle);

        void DrawEquilateralTriangle(Graphics g, Pen pen, clsTriangle objTriangle); 
        #endregion
    }
}
