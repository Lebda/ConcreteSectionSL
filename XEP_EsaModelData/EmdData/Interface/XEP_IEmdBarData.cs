using System;
using XEP_EsaModelData.EmdData.Inputs;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdBarData : XEP_IEmdElemConventor
    {
        XEP_IBarIO Create();
        void CreateFrom(XEP_IBarIO barIO, int compID, string matName, int isActive, int isDetailing);
        int ComponentID { get; set; }
        double X { get; set; }
        double Y { get; set; }
        double D { get; set; }
        string RefMaterial { get; set; }
        int IsActive { get; set; }
        int IsDetailing { get; set; }
    }
}