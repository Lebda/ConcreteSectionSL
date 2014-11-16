using System.Collections.Generic;

namespace XEP_EsaModelData.General.Interface
{
    internal interface XEP_IEmdDom
    {
        XEP_IEmdLine Root { get; }
        void CreateDom(List<XEP_IEmdLine> linesEmd);
    }
}