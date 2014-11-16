using System;
using XEP_EsaModelData.EmdData.Inputs;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    public interface XEP_IStirrupZonePreparator
    {
        void SetStirrupZoneIO(XEP_IStirrupZoneIO zoneIO);
        XEP_IStirrupZoneIO GetStirrupZoneIO();
        void PrepareZones(XEP_IEmdElement reinf4Stirrups, double sectionPos, string matName, double zoneBeg, double zoneEnd);

    }
}