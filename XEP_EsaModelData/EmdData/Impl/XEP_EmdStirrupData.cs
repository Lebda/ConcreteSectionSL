using System;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdStirrupData : XEP_IEmdStirrupData
    {
        public XEP_EmdStirrupData()
        {
            Clear();
        }

        #region PROPERTIES
        public double DX { get; set; }
        public double D { get; set; }
        public int Multiply { get; set; }
        public double DsL { get; set; }
        public double DsR { get; set; }
        public double Dss { get; set; }
        #endregion

        #region INTERFACE IMPL
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_EmdReadWriteFactory fac = XEP_EmdReadWriteFactory.Instance();
            XEP_IEmdElement elemEmd = fac.CreateEmdElement();
            elemEmd.Name = XEP_EmdNames.s_KeyStirrup;
            //
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupDX, DX.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupD, D.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupMultiply, Multiply.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupDsL, DsL.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupDsR, DsR.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupDss, Dss.ToString()));
            return elemEmd;
        }
        public void CreateFromEmdElement(XEP_IEmdElement elem)
        {
            XEP_BaseEmdFile.CheckName(elem.Name, XEP_EmdNames.s_KeyStirrup);
            DX = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupDX).GetDoubleValue();
            D = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupD).GetDoubleValue();
            Multiply = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupMultiply).GetIntValue();
            DsL = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupDsL).GetDoubleValue();
            DsR = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupDsR).GetDoubleValue();
            Dss = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupDss).GetDoubleValue();
        }
        #endregion

        #region METHODS PRIVATE
        private void Clear()
        {
            DX = 0.0;
            D = 0.0;
            Multiply = 0;
            DsL = 0.0;
            DsR = 0.0;
            Dss = 0.0;
        }
        #endregion
    }
}
