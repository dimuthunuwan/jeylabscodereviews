using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Classes;

namespace Backend.Interfaces
{
    public interface iCircle
    {
        #region Method signatures
        void DrawCircle(Graphics g, Pen pen, clsCircle objCircle);

        void DrawOval(Graphics g, Pen pen, clsCircle objCircle); 
        #endregion
    }
}
