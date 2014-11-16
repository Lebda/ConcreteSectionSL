using System;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdNameValueData
    {
        XEP_IEmdAttribute CreateAttribute();
        string Name { get; set; }
        string Value { get; set; }
    }
}