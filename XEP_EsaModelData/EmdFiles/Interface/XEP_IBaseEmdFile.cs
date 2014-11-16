using System;
using System.IO;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    public interface XEP_IBaseEmdFile
    {
        void Load(Stream stream);
        void Save(Stream stream);
    }
}
