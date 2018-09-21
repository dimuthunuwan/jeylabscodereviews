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
                //  Pointer array define
                Point[] pnt = new Point[8];

                int r = Convert.ToInt32(objOctagon.sidelength / (2 * Math.Sin(DegreeToRadian(360 / 16))));
                //  Law of cosines:  c^{2}=a^{2}+b^{2}-2ab\cos(C);
                int maxW = Convert.ToInt32(r * 2 * Math.Cos(DegreeToRadian(45 / 2)));
                int minW = Convert.ToInt32(Math.Sqrt(2 * Math.Pow(r, 2)));
                int extraW = Convert.ToInt32((Math.Sin(DegreeToRadian(45 / 2))) * objOctagon.sidelength);
                //calculate each pointers x and y position
                pnt[0].X = 50;
                pnt[0].Y = 450 + r;

                pnt[1].X = 50 + extraW;
                pnt[1].Y = 450 + extraW;

                pnt[2].X = 50 + r;
                pnt[2].Y = 450;

                pnt[3].X = 50 + 2 * r - extraW;
                pnt[3].Y = 450 + extraW;

                pnt[4].X = 50 + 2 * r;
                pnt[4].Y = 450 + r;

                pnt[5].X = 50 + 2 * r - extraW;
                pnt[5].Y = 450 + 2 * r - extraW;

                pnt[6].X = 50 + r;
                pnt[6].Y = 450 + 2 * r;

                pnt[7].X = 50 + extraW;
                pnt[7].Y = 450 + 2 * r - extraW;

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
                    Point[] pnt = new Point[4];
                    int part = Convert.ToInt32(Math.Sqrt((Math.Pow(objParallelogram.sidelength, 2) - Math.Pow(objParallelogram.height, 2))));
                //calculate each pointers x and y position
                pnt[0].X = 450 + part;
                    pnt[0].Y = 50;

                    pnt[1].X = 450 + part + objParallelogram.width;
                    pnt[1].Y = 50;

                    pnt[2].X = 450 + objParallelogram.width;
                    pnt[2].Y = 50 + objParallelogram.height;

                    pnt[3].X = 450;
                    pnt[3].Y = 50 + objParallelogram.height;

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
                Point[] pnt = new Point[5];
                int h = Convert.ToInt32(objPentagon.sidelength * Math.Sqrt(5 + 2 * Math.Sqrt(5)) / 2);
                int w = Convert.ToInt32(objPentagon.sidelength * (1 + Math.Sqrt(5)) / 2);
                int h2 = Convert.ToInt32(Math.Sqrt(Math.Pow(objPentagon.sidelength, 2) - Math.Pow(w / 2, 2)));
                //calculate each pointers x and y position
                pnt[0].X = 50;
                pnt[0].Y = 450 + h2;

                pnt[1].X = 50 + w / 2;
                pnt[1].Y = 450;

                pnt[2].X = 50 + w;
                pnt[2].Y = 450 + h2;

                pnt[3].X = 50 + w - (w - objPentagon.sidelength) / 2;
                pnt[3].Y = 450 + h;

                pnt[4].X = 50 + (w - objPentagon.sidelength) / 2;
                pnt[4].Y = 450 + h;


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
                Point[] pnt = new Point[6];
                int h = Convert.ToInt32(Math.Sqrt(3) * objHexagon.sidelength);
                int w = 2 * objHexagon.sidelength;
                //calculate each pointers x and y position
                pnt[0].X = 50;
                pnt[0].Y = 450 + h / 2;

                pnt[1].X = 50 + objHexagon.sidelength / 2;
                pnt[1].Y = 450;

                pnt[2].X = Convert.ToInt32(50 + (objHexagon.sidelength * 1.5));
                pnt[2].Y = 450;

                pnt[3].X = 50 + w;
                pnt[3].Y = 450 + h / 2;

                pnt[4].X = Convert.ToInt32(50 + (objHexagon.sidelength * 1.5));
                pnt[4].Y = 450 + h;

                pnt[5].X = 50 + objHexagon.sidelength / 2;
                pnt[5].Y = 450 + h;

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
                Point[] pnt = new Point[7];

                int r = Convert.ToInt32(objHeptagon.sidelength / (2 * Math.Sin(DegreeToRadian(360 / 14))));
                int h = Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) - Math.Pow(objHeptagon.sidelength / 2, 2)));
                //  Law of cosines:  c^{2}=a^{2}+b^{2}-2ab\cos(C);
                int maxW = Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) * (2 - 2 * Math.Cos(DegreeToRadian(1080 / 7)))));
                int minW = Convert.ToInt32(Math.Sqrt(Math.Pow(r, 2) * (2 - 2 * Math.Cos(DegreeToRadian(720 / 7)))));
                int extraW = Convert.ToInt32(objHeptagon.sidelength * Math.Cos(DegreeToRadian(180 - 900 / 7)));

                //  Mid Height and Min Height
                int h2 = Convert.ToInt32((Math.Pow(r, 2) / minW) * Math.Sin(DegreeToRadian(720 / 7)));
                int h3 = Convert.ToInt32((Math.Pow(r, 2) / maxW) * Math.Sin(DegreeToRadian(1080 / 7)));

                //calculate each pointers x and y position
                pnt[0].X = 50;
                pnt[0].Y = 450 + r + h3;

                pnt[1].X = 50 + (maxW - minW) / 2;
                pnt[1].Y = 450 + r - h2;

                pnt[2].X = 50 + maxW / 2;
                pnt[2].Y = 450;

                pnt[3].X = 50 + maxW - (maxW - minW) / 2;
                pnt[3].Y = 450 + r - h2;

                pnt[4].X = 50 + maxW;
                pnt[4].Y = 450 + r + h3;

                pnt[5].X = 50 + objHeptagon.sidelength + extraW;
                pnt[5].Y = 450 + r + h;

                pnt[6].X = 50 + extraW;
                pnt[6].Y = 450 + r + h;

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
