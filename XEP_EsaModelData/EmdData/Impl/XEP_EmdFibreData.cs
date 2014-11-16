using System;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdFibreData : XEP_IEmdFibreData
    {
        public XEP_EmdFibreData()
        {
            Flag = 0;
            Lcs = XEP_EmdReadWriteFactory.Instance().CreateEmdLcsData();
            Principal = XEP_EmdReadWriteFactory.Instance().CreateIEmdPrincipalData();
        }

        #region PROPERTIES
        public int Flag { get; set; }
        public XEP_IEmdLcsData Lcs { get; set; }
        public XEP_IEmdPrincipalData Principal { get; set; }
        #endregion

        #region INTERFACE IMPL
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement elemEmd = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elemEmd.Name = XEP_EmdNames.s_KeyFibre;
            XEP_IEmdAttribute attEmd = XEP_EmdReadWriteFactory.Instance().CreateEmdAttribute();
            attEmd.Name = XEP_EmdNames.s_KeyFlag;
            attEmd.Value = Flag.ToString();
            elemEmd.AddAttribute(attEmd);
            //
            elemEmd.Elements.Add(Lcs.CreateEmdElement());
            elemEmd.Elements.Add(Principal.CreateEmdElement());
            return elemEmd;
        }
        public void CreateFrom(Point actPoint)
        {
            Flag = 0;
            Lcs.CreateFrom(actPoint);
            Principal.CreateFrom(actPoint);
        }
        #endregion
    }
}
