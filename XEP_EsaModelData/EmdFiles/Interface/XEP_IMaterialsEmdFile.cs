using System;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    public interface XEP_IMaterialsEmdFile : XEP_IBaseEmdFile
    {
        string GetBaseMaterial(string matNameEnum);
    }
}