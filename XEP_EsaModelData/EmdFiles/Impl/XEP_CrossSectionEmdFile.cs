using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_CrossSectionEmdFile : XEP_BaseEmdFile, XEP_ICrossSectionEmdFile
    {
        public XEP_CrossSectionEmdFile()
            : base(XEP_EmdNames.s_KeyCrossSection)
        {
        }
        
        #region INTERFACE IMPL
        public void SaveGeometry(List<KeyValuePair<string, string>> items)
        {
            XEP_IEmdGeometryData data = XEP_EmdReadWriteFactory.Instance().CreateEmdGeometryData();
            data.CreateFrom(items);
            SaveElement(_emdDocument.Root, data.CreateEmdElement(), XEP_EmdNames.s_KeyGeometry);
        }
        public void SaveShape(List<Point> points)
        {
            XEP_IEmdShapeData data = XEP_EmdReadWriteFactory.Instance().CreateEmdShapeData();
            data.CreateFrom(points);
            SaveElement(GetElement(_emdDocument.Root, XEP_EmdNames.s_KeyComponent), data.CreateEmdElement(), XEP_EmdNames.s_KeyShape);
        }
        public void SaveFibres(List<Point> fibres)
        {
            XEP_IEmdFibresData data = XEP_EmdReadWriteFactory.Instance().CreateEmdFibresData();
            data.CreateFrom(fibres);
            SaveElement(_emdDocument.Root, data.CreateEmdElement(), XEP_EmdNames.s_KeyFibres);
        }
        public List<Point> GetShape()
        {
            XEP_IEmdElement domCompElem = GetElement(_emdDocument.Root, XEP_EmdNames.s_KeyComponent);
            XEP_IEmdElement domShapeElem = GetElement(domCompElem, XEP_EmdNames.s_KeyShape);
            XEP_IEmdShapeData data = XEP_EmdReadWriteFactory.Instance().CreateEmdShapeData();
            data.CreateFromEmdElement(domShapeElem);
            return data.Create();
        }
        public int GetFormCode()
        {
            XEP_IEmdElement domElem = GetElement(_emdDocument.Root, XEP_EmdNames.s_KeyGeometry);
            return domElem.GetAttribute(XEP_EmdNames.s_KeyFormCode).GetIntValue();
        }
        #endregion
    }
}