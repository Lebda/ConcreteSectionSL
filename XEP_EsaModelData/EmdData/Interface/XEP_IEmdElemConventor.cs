using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdElemConventor
    {
        void CreateFromEmdElement(XEP_IEmdElement elem);
        XEP_IEmdElement CreateEmdElement();
    }
}