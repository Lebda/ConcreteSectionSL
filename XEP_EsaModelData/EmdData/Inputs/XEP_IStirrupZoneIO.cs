using System.Collections.Generic;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Inputs
{
    public interface XEP_IStirrupZoneIO
    {
        bool IsValid();
        List<List<Point>> Shapes { get; set; }
        int NumCut { get; set; }
        double StirrupDiameter { get; set; }
        double Spacing { get; set; }
    }
}