using System;

namespace XEP_EsaModelData.General.Interface
{
    public interface XEP_IEmdIntendationGetter
    {
        int IntendationLevel { get; set; }
        string GetIntendation();
    }
}