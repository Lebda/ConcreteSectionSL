using System;
using System.Collections.Generic;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Inputs
{
    internal class XEP_StirrupZoneIO : XEP_IStirrupZoneIO
    {
        public XEP_StirrupZoneIO()
        {
            Shapes = new List<List<Point>>();
            NumCut = 2;
            StirrupDiameter = 0.0;
            Spacing = 0.0;
        }

        #region PROPERTIES
        public List<List<Point>> Shapes { get; set; }
        public int NumCut { get; set; }
        public double StirrupDiameter { get; set; }
        public double Spacing { get; set; }
        #endregion

        #region INTERFACE IMPL
        public bool IsValid()
        {
            if (NumCut < 1)
            {
                return false;
            }
            if (StirrupDiameter <= 0.0)
            {
                return false;  
            }
            if (Spacing <= 0.0)
            {
                return false;
            }
            if (Shapes == null)
            {
                return false;
            }
            foreach (var branch in Shapes)
            {
                if (branch == null || branch.Count < 3)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion
    }
}
