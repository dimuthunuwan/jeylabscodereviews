using Backend.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Classes
{
    public class clsCanvas : iCanvas
    {
        #region Methods
        /// <summary>
        /// method will clear painted canvas
        /// </summary>
        /// <param name="g"></param>
        public void ClearCanvas(Graphics g)
        {
            try
            {
                g.Clear(Color.White);
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
