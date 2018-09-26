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
        public int width { get; set; }
        public int height { get; set; }
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
        /// method will draw octagon
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objOctagon"></param>
        public void DrawOctagon(Graphics g, Pen pen, clsPolygon objOctagon)
        {
            try
            {
                
                PointF[] verticies = CalculateVertices(8, objOctagon.sidelength);
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
        /// method will calculate degree to radian
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        private static double DegreeToRadian(double angle)
        {
            try
            {
                return Math.PI * angle / 180.0;
            }
            catch (MissingMemberException mmex)
            {
                throw mmex;
            }
            catch (MemberAccessException maex)
            {
                throw maex;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// method will draw parallelogram
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objParallelogram"></param>
        public void DrawParallelogram(Graphics g, Pen pen, clsPolygon objParallelogram)
        {
            try
            {

                //  Pointer array define
                PointF[] verticies = CalculateVertices(4, objParallelogram.sidelength);
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
        /// method will draw pentagon
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objPentagon"></param>
        public void DrawPentagon(Graphics g, Pen pen, clsPolygon objPentagon)
        {
            try
            {
                //  Pointer array define
                PointF[] verticies = CalculateVertices(5, objPentagon.sidelength);
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

        private PointF[] CalculateVertices(int sides, int radius)
        {
            if (sides < 3)
                throw new ArgumentException("Polygon must have 3 sides or more.");

            Point center = new Point();
            center.X = intCenterx;
            center.Y = intCentery;

            int startingAngle = 90;

            List<PointF> points = new List<PointF>();
            float step = 360.0f / sides;

            float angle = startingAngle; //starting angle
            for (double i = startingAngle; i < startingAngle + 360.0; i += step) //go in a full circle
            {
                points.Add(DegreesToXY(angle, radius, center)); //code snippet from above
                angle += step;
            }

            return points.ToArray();
        }

        /// <summary>
        /// Calculates a point that is at an angle from the origin (0 is to the right)
        /// </summary>
        private PointF DegreesToXY(float degrees, float radius, Point origin)
        {
            PointF xy = new PointF();
            double radians = degrees * Math.PI / 180.0;

            xy.X = (float)Math.Cos(radians) * radius + origin.X;
            xy.Y = (float)Math.Sin(-radians) * radius + origin.Y;

            return xy;
        }

        /// <summary>
        /// method will draw hexagon
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objHexagon"></param>
        public void Drawhexagon(Graphics g, Pen pen, clsPolygon objHexagon)
        {
            try
            {
                //  Pointer array define
                PointF[] verticies = CalculateVertices(6, objHexagon.sidelength);
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
        /// method will draw heptagon
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objHeptagon"></param>
        public void Drawheptagon(Graphics g, Pen pen, clsPolygon objHeptagon)
        {
            try
            {
                //  Pointer array define
                PointF[] verticies = CalculateVertices(7, objHeptagon.sidelength);
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
        #endregion
    }
}
