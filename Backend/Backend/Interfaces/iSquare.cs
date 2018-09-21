using Backend.Classes;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Interfaces
{
    public interface iSquare
    {
        #region Method signatures
        void DrawSquare(Graphics g, Pen pen, clsSquare objSquare); 
        #endregion
    }
}
