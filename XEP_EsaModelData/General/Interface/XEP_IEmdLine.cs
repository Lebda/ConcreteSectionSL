using System;
using System.Collections.Generic;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.General.Interface
{
    internal interface XEP_IEmdLine
    {
        void CreateFakeRoot();
        void Parse(string line, int lineIndex);
        XEP_IEmdElement CreateEmdElement();
        void ReverseLines();
        List<XEP_IEmdLine> Lines { get; }
        int LineIndex { get; }
        int IntendationLevel { get; }
    }
}