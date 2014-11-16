using System;
using System.Collections.Generic;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdShapeData : XEP_IEmdShapeData
    {
        public XEP_EmdShapeData()
        {
            Points = new List<XEP_IEmdPointData>();
        }

        #region PROPERTIES
        public List<XEP_IEmdPointData> Points { get; set; }
        #endregion

        #region INTERFACE IMPL
        public void CreateFrom(List<Point> shape)
        {
            Points.Clear();
            foreach (var item in shape)
            {
                XEP_IEmdPointData pointData = XEP_EmdReadWriteFactory.Instance().CreateEmdPointData();
                pointData.CreateFrom(item);
                Points.Add(pointData);
            }
        }
        public List<Point> Create()
        {
            List<Point> retVal = new List<Point>();
            foreach (var item in Points)
            {
                retVal.Add(item.Create());
            }
            return retVal;
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement elem = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elem.Name = XEP_EmdNames.s_KeyShape;
            foreach (var item in Points)
            {
                elem.Elements.Add(item.CreateEmdElement());
            }
            return elem;
        }
        public void CreateFromEmdElement(XEP_IEmdElement elem)
        {
            XEP_BaseEmdFile.CheckName(elem.Name, XEP_EmdNames.s_KeyShape);
            Points.Clear();
            foreach (var item in elem.Elements)
            {
                XEP_IEmdPointData pointData = XEP_EmdReadWriteFactory.Instance().CreateEmdPointData();
                pointData.CreateFromEmdElement(item);
                Points.Add(pointData);
            }
        }
        #endregion
    }
}
