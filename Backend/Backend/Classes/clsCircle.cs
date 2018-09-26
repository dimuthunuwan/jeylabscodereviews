using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Interfaces;
using System.Drawing;
using Backend.Enum;

namespace Backend.Classes
{
    public class clsCircle : iCircle
    {

        #region Properties
        public float Radius { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public List<string> Languages { get; set; }
        #endregion

        #region Variables
        int intCenterx;
        int intCentery;
        #endregion


        #region Constructors
        public clsCircle()
        {
            intCenterx = (int)clsEnum.CenterXY.centerX;
            intCentery = (int)clsEnum.CenterXY.centerY;
            
        }
        #endregion

        #region Methods
        /// <summary>
        /// method will draw circle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objCircle"></param>
        public void DrawCircle(Graphics g, Pen pen, clsCircle objCircle)
        {

            try
            {
                g.DrawEllipse(pen, intCenterx - objCircle.Radius, intCentery - objCircle.Radius, objCircle.Radius + objCircle.Radius, objCircle.Radius + objCircle.Radius);
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
        /// <summary>
        /// method will draw oval
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objCircle"></param>
        public void DrawOval(Graphics g, Pen pen, clsCircle objCircle)
        {

            try
            {
                Rectangle oval = new Rectangle(intCenterx, intCentery, objCircle.width, objCircle.height);
                g.DrawEllipse(pen, oval);
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
