using System.Collections.Generic;
using XEP_EsaModelData.EmdData.Inputs;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    public interface XEP_IReinforcementEmdFile : XEP_IBaseEmdFile
    {
        void PrepareDocument(double sectionPos, string baseMaterial, double memberLenght);
        void SetBars(List<XEP_IBarIO> bars, int sectionID);
        void SetStirrupZoneIO(XEP_IStirrupZoneIO zoneIO);
        XEP_IStirrupZoneIO GetStirrupZoneIO();
        List<XEP_IBarIO> GetBars(int sectionID);
    }
}