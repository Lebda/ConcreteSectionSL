using System;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdNameValueData : XEP_IEmdNameValueData
    {
        public XEP_EmdNameValueData()
        {
            Name = String.Empty;
            Value = String.Empty;
        }

        #region PROPERTIES
        public string Name { get; set; }
        public string Value { get; set; }
        #endregion

        #region INTERFACE IMPL
        public XEP_IEmdAttribute CreateAttribute()
        {
            XEP_IEmdAttribute attEmd = XEP_EmdReadWriteFactory.Instance().CreateEmdAttribute();
            attEmd.Name = Name;
            attEmd.Value = Value;
            return attEmd;
        }
        #endregion
    }
}
