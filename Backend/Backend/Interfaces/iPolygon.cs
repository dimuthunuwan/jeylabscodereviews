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

        void DrawPolygon(Graphics g, Pen pen, clsPolygon objPolygon);
        
        #endregion
    }
}
