using System.Collections.Generic;
using System.Windows;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdFibresData
    {
        void CreateFrom(List<Point> fibres);
        XEP_IEmdElement CreateEmdElement();
    }
}