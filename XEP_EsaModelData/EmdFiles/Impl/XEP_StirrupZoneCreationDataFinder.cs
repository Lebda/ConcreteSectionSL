using System;
using System.Collections.Generic;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_StirrupZoneCreationDataFinder : XEP_IStirrupZoneCreationDataFinder
    {
        public XEP_StirrupZoneCreationDataFinder()
        {
            _zoneID = -1;
            _materialName = String.Empty;
            _zoneMatch = null;
        }

        #region MEMBERS
        private int _zoneID;
        private string _materialName;
        XEP_IEmdElement _zoneMatch;
        #endregion

        #region PROPERTIES
        #endregion

        #region INTERFACE IMPL
        public XEP_IEmdElement ZoneMatch
        {
            get { return _zoneMatch; }
        }
        public string MaterialName
        {
            get { return _materialName; }
        }
        public int ZoneID
        {
            get { return _zoneID; }
        }
        public void FindData(XEP_IEmdElement reinf4Stirrups)
        {
            _zoneID = -1;
            _materialName = String.Empty;
            _zoneMatch = null;
            XEP_BaseEmdFile.CheckName(reinf4Stirrups.Name, XEP_EmdNames.s_KeyReinforcement);
            List<XEP_IEmdElement> domStirrupZones = XEP_BaseEmdFile.GetElements(reinf4Stirrups, XEP_EmdNames.s_KeyStirrupZone);
            XEP_BaseEmdFile.RemoveElements(reinf4Stirrups, XEP_EmdNames.s_KeyStirrupZone);
            if (domStirrupZones == null || domStirrupZones.Count == 0)
            {
                return;
            }
            foreach (var zone in domStirrupZones)
            {
                if (FindInZone(zone))
                {
                    _zoneMatch = zone;
                    break;
                }
            }
        }
        #endregion

        #region METHODS PRIVATE
        private bool FindInZone(XEP_IEmdElement domStirrupZone)
        {
            XEP_BaseEmdFile.CheckName(domStirrupZone.Name, XEP_EmdNames.s_KeyStirrupZone);
            if (domStirrupZone.GetAttribute(XEP_EmdNames.s_KeyStirrupZonePosition).Value != XEP_EmdNames.s_Value_ZonePosCurrent)
            {
                return false;
            }
            _zoneID = domStirrupZone.GetAttribute(XEP_EmdNames.s_KeyStirrupZoneID).GetIntValue();
            _materialName = domStirrupZone.GetAttribute(XEP_EmdFileConstants.s_RefAttributEmdTag + XEP_EmdNames.s_KeyStirrupZoneMaterial).Value;
            return true;
        }
        #endregion
    }
}
