using System;
using System.Collections.Generic;
using XEP_EsaModelData.EmdData.Inputs;

namespace XEP_EsaModelData.EmdData.Interface
{
    public interface XEP_IEmdStirrupZoneData : XEP_IEmdElemConventor
    {
        void CreateFrom(XEP_IStirrupZoneIO zoneInput, double sectionPos, string matName, double zoneBeg, double zoneEnd, int zoneID);
        XEP_IStirrupZoneIO Create(double sectionPos);
        List<XEP_IEmdStirrupData> Stirrups { get; set; }
        XEP_IEmdStirrupZoneShapeData ZoneShape { get; set; }
        int ZoneID { get; set; }
        string Material { get; set; }
        double ZoneBeg { get; set; }
        double ZoneEnd { get; set; }
        int IsAutoCutsCalc { get; set; }
        int NumCutUser { get; set; }
        string Position { get; set; }
    }
}