namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdStirrupData : XEP_IEmdElemConventor
    {
        double DX { get; set; }
        double D { get; set; }
        int Multiply { get; set; }
        double DsL { get; set; }
        double DsR { get; set; }
        double Dss { get; set; }
    }
}