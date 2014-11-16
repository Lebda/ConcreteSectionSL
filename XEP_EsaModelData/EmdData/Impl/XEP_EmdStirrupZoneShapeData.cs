using System;
using System.Collections.Generic;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdStirrupZoneShapeData : XEP_IEmdStirrupZoneShapeData
    {
        public XEP_EmdStirrupZoneShapeData()
        {
            Branches = new List<XEP_IEmdStirrupBranchData>();
        }

        #region PROPERTIES
        public List<XEP_IEmdStirrupBranchData> Branches { get; set; }
        #endregion

        #region INTERFACE IMPL
        public void CreateFrom(List<List<Point>> shape)
        {
            Branches.Clear();
            foreach (var item in shape)
            {
                XEP_IEmdStirrupBranchData branchData = XEP_EmdReadWriteFactory.Instance().CreateEmdStirrupBranchData();
                branchData.CreateFrom(item);
                Branches.Add(branchData);
            }
        }
        public List<List<Point>> Create()
        {
            List<List<Point>> retVal = new List<List<Point>>();
            foreach (var item in Branches)
            {
                retVal.Add(item.Create());
            }
            return retVal;
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement elem = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elem.Name = XEP_EmdNames.s_KeyStirrupZoneShape;
            foreach (var item in Branches)
            {
                elem.Elements.Add(item.CreateEmdElement());
            }
            return elem;
        }
        public void CreateFromEmdElement(XEP_IEmdElement elem)
        {
            XEP_BaseEmdFile.CheckName(elem.Name, XEP_EmdNames.s_KeyStirrupZoneShape);
            Branches.Clear();
            foreach (var item in elem.Elements)
            {
                XEP_IEmdStirrupBranchData branchData = XEP_EmdReadWriteFactory.Instance().CreateEmdStirrupBranchData();
                branchData.CreateFromEmdElement(item);
                Branches.Add(branchData);
            }
        }
        #endregion
    }
}
