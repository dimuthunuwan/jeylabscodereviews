using Backend.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Backend.Interfaces;

namespace Frontend
{
    public partial class frmMain : Form
    {
        #region Variables
        Pen p = new Pen(Color.Red, 5);
        clsCircle objCircle = new clsCircle();
        iCanvas ifCanvas;
        iCircle ifCircle;
        iSquare ifSquare;
        iTriangle ifTriangle;
        iPolygon ifOctagon; 
        #endregion

        #region Default constructor
        public frmMain()
        {
            InitializeComponent();
        }
        #endregion

        #region events
        /// <summary>
        /// form load method will initialize all the controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                /** Reset all form controls**/
                Resetform();
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }

        /// <summary>
        /// Draw button click event fires all validations and render shapes on canvas according to parameters
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDraw_Click(object sender, EventArgs e)
        {
            String strNameofShape = Convert.ToString(txtNameofShape.Text).ToLower();
            string[] strReJoin = new string[30];
            String strReCorrectedString = String.Empty;
            String strErrMsg = String.Empty;
            Boolean blReturnVal;
            try
            {
                /** Check if there is any input parameter**/
                if (txtNameofShape.Text.Trim().Length > 0)
                {
                    /** one button used for draw shape and rest the form.differenciate by button text**/
                    if (btnDraw.Text == "Draw")
                    {
                        /** validate input parameters**/
                        if (blReturnVal = ValidateNameOfShape(strNameofShape, out strErrMsg))
                        {
                            /** if all validations are success program will correct and re-write the input parameters on text box**/
                            txtNameofShape.Text = Convert.ToString(strErrMsg);
                            /** all shapes draw using DrawShape method**/
                            DrawShape(strErrMsg);

                            btnDraw.Text = "Reset";
                        }
                        else/** if validation fail display the error message**/
                        {
                            lblErrMsg.Text = strErrMsg;
                            lblErrMsg.Visible = true;
                        }
                    }
                    else if (btnDraw.Text == "Reset")/** if button on reset mode**/
                    {
                        /** Reset all form controls**/
                        Resetform();
                    } 
                }
                else/** if input string is null or empty display message**/
                {
                    lblErrMsg.Text = "please enter input string."; ;
                    lblErrMsg.Visible = true;
                }

            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }


        #endregion

        #region Methods
        /// <summary>
        /// method will validate all input parameters according to accepted string format
        /// </summary>
        /// <param name="strNOS"></param>
        /// <param name="StrOutPutMsg"></param>
        /// <returns></returns>
        private Boolean ValidateNameOfShape(String strNOS, out String StrOutPutMsg)
        {
            Boolean blnIsSduccess = false;
            StrOutPutMsg = String.Empty;

            try
            {
                /*************************Remove all possible special characters from input string*********************************************/


                // Create  a string array and add the special characters you want to remove
                string[] chars = new string[] { ",", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "(", ")", ":", "|",
                    "[", "]","-","?","<",">","{","}","=","+","~" };
                //Iterate the number of times based on the String array length.
                for (int i = 0; i < chars.Length; i++)
                {
                    if (strNOS.Contains(chars[i]))
                    {
                        strNOS = strNOS.Replace(chars[i], "");
                    }
                }


                /******************************************************************************************************************************/

                /** split string by space and assign to string array**/
                string[] arrstr = SplitString(strNOS);

                /** validate string array**/
                if (arrstr != null && arrstr.Length > 0)
                {
                    switch (arrstr[2])
                    {
                        case "circle":/** if circle **/
                            float cleRadius;
                            if (float.TryParse(arrstr[7], out cleRadius))/** validate input circle radius is float value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "radius";
                                arrstr[6] = "of";
                                /** convert string array to string**/
                                StrOutPutMsg = MergeString(arrstr);
                                blnIsSduccess = true; 
                            }
                            else/** if input circle radius value is not float display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        case "square":/** if square**/
                            int sqsdlength;
                            if (int.TryParse(arrstr[8], out sqsdlength))/** validate input square side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "side";
                                arrstr[6] = "length";
                                arrstr[7] = "of";
                                /** convert string array to string**/
                                StrOutPutMsg = MergeString(arrstr);
                                blnIsSduccess = true; 
                            }
                            else/** if input square side length value is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        case "rectangle":/** if rectangle**/
                            int recWidth;
                            int recHeight;
                            if (int.TryParse(arrstr[7], out recWidth) && int.TryParse(arrstr[12], out recHeight))/** validate input rectangle width and height are int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                if (Convert.ToString(arrstr[5]).Contains("width"))
                                    arrstr[5] = "width";
                                else if (Convert.ToString(arrstr[5]).Contains("height"))
                                    arrstr[5] = "height";
                                else
                                    arrstr[5] = "width";
                                arrstr[6] = "of";
                                arrstr[8] = "and";
                                arrstr[9] = "a";
                                if (Convert.ToString(arrstr[10]).Contains("height"))
                                    arrstr[10] = "height";
                                else if (Convert.ToString(arrstr[10]).Contains("width"))
                                    arrstr[10] = "width";
                                else
                                    arrstr[10] = "height";
                                arrstr[11] = "of";
                                /** convert string array to string**/
                                StrOutPutMsg = MergeString(arrstr);
                                blnIsSduccess = true; 
                            }
                            else/** if input rectangle width and height value are not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        case "octagon":/** if octagon**/
                            int octlen;
                            if (int.TryParse(arrstr[8], out octlen))/** validate input octagon side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "an";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "side";
                                arrstr[6] = "length";
                                arrstr[7] = "of";
                                /** convert string array to string**/
                                StrOutPutMsg = MergeString(arrstr);
                                blnIsSduccess = true; 
                            }
                            else/** if input octagon side length value is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        case "isosceles":// if isosceles triangle
                            int itwidth;
                            int itheight;
                            if (int.TryParse(arrstr[8], out itheight) && int.TryParse(arrstr[13], out itwidth))/** validate input isosceles triangle width and height are int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "an";
                                arrstr[3] = "triangle";
                                arrstr[4] = "with";
                                arrstr[5] = "a";
                                if (Convert.ToString(arrstr[6]).Contains("height"))
                                    arrstr[6] = "height";
                                else if (Convert.ToString(arrstr[6]).Contains("width"))
                                    arrstr[6] = "width";
                                else
                                    arrstr[6] = "height";
                                arrstr[7] = "of";
                                arrstr[9] = "and";
                                arrstr[10] = "a";
                                if (Convert.ToString(arrstr[11]).Contains("width"))
                                    arrstr[11] = "width";
                                else if (Convert.ToString(arrstr[11]).Contains("height"))
                                    arrstr[11] = "height";
                                else
                                    arrstr[11] = "width";
                                arrstr[12] = "of";
                                /** convert string array to string**/
                                StrOutPutMsg = MergeString(arrstr);
                                blnIsSduccess = true; 
                            }
                            else/** if input isosceles triangle width and height are not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        //Assumption - the string on this format
                        //Draw a scalene triangle with a side lengths of 250 and 100 and 250
                        case "scalene":// if scalene triangle
                            int stSidelength1;
                            int stSidelength2;
                            int stSidelength3;
                            /** validate input scalene triangle side length 1,2,3  are int value**/
                            if (int.TryParse(arrstr[9], out stSidelength1) && int.TryParse(arrstr[11], out stSidelength2) && int.TryParse(arrstr[13], out stSidelength3))
                            {
                                if (stSidelength1 != 0 && stSidelength2 != 0 && stSidelength3 != 0 && /** validate input scalene triangle side length 1,2,3  are greater than zero and compatible**/
                                    ((stSidelength1 + stSidelength2) > stSidelength3) 
                                    && ((stSidelength1 + stSidelength3) > stSidelength2)
                                    && ((stSidelength2 + stSidelength3) > stSidelength1))
                                {
                                    /** Re-correct and rewrite input string**/
                                    arrstr[0] = "Draw";
                                    arrstr[1] = "a";
                                    arrstr[3] = "triangle";
                                    arrstr[4] = "with";
                                    arrstr[5] = "a";
                                    arrstr[6] = "side";
                                    arrstr[7] = "length";
                                    arrstr[8] = "of";
                                    arrstr[10] = "and";
                                    arrstr[12] = "and";
                                    /** convert string array to string**/
                                    StrOutPutMsg = MergeString(arrstr);
                                    blnIsSduccess = true;  
                                }
                                else/** if input scalene triangle side length 1,2,3 are not greater than zero and compatible, display error message**/
                                {
                                    StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                    blnIsSduccess = false;
                                }
                            }
                            else/** if input scalene triangle side length 1,2,3 are not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        //Assumption - the string on this format
                        //Draw a parallelogram with a side length of 250 and width of 100 and height of 250
                        case "parallelogram":// if parallelogram
                            int prSidelegth;
                            int prWidth;
                            int prHeight;
                            /** validate input parallelogram side length,width,height  are int value**/
                            if (int.TryParse(arrstr[8], out prSidelegth) && int.TryParse(arrstr[12], out prWidth) && int.TryParse(arrstr[16], out prHeight))
                            {
                                /** validate input parallelogram side length,width,height  are greater than zero and compatible**/
                                if (prSidelegth != 0 && prWidth != 0 && prHeight != 0 && ((prSidelegth + prHeight) > prWidth) &&
                                    ((prSidelegth + prWidth) > prHeight) && ((prHeight + prWidth) > prSidelegth))
                                {
                                    /** Re-correct and rewrite input string**/
                                    arrstr[0] = "Draw";
                                    arrstr[1] = "a";
                                    arrstr[2] = "parallelogram";
                                    arrstr[3] = "with";
                                    arrstr[4] = "a";
                                    arrstr[5] = "side";
                                    arrstr[6] = "length";
                                    arrstr[7] = "of";
                                    arrstr[9] = "and";
                                    arrstr[10] = "width";
                                    arrstr[11] = "of";
                                    arrstr[13] = "and";
                                    arrstr[14] = "height";
                                    arrstr[15] = "of";
                                    StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                    blnIsSduccess = true;  
                                }
                                else/** if input parallelogram side length,width,height are not greater than zero and compatible, display error message**/
                                {
                                    StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                    blnIsSduccess = false;
                                }
                            }
                            else/** if input parallelogram side length,width,height are not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;

                        //Assumption - the string on this format
                        //Draw an equilateral Triangle with a side length of 100
                        case "equilateral":// if Equilateral Triangle
                            int eqtSidelegth;
                            if (int.TryParse(arrstr[9], out eqtSidelegth))/** validate input Equilateral Triangle side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "an";
                                arrstr[3] = "triangle";
                                arrstr[4] = "with";
                                arrstr[5] = "a";
                                arrstr[6] = "side";
                                arrstr[7] = "length";
                                arrstr[8] = "of";
                                StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                blnIsSduccess = true; 
                            }
                            else/** if input Equilateral Triangle side length is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        //Assumption - the string on this format
                        //Draw a pentagon with a side length of 100
                        case "pentagon":// if pentagon
                            int ptSidelegth;
                            if (int.TryParse(arrstr[8], out ptSidelegth))/** validate input pentagon side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "side";
                                arrstr[6] = "length";
                                arrstr[7] = "of";
                                StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                blnIsSduccess = true; 
                            }
                            else/** if input pentagon side length is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;

                        //Assumption - the string on this format
                        //Draw a hexagon with a side length of 100
                        case "hexagon":// if hexagon
                            int hxnSideLength;
                            if (int.TryParse(arrstr[8], out hxnSideLength))/** validate input hexagon side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "side";
                                arrstr[6] = "length";
                                arrstr[7] = "of";
                                StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                blnIsSduccess = true; 
                            }
                            else/** if input hexagon side length is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        //Assumption - the string on this format
                        //Draw a heptagon with a side length of 100
                        case "heptagon":// if heptagon
                            int hpnSideLength;
                            if (int.TryParse(arrstr[8], out hpnSideLength))/** validate input heptagon side length is int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "a";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "side";
                                arrstr[6] = "length";
                                arrstr[7] = "of";
                                StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                blnIsSduccess = true;
                            }
                            else/** if input heptagon side length is not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;
                        //Assumption - the string on this format
                        //Draw an oval with a width of 100 and a height of 50
                        case "oval":// if oval
                            int ovwidth;
                            int ovheight;
                            if (int.TryParse(arrstr[7], out ovwidth) && int.TryParse(arrstr[12], out ovheight))/** validate input oval width and height are int value**/
                            {
                                /** Re-correct and rewrite input string**/
                                arrstr[0] = "Draw";
                                arrstr[1] = "an";
                                arrstr[3] = "with";
                                arrstr[4] = "a";
                                arrstr[5] = "width";
                                arrstr[6] = "of";
                                arrstr[8] = "and";
                                arrstr[9] = "a";
                                arrstr[10] = "height";
                                arrstr[11] = "of";
                                StrOutPutMsg = MergeString(arrstr);/** convert string array to string**/
                                blnIsSduccess = true; 
                            }
                            else/** if input oval width and height are not int, display error message**/
                            {
                                StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                                blnIsSduccess = false;
                            }
                            break;

                        default:/*** if input value does not belong to any of this, display error message ****/
                            StrOutPutMsg = "Invalid input parameter/s.please refer the expected string format.";
                            return blnIsSduccess;
                    }
                }
            }
            catch (OverflowException exofe)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (IndexOutOfRangeException exior)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            return blnIsSduccess;
        }
        /// <summary>
        /// split input string by space and fill it to string array
        /// </summary>
        /// <param name="strNOS"></param>
        /// <returns></returns>
        private string[] SplitString(String strNOS)
        {
            string[] arrstr = new string[50];
            try
            {
                strNOS.Split(new char[0], StringSplitOptions.RemoveEmptyEntries);// remove null or empty elements from array
                arrstr = strNOS.Split(new char[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (FormatException exfe)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            return arrstr;
        }
        /// <summary>
        /// merge all string array elements to single statement
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private String MergeString(string[] input)
        {
            String strReturn = String.Empty;

            try
            {
                strReturn = string.Join(" ", input);//add space between 2 words
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (FormatException exfe)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return strReturn;
        }

        /// <summary>
        /// method will draw required shape on canvas
        /// </summary>
        /// <param name="strInputVal"></param>
        private void DrawShape(String strInputVal)
        {
            try
            {
                /** split string by space and assign to string array**/
                string[] arrstr = SplitString(strInputVal.ToLower());

                /** validate string array**/
                if (arrstr != null && arrstr.Length > 0)
                {
                    switch (arrstr[2])
                    {
                        case "circle":/** if circle **/
                            DrawCircle(float.Parse(arrstr[7]));
                            break;
                        case "square":/** if square **/
                            DrawSquare(int.Parse(arrstr[8]));
                            break;
                        case "rectangle":/** if rectangle **/
                            int rectwidth;
                            int rectheight;
                            if (int.TryParse(arrstr[7], out rectwidth)) { }
                            if (int.TryParse(arrstr[12], out rectheight)) { }
                            if (rectwidth > 0 && rectheight > 0)
                                DrawRectangle(rectwidth, rectheight);
                            break;
                        case "octagon":/** if octagon **/
                            int octlength;
                            if (int.TryParse(arrstr[8], out octlength)) { }
                            DrawOctagon(octlength);
                            break;
                        case "isosceles"://if isosceles triangle
                            if (strInputVal.Contains("triangle"))
                            {
                                int itriwidth;
                                int itriheight;
                                if (int.TryParse(arrstr[8], out itriheight)) { }
                                if (int.TryParse(arrstr[13], out itriwidth)) { }
                                if (itriwidth > 0 && itriheight > 0)
                                    DrawisoscelesTriangle(itriwidth, itriheight);
                            }
                            break;


                        //Assumption - the string on this format
                        //Draw a scalene triangle with a side lengths of 250 and 100 and 250
                        case "scalene":// if Scalene Triangle
                            if (strInputVal.Contains("triangle"))
                            {
                                int sidelength1;
                                int sidelength2;
                                int sidelength3;

                                if (int.TryParse(arrstr[9], out sidelength1)) { }
                                if (int.TryParse(arrstr[11], out sidelength2)) { }
                                if (int.TryParse(arrstr[13], out sidelength3)) { }
                                if (sidelength1 > 0 && sidelength2 > 0 && sidelength3 > 0)
                                    DrawscaleneTriangle(sidelength1, sidelength2, sidelength3); 
                            }
                            break;

                        //Assumption - the string on this format
                        //Draw a parallelogram with a side length of 250 and width of 100 and height of 250
                        case "parallelogram":/** if parallelogram **/
                            int parsidelength;
                            int parwidth;
                            int parheight;

                            if (int.TryParse(arrstr[8], out parsidelength)) { }
                            if (int.TryParse(arrstr[12], out parwidth)) { }
                            if (int.TryParse(arrstr[16], out parheight)) { }

                            if (parsidelength > 0 && parwidth > 0 && parheight > 0)
                                DrawParallelogram(parsidelength, parwidth, parheight);
                            break;

                        //Assumption - the string on this format
                        //Draw a Equilateral Triangle with a side length of 100
                        case "equilateral":// if equilateral Triangle
                            int equsidelength;

                            if (int.TryParse(arrstr[9], out equsidelength)) { }

                            if (equsidelength > 0)
                                DrawEquilateralTriangle(equsidelength);

                            break;

                        //Assumption - the string on this format
                        //Draw a pentagon with a side length of 100
                        case "pentagon":/** if pentagon **/
                            int pensidelength;

                            if (int.TryParse(arrstr[8], out pensidelength)) { }

                            if (pensidelength > 0)
                                DrawPentagon(pensidelength);
                            break;

                        //Assumption - the string on this format
                        //Draw a hexagon with a side length of 100
                        case "hexagon":/** if hexagon **/
                            int hexsidelength;

                            if (int.TryParse(arrstr[8], out hexsidelength)) { }

                            if (hexsidelength > 0)
                                DrawHexagon(hexsidelength);
                            break;

                        //Assumption - the string on this format
                        //Draw a heptagon with a side length of 100
                        case "heptagon":/** if heptagon **/
                            int hepsidelength;

                            if (int.TryParse(arrstr[8], out hepsidelength)) { }

                            if (hepsidelength > 0)
                                DrawHeptagon(hepsidelength);
                            break;

                        //Assumption - the string on this format
                        //Draw an oval with a width of 100 and a height of 50
                        case "oval":/** if oval **/

                            int ovwidth;
                            int ovheight;
                            
                            if (int.TryParse(arrstr[7], out ovwidth)) { }
                            if (int.TryParse(arrstr[12], out ovheight)) { }
                            if (ovwidth > 0 && ovheight > 0)
                                DrawOval(ovwidth, ovheight);
                            break;

                        default:
                            break;
                    }
                }
            }
            catch (OverflowException exofe)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (IndexOutOfRangeException exior)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// method will draw with input radius
        /// </summary>
        /// <param name="Radius"></param>
        private void DrawCircle(float Radius)
        {
            
            try
            {

                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifCircle = new clsCircle();
                //crate circle object and fill value to property
                clsCircle objCircle = new clsCircle();
                objCircle.Radius = Radius;
                ifCircle.DrawCircle(gP, p, objCircle);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw square for given side length
        /// </summary>
        /// <param name="Sidelength"></param>
        private void DrawSquare(int Sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifSquare = new clsSquare();
                clsSquare objSquare = new clsSquare();//crate square object and fill value to property
                objSquare.width = Sidelength;
                objSquare.height = Sidelength;

                ifSquare.DrawSquare(gP, p, objSquare);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw rectangle by width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawRectangle(int width,int height)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifSquare = new clsSquare();
                clsSquare objSquare = new clsSquare();//crate square object and fill value to property
                objSquare.width = width;
                objSquare.height = height;

                ifSquare.DrawSquare(gP, p, objSquare);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw octagon by side length
        /// </summary>
        /// <param name="sidelength"></param>
        private void DrawOctagon(int sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifOctagon = new clsPolygon();
                clsPolygon objOctagon = new clsPolygon();//crate polygon object and fill value to property
                objOctagon.sidelength = sidelength;

                ifOctagon.DrawOctagon(gP, p, objOctagon);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw isosceles triangle by width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawisoscelesTriangle(int width,int height)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifTriangle = new clsTriangle();
                clsTriangle objTriangle = new clsTriangle();//crate triangle object and fill value to property
                objTriangle.width = width;
                objTriangle.height = height;

                ifTriangle.DrawisoscelesTriangle(gP,p,objTriangle);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw scalene triangle by side length 1,2,3
        /// </summary>
        /// <param name="sidelength1"></param>
        /// <param name="sidelength2"></param>
        /// <param name="sidelength3"></param>
        private void DrawscaleneTriangle(int sidelength1, int sidelength2,int sidelength3)
        {
            try
            {
               
                    Graphics gP = this.pnlCanvas.CreateGraphics();
                    ifTriangle = new clsTriangle();
                    clsTriangle objTriangle = new clsTriangle();//crate triangle object and fill value to property
                objTriangle.sidelength1 = sidelength1;
                    objTriangle.sidelength2 = sidelength2;
                    objTriangle.sidelength3 = sidelength3;

                    ifTriangle.DrawScaleneTriangle(gP, p, objTriangle); 
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw parallelogram by side length,width,height
        /// </summary>
        /// <param name="sidelength"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawParallelogram(int sidelength, int width, int height)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifOctagon = new clsPolygon();
                clsPolygon objParallelogram = new clsPolygon();//crate polygon object and fill value to property
                objParallelogram.sidelength = sidelength;
                objParallelogram.width = width;
                objParallelogram.height = height;

                ifOctagon.DrawParallelogram(gP, p, objParallelogram);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw equilateral triangle by side length
        /// </summary>
        /// <param name="sidelength"></param>
        private void DrawEquilateralTriangle(int sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifTriangle = new clsTriangle();
                clsTriangle objTriangle = new clsTriangle();//crate triangle object and fill value to property
                objTriangle.sidelength1 = sidelength;

                ifTriangle.DrawEquilateralTriangle(gP, p, objTriangle);
                
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw pentagon by side length
        /// </summary>
        /// <param name="sidelength"></param>
        private void DrawPentagon(int sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifOctagon = new clsPolygon();
                clsPolygon objPentagon = new clsPolygon();//crate polygon object and fill value to property
                objPentagon.sidelength = sidelength;

                ifOctagon.DrawPentagon(gP, p, objPentagon);
                
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw hexagon by side length
        /// </summary>
        /// <param name="sidelength"></param>
        private void DrawHexagon(int sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();
                ifOctagon = new clsPolygon();
                clsPolygon objHexagon = new clsPolygon();//crate polygon object and fill value to property
                objHexagon.sidelength = sidelength;

                ifOctagon.Drawhexagon(gP, p, objHexagon);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw heptagon
        /// </summary>
        /// <param name="sidelength"></param>
        private void DrawHeptagon(int sidelength)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();

                ifOctagon = new clsPolygon();
                clsPolygon objHeptagon = new clsPolygon();//crate polygon object and fill value to property
                objHeptagon.sidelength = sidelength;

                ifOctagon.Drawheptagon(gP, p, objHeptagon);
            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will draw oval by width and height
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        private void DrawOval(int width,int height)
        {
            try
            {
                Graphics gP = this.pnlCanvas.CreateGraphics();

                ifCircle = new clsCircle();

                clsCircle objCircle = new clsCircle();//crate circle object and fill value to property
                objCircle.width = width;
                objCircle.height = height;
                ifCircle.DrawOval(gP, p, objCircle);

            }
            catch (ArgumentNullException exanl)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (NullReferenceException exnr)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        /// <summary>
        /// method will reset/initialize all controls in form
        /// </summary>
        private void Resetform()
        {
            Graphics gP = this.pnlCanvas.CreateGraphics();
            try
            {
                txtNameofShape.Text = String.Empty;
                lblErrMsg.Visible = false;
                ifCanvas = new clsCanvas();
                ifCanvas.ClearCanvas(gP);//clear drawing canvas
                btnDraw.Text = "Draw";
            }
            catch (Exception ex)
            {
                lblErrMsg.Text = "Application error occured";
                lblErrMsg.Visible = true;
            }
        }
        #endregion

        
    }
}
