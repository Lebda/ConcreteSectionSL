using System;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.EmdFiles.Interface
{
    public interface XEP_IStirrupZoneCreationDataFinder
    {
        XEP_IEmdElement ZoneMatch { get; }
        string MaterialName { get; }
        int ZoneID { get; }
        void FindData(XEP_IEmdElement reinf4Stirrups);
    }
}