using System;
using System.Linq;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    internal interface XEP_IReinf4BarsProxy
    {
        XEP_IEmdElement Reinf4Bars { get; }
        int SectionID { set; }
    }
}