using System.Collections.Generic;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdShapeData : XEP_IEmdElemConventor
    {
        List<Point> Create();
        void CreateFrom(List<Point> shape);
        List<XEP_IEmdPointData> Points { get; }
    }
}