using System;
using System.Collections.Generic;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdGeometryData : XEP_IEmdGeometryData
    {
        public XEP_EmdGeometryData()
        {
            Items = new List<XEP_IEmdNameValueData>();
        }

        #region PROPERTIES
        public List<XEP_IEmdNameValueData> Items { get; set; }
        #endregion

        #region INTERFACE IMPL
        public void CreateFrom(List<KeyValuePair<string, string>> items)
        {
            Items.Clear();
            foreach (var item in items)
            {
                XEP_IEmdNameValueData itemData = XEP_EmdReadWriteFactory.Instance().CreateEmdNameValueData();
                itemData.Name = item.Key;
                itemData.Value = item.Value;
                Items.Add(itemData);
            }
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement elem = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elem.Name = XEP_EmdNames.s_KeyGeometry;
            foreach (var item in Items)
            {
                elem.AddAttribute(item.CreateAttribute());
            }
            return elem;
        }
        #endregion
    }
}
