using System;
using System.Collections.Generic;
using System.Linq;
using XEP_EsaModelData.EmdData.Inputs;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_StirrupZonePreparator : XEP_IStirrupZonePreparator
    {
        public XEP_StirrupZonePreparator()
        {
            _zone4Work = XEP_EmdReadWriteFactory.Instance().CreateEmdStirrupZoneData();
            _zonesBefore = new List<XEP_IEmdElement>();
            _zonesAfter = new List<XEP_IEmdElement>();
            _sectionPos = 0.0;
            _zoneBeg = 0.0;
            _zoneEnd = 0.0;
            _baseMat = String.Empty;
            _reinf4Stirrups = null;
        }

        #region MEMBERS
        static readonly int s_zoneIDstatic = 666;
        readonly List<XEP_IEmdElement> _zonesBefore;
        readonly List<XEP_IEmdElement> _zonesAfter;
        XEP_IEmdStirrupZoneData _zone4Work;
        double _sectionPos;
        double _zoneBeg;
        double _zoneEnd;
        string _baseMat;
        XEP_IEmdElement _reinf4Stirrups;
        #endregion

        #region INTERFACE IMPL
        public void SetStirrupZoneIO(XEP_IStirrupZoneIO zoneIO)
        {
            if (_zone4Work == null)
            {
                throw new InvalidOperationException("Zone4Work was not created, please call 'PrepareZones' ");
            }
            _zone4Work.CreateFrom(zoneIO, _sectionPos, _baseMat, _zoneBeg, _zoneEnd, _zone4Work.ZoneID);
            XEP_BaseEmdFile.RemoveElements(_reinf4Stirrups, XEP_EmdNames.s_KeyStirrupZone);
            if (zoneIO.IsValid())
            {
                foreach (var zone in _zonesBefore)
                {
                    _reinf4Stirrups.Elements.Add(zone);
                }
                _reinf4Stirrups.Elements.Add(_zone4Work.CreateEmdElement());
                foreach (var zone in _zonesAfter)
                {
                    _reinf4Stirrups.Elements.Add(zone);
                }   
            }
        }
        public XEP_IStirrupZoneIO GetStirrupZoneIO()
        {
            if (_zone4Work == null)
            {
               throw new InvalidOperationException("Zone4Work was not created, please call 'PrepareZones' ");             
            }
            return _zone4Work.Create(_sectionPos);
        }
        public void PrepareZones(XEP_IEmdElement reinf4Stirrups, double sectionPos, string baseMat, double zoneBeg, double zoneEnd)
        {
            _zonesBefore.Clear();
            _zonesAfter.Clear();
            _zone4Work = null;
            _sectionPos = sectionPos;
            _baseMat = baseMat;
            _zoneBeg = zoneBeg;
            _zoneEnd = zoneEnd;
            _reinf4Stirrups = reinf4Stirrups;
            XEP_BaseEmdFile.CheckName(_reinf4Stirrups.Name, XEP_EmdNames.s_KeyReinforcement);
            List<XEP_IEmdElement> domStirrupZones = XEP_BaseEmdFile.GetElements(_reinf4Stirrups, XEP_EmdNames.s_KeyStirrupZone);
            if (domStirrupZones == null || domStirrupZones.Count == 0)
            {
                PrepareZone4NoZones();
                return;
            }
            XEP_BaseEmdFile.RemoveElements(_reinf4Stirrups, XEP_EmdNames.s_KeyStirrupZone);
            List<XEP_IEmdElement> currentZoneCandidates = new List<XEP_IEmdElement>();
            SortZones(domStirrupZones, currentZoneCandidates);
            domStirrupZones.Clear();
            if (currentZoneCandidates.Count == 0)
            {
                PrepareZone4NoZones();
            }
            else if (currentZoneCandidates.Count == 1)
            {
                PrepareZoneFromElement(currentZoneCandidates[0]);
            }
            else
            {
                bool wasMatch = false;
                foreach (var zone in currentZoneCandidates)
                {
                    double actZoneBeg = zone.GetAttribute(XEP_EmdNames.s_KeyStirrupZoneZoneBeg).GetDoubleValue();
                    double actZoneEnd = zone.GetAttribute(XEP_EmdNames.s_KeyStirrupZoneZoneEnd).GetDoubleValue();
                    if (sectionPos > actZoneBeg && sectionPos < actZoneEnd)
                    {
                        PrepareZoneFromElement(zone);
                        wasMatch = true;
                        break;
                    }
                }
                if (!wasMatch)
                {
                    PrepareZoneFromElement(currentZoneCandidates[0]);
                }
            }
            if (_zone4Work == null)
            {
                PrepareZone4NoZones();
            }
        }
        #endregion

        #region PRIVATE
        private void SortZones(List<XEP_IEmdElement> domStirrupZones, List<XEP_IEmdElement> currentZoneCandidates)
        {
            foreach (var zone in domStirrupZones)
            {
                string position = zone.GetAttribute(XEP_EmdNames.s_KeyStirrupZonePosition).Value;
                if (position == XEP_EmdNames.s_Value_ZonePosBefore)
                {
                    _zonesBefore.Add(zone);
                }
                else if (position == XEP_EmdNames.s_Value_ZonePosAfter)
                {
                    _zonesAfter.Add(zone);
                }
                else if (position == XEP_EmdNames.s_Value_ZonePosCurrent)
                {
                    currentZoneCandidates.Add(zone);
                }
            }
        }
        void PrepareZoneFromElement(XEP_IEmdElement zone)
        {
            _zone4Work = XEP_EmdReadWriteFactory.Instance().CreateEmdStirrupZoneData();
            _zone4Work.CreateFromEmdElement(zone);
            _zone4Work.ZoneBeg = _zoneBeg;
            _zone4Work.ZoneEnd = _zoneEnd;
        }
        void PrepareZone4NoZones()
        {
            _zone4Work = XEP_EmdReadWriteFactory.Instance().CreateEmdStirrupZoneData();
            _zone4Work.ZoneID = s_zoneIDstatic;
            _zone4Work.ZoneBeg = _zoneBeg;
            _zone4Work.ZoneEnd = _zoneEnd;
            _zone4Work.Material = _baseMat;
        }
        #endregion
    }
}
