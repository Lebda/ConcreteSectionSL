using System.Collections.Generic;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdStirrupZoneShapeData : XEP_IEmdElemConventor
    {
        void CreateFrom(List<List<Point>> shape);
        List<List<Point>> Create();
    }
}