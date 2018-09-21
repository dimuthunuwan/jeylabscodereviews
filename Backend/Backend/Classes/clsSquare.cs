using Backend.Enum;
using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Classes
{
    public class clsSquare : iSquare
    {
        #region Properties
        
        public int width { get; set; }
        public int height { get; set; }
        #endregion

        #region Variables
        int intCenterx;
        int intCentery;
        #endregion

        #region Constructors
        public clsSquare()
        {
            intCenterx = (int)clsEnum.CenterXY.centerX;
            intCentery = (int)clsEnum.CenterXY.centerY;
        }
        #endregion


        #region Methods
        /// <summary>
        /// method will draw square
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objSquare"></param>
        public void DrawSquare(Graphics g, Pen pen, clsSquare objSquare)
        {
            try
            {
                g.DrawRectangle(pen, intCenterx, intCentery, objSquare.width, objSquare.height);
                g.Dispose();//dispose object
            }
            catch (ArgumentNullException exanl)
            {
                throw exanl;
            }
            catch (NullReferenceException exnr)
            {
                throw exnr;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        } 
        #endregion
    }
}
