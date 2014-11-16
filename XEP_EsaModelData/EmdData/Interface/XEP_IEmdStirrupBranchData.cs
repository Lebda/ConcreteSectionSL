using System.Collections.Generic;
using System.Windows;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdStirrupBranchData : XEP_IEmdElemConventor
    {
        void CreateFrom(List<Point> shape);
        List<Point> Create();
    }
}