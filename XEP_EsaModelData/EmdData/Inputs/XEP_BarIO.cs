using System;

namespace XEP_EsaModelData.EmdData.Inputs
{
    internal class XEP_BarIO : XEP_IBarIO
    {
        public XEP_BarIO()
        {
            X = 0.0;
            Y = 0.0;
            D = 0.0;
            Area = 0.0;
        }

        public override string ToString()
        {
            return
                  "X: " + X.ToString() + "|" +
                  "Y: " + Y.ToString() + "|" +
                  "D: " + D.ToString() + "|" +
                  "Area: " + Area.ToString();
        }

        public double X { get; set; }
        public double Y { get; set; }
        public double D { get; set; }
        public double Area { get; set; }
    }
}
