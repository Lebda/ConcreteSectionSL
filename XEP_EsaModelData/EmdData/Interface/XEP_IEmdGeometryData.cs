using System.Collections.Generic;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdGeometryData
    {
        void CreateFrom(List<KeyValuePair<string, string>> items);
        XEP_IEmdElement CreateEmdElement();
    }
}