using System;
using System.IO;

namespace XEP_EsaModelData.General.Interface
{
    internal interface XEP_IEmdFileReader
    {
        XEP_IEmdLine Root { get; }
        void Read(StreamReader reader);
    }
}
