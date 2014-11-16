using System;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdPointData : XEP_IEmdElemConventor
    {
        double X { get; }
        double Y { get; }
        void CreateFrom(Point actPoint);
        Point Create();
    }
}