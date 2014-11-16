using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XEP_EsaModelData.EmdData.Inputs;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_ReinforcementEmdFile : XEP_BaseEmdFile, XEP_IReinforcementEmdFile
    {
        public XEP_ReinforcementEmdFile()
            : base(XEP_EmdNames.s_KeyReinforcement)
        {
            _reinfBarsProxy = null;
            _reinfStirrupsProxy = null;
            _zonePreparator = XEP_EmdReadWriteFactory.Instance().CreateStirrupZonePreparator();
            _baseMaterial = String.Empty;
        }
        
        #region MEMBERS
        private XEP_IReinf4BarsProxy _reinfBarsProxy;
        private XEP_IReinf4StirrupsProxy _reinfStirrupsProxy;
        private readonly XEP_IStirrupZonePreparator _zonePreparator;
        string _baseMaterial;
        #endregion
        
        #region PROPERTIES
        #endregion
        
        #region INTERFACE IMPL
        public override void Load(Stream stream)
        {
            base.Load(stream);
            _reinfBarsProxy = XEP_EmdReadWriteFactory.Instance().CreateReinf4BarsProxy(_emdDocument.Root);
            _reinfStirrupsProxy = XEP_EmdReadWriteFactory.Instance().CreateReinf4StirrupsProxy(_emdDocument.Root);
        }
        public void PrepareDocument(double sectionPos, string baseMaterial, double memberLenght)
        {
            _baseMaterial = baseMaterial;
            _zonePreparator.PrepareZones(_reinfStirrupsProxy.Reinf4Stirrups, sectionPos, _baseMaterial, 0.0, memberLenght);
        }
        public void SetBars(List<XEP_IBarIO> bars, int sectionID)
        {
            _reinfBarsProxy.SectionID = sectionID;
            RemoveElements(_reinfBarsProxy.Reinf4Bars, XEP_EmdNames.s_KeyBar);
            foreach (var bar in bars)
            {
                XEP_IEmdBarData barData = XEP_EmdReadWriteFactory.Instance().CreateEmdBarData();
                barData.CreateFrom(bar, 0, _baseMaterial, 1, 0);
                _reinfBarsProxy.Reinf4Bars.Elements.Add(barData.CreateEmdElement());
            }
        }
        public List<XEP_IBarIO> GetBars(int sectionID)
        {
            _reinfBarsProxy.SectionID = sectionID;
            List<XEP_IBarIO> retVal = new List<XEP_IBarIO>();
            List<XEP_IEmdElement> domBars = GetElements(_reinfBarsProxy.Reinf4Bars, XEP_EmdNames.s_KeyBar);
            foreach (var domBar in domBars)
            {
                XEP_IEmdBarData barData = XEP_EmdReadWriteFactory.Instance().CreateEmdBarData();
                barData.CreateFromEmdElement(domBar);
                retVal.Add(barData.Create());
            }
            return retVal;
        }
        public XEP_IStirrupZoneIO GetStirrupZoneIO()
        {
            return _zonePreparator.GetStirrupZoneIO();
        }
        public void SetStirrupZoneIO(XEP_IStirrupZoneIO zoneIO)
        {
            _zonePreparator.SetStirrupZoneIO(zoneIO);
        }
        #endregion
        
        #region PRIVATE
        #endregion
    }
}