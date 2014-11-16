using System.Windows;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdPrincipalData : XEP_IEmdElemConventor
    {
        void CreateFrom(Point actPoint);
        Point Create();
        double y { get; }
        double z { get; }
    }
}