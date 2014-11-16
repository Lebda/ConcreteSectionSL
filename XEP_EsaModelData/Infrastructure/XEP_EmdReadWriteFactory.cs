using System;
using XEP_CommonLibSL.FactoryHelp;
using XEP_EsaModelData.EmdData.Impl;
using XEP_EsaModelData.EmdData.Inputs;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Impl;
using XEP_EsaModelData.General.Interface;

namespace XEP_EsaModelData.Infrastructure
{
    public class XEP_EmdReadWriteFactory
    {
        readonly private static object s_myLock = new object();
        private static XEP_EmdReadWriteFactory sc_mySingleton = null;
        private XEP_EmdReadWriteFactory()
        {
        }
        public static XEP_EmdReadWriteFactory Instance()
        {
            return XEP_FactoryHelp.Instance<XEP_EmdReadWriteFactory>(ref sc_mySingleton, s_myLock, () => new XEP_EmdReadWriteFactory());
        }
        //
        internal XEP_IEmdFileReader CreateEmdFileReader()
        {
            return new XEP_EmdFileReader();
        }
        internal XEP_IEmdLine CreateEmdLine()
        {
            return new XEP_EmdLine();
        }
        internal XEP_IEmdDom CreateEmdLinesParser()
        {
            return new XEP_EmdDom();
        }
        internal XEP_IReinf4BarsProxy CreateReinf4BarsProxy(XEP_IEmdElement elem4Work)
        {
            return new XEP_Reinf4BarsProxy(elem4Work);
        }
        internal XEP_IReinf4StirrupsProxy CreateReinf4StirrupsProxy(XEP_IEmdElement elem4Work)
        {
            return new XEP_Reinf4StirrupsProxy(elem4Work);
        }
        internal XEP_IStirrupZoneCreationDataFinder CreateStirrupZoneCreationDataFinder()
        {
            return new XEP_StirrupZoneCreationDataFinder();
        }
        internal XEP_IStirrupZonePreparator CreateStirrupZonePreparator()
        {
            return new XEP_StirrupZonePreparator();
        }
        //
        public XEP_IEmdIntendationGetter CreateEmdIntendationGetter()
        {
            return new XEP_EmdIntendationGetter();
        }
        public XEP_IEmdAttribute CreateEmdAttribute()
        {
            return new XEP_EmdAttribute();
        }
        public XEP_IEmdAttribute CreateEmdAttribute(string name, string value)
        {
            XEP_IEmdAttribute att = CreateEmdAttribute();
            att.Name = name;
            att.Value = value;
            return att;
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            return new XEP_EmdElement();
        }
        public XEP_IEmdDocument CreateEmdDocument()
        {
            return new XEP_EmdDocument();
        }
        // Emd data
        public XEP_IEmdPointData CreateEmdPointData()
        {
            return new XEP_EmdPointData();
        }
        public XEP_IEmdShapeData CreateEmdShapeData()
        {
            return new XEP_EmdShapeData();
        }
        public XEP_IEmdLcsData CreateEmdLcsData()
        {
            return new XEP_EmdLcsData();
        }
        public XEP_IEmdPrincipalData CreateIEmdPrincipalData()
        {
            return new XEP_EmdPrincipalData();
        }
        public XEP_IEmdFibreData CreateEmdFibreData()
        {
            return new XEP_EmdFibreData();
        }
        public XEP_IEmdNameValueData CreateEmdNameValueData()
        {
            return new XEP_EmdNameValueData();
        }
        public XEP_IEmdGeometryData CreateEmdGeometryData()
        {
            return new XEP_EmdGeometryData();
        }
        public XEP_IEmdFibresData CreateEmdFibresData()
        {
            return new XEP_EmdFibresData();
        }
        public XEP_IEmdBarData CreateEmdBarData()
        {
            return new XEP_EmdBarData();
        }
        public XEP_IEmdStirrupBranchData CreateEmdStirrupBranchData()
        {
            return new XEP_EmdStirrupBranchData();
        }
        public XEP_IEmdStirrupZoneShapeData CreateEmdStirrupZoneShapeData()
        {
            return new XEP_EmdStirrupZoneShapeData();
        }
        public XEP_IEmdStirrupData CreateEmdStirrupData()
        {
            return new XEP_EmdStirrupData();
        }
        public XEP_ICrossSectionEmdFile CreateCrossSectionEmdFile()
        {
            return new XEP_CrossSectionEmdFile();
        }
        public XEP_IReinforcementEmdFile CreateReinforcementEmdFile()
        {
            return new XEP_ReinforcementEmdFile();
        }
        public XEP_IMaterialsEmdFile CreateMaterialsEmdFile()
        {
            return new XEP_MaterialsEmdFile();
        }
        public XEP_IStirrupZoneIO CreateStirrupZoneIO()
        {
            return new XEP_StirrupZoneIO();
        }
        public XEP_IBarIO CreateBarIO()
        {
            return new XEP_BarIO();
        }
        public XEP_IBarIO CreateBarIO(double x, double y, double diam, double area)
        {
            XEP_IBarIO retVal = CreateBarIO();
            retVal.X = x;
            retVal.Y = y;
            retVal.D = diam;
            retVal.Area = area;
            return retVal;
        }
        public XEP_IEmdStirrupZoneData CreateEmdStirrupZoneData()
        {
            return new XEP_EmdStirrupZoneData();
        }
        
    }
}