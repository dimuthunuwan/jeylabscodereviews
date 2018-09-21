using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Classes
{
    public class clsTriangle : iTriangle
    {
        #region Properties

        public int width { get; set; }
        public int height { get; set; }
        public int sidelength1 { get; set; }
        public int sidelength2 { get; set; }
        public int sidelength3 { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// method will draw isosceles triangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objTriangle"></param>
        public void DrawisoscelesTriangle(Graphics g, Pen pen, clsTriangle objTriangle)
        {
            try
            {
                //  Pointer array define
                PointF[] pnt = new PointF[3];

                //calculate each pointers x and y position
                pnt[0].X = 50 + objTriangle.width / 2;
                pnt[0].Y = 50;

                pnt[1].X = 50;
                pnt[1].Y = 50 + objTriangle.height;

                pnt[2].X = 50 + objTriangle.width;
                pnt[2].Y = 50 + objTriangle.height;

                g.DrawPolygon(pen, pnt);
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
        /// method will draw scalene triangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objTriangle"></param>
        public void DrawScaleneTriangle(Graphics g, Pen pen, clsTriangle objTriangle)
        {
            try
            {
                
                    //  Pointer array define
                    Point[] pnt = new Point[3];
                    //Assume value3 is the max side length;
                    //  This is the total length/2
                    int p = (objTriangle.sidelength1 + objTriangle.sidelength2 + objTriangle.sidelength3) / 2;
                    //  S = SQRT[P * ( P - m ) * ( P - n ) * ( P - x - y )]; This is area
                    //  S = 1/2( x + y )h;  This is area
                    //  h = {SQRT[P * ( P - m ) * ( P - n ) * ( P - x - y )]} * 2/( x + y ); This is height

                    //  Find the max and mix side length in case of Height out side of the triangle!.
                    int[] array = { objTriangle.sidelength1, objTriangle.sidelength2, objTriangle.sidelength3 };
                    int valueMax = array.Max();
                    int valueMin = array.Min();

                    //  Get the height for lengh(Max);
                    int h = Convert.ToInt32(Math.Sqrt(p * (p - objTriangle.sidelength1) * (p - objTriangle.sidelength2) * (p - objTriangle.sidelength3)) * 2 / valueMax);

                //calculate each pointers x and y position
                pnt[0].X = 50 + Convert.ToInt32(Math.Sqrt(Math.Pow(valueMin, 2) - Math.Pow(h, 2)));
                    pnt[0].Y = 50;

                    pnt[1].X = 50;
                    pnt[1].Y = 50 + h;

                    pnt[2].X = 50 + valueMax;
                    pnt[2].Y = 50 + h;

                    g.DrawPolygon(pen, pnt);
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
        /// method will draw equilateral triangle
        /// </summary>
        /// <param name="g"></param>
        /// <param name="pen"></param>
        /// <param name="objTriangle"></param>
        public void DrawEquilateralTriangle(Graphics g, Pen pen, clsTriangle objTriangle)
        {
            try
            {
                //  Pointer array define
                Point[] pnt = new Point[3];
                
                //calculate each pointers x and y position
                pnt[0].X = 50 + Convert.ToInt32(objTriangle.sidelength1 / Math.Sqrt(3));
                pnt[0].Y = 50;

                pnt[1].X = 50;
                pnt[1].Y = 50 + objTriangle.sidelength1;

                pnt[2].X = 50 + Convert.ToInt32(2 * (objTriangle.sidelength1 / Math.Sqrt(3)));
                pnt[2].Y = 50 + objTriangle.sidelength1;

                g.DrawPolygon(pen, pnt);
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
