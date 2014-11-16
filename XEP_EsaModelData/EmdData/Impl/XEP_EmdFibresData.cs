using System;
using System.Collections.Generic;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdFibresData : XEP_IEmdFibresData
    {
        public XEP_EmdFibresData()
        {
            Fibres = new List<XEP_IEmdFibreData>();
        }

        #region PROPERTIES
        public List<XEP_IEmdFibreData> Fibres { get; set; }
        #endregion

        #region INTERFACE IMPL
        public void CreateFrom(List<Point> fibres)
        {
            Fibres.Clear();
            foreach (var item in fibres)
            {
                XEP_IEmdFibreData fibreData = XEP_EmdReadWriteFactory.Instance().CreateEmdFibreData();
                fibreData.CreateFrom(item);
                Fibres.Add(fibreData);
            }
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement elem = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elem.Name = XEP_EmdNames.s_KeyFibres;
            foreach (var item in Fibres)
            {
                elem.Elements.Add(item.CreateEmdElement());
            }
            return elem;
        }
        #endregion
    }
}
