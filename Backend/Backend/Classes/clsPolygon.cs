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
    public class clsPolygon : iPolygon
    {
        #region Properties
        public int sidelength { get; set; }
        
        public int NumOFsides { get; set; }
        #endregion

        #region Variables
        int intCenterx;
        int intCentery;
        #endregion

        #region Constructors
        public clsPolygon()
        {
            intCenterx = (int)clsEnum.CenterXY.centerX;
            intCentery = (int)clsEnum.CenterXY.centerY;

        }
        #endregion

        #region Methods
        
        /// <summary>
        /// method will draw polygons including parallelogram,pentagon,hexagon,heptagon,octagon
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objOctagon"></param>
        /// <param name="sides"></param>
        public void DrawPolygon(Graphics g, Pen pen, clsPolygon objOctagon)
        {
            try
            {
                PointF[] verticies = CalculateVertices(objOctagon.NumOFsides, objOctagon.sidelength);
                g.DrawPolygon(pen, verticies);
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
        /// method will calculate vertices for each polygon shape
        /// </summary>
        /// <param name="sides"></param>
        /// <param name="radius"></param>
        /// <returns></returns>
        private PointF[] CalculateVertices(int sides, int radius)
        {
            List<PointF> points = new List<PointF>();
            try
            {
                
                Point center = new Point();
                center.X = intCenterx;
                center.Y = intCentery;

                int startingAngle = (int)clsEnum.startingAngle.intstartingAngle;

                
                float step = 360.0f / sides;

                float angle = startingAngle; //starting angle
                for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a full circle
                {
                    points.Add(DegreesToXY(angle, radius, center)); //code snippet from above
                    angle += step;
                }
            }
            catch (ArgumentNullException exanl)
            {
                throw exanl;
            }
            catch (NullReferenceException exnr)
            {
                throw exnr;
            }
            catch (ArgumentException argex)
            {
                throw argex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Calculates a point that is at an angle from the origin (0 is to the right)
        /// </summary>
        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            try
            {
                PointF xy = new PointF();
                double radians = degrees * Math.PI / 180.0;

                xy.X = (float)Math.Cos(radians) * radius + origin.X;
                xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;

                return xy;
            }
            catch (ArgumentNullException exanl)
            {
                throw exanl;
            }
            catch (NullReferenceException exnr)
            {
                throw exnr;
            }
            catch (ArgumentException argex)
            {
                throw argex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
        #endregion
    }
}
