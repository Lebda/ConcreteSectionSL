using System;
using System.Windows;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdFibreData
    {
        void CreateFrom(Point actPoint);
        XEP_IEmdElement CreateEmdElement();
        int Flag { get; set; }
        XEP_IEmdLcsData Lcs { get; set; }
        XEP_IEmdPrincipalData Principal { get; set; }
    }
}