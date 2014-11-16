using System;
using System.Collections.Generic;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdStirrupBranchData : XEP_IEmdStirrupBranchData
    {
        public XEP_EmdStirrupBranchData()
        {
            Points = new List<XEP_IEmdPointData>();
            IsActive = 1;
            IsDetailing = 0;
            IsTorsion = 1;
        }

        #region PROPERTIES
        public List<XEP_IEmdPointData> Points { get; set; }
        public int IsActive { get; set; }
        public int IsDetailing { get; set; }
        public int IsTorsion { get; set; }
        #endregion

        #region INTERFACE IMPL
        public void CreateFrom(List<Point> shape)
        {
            Points.Clear();
            IsActive = 1;
            IsDetailing = 0;
            IsTorsion = 1;
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
            XEP_EmdReadWriteFactory fac = XEP_EmdReadWriteFactory.Instance();
            XEP_IEmdElement elem = fac.CreateEmdElement();
            elem.Name = XEP_EmdNames.s_KeyStirrupBranch;
            foreach (var item in Points)
            {
                elem.Elements.Add(item.CreateEmdElement());
            }
            elem.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupIsActive, IsActive.ToString()));
            elem.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupIsDetailing, IsDetailing.ToString()));
            elem.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyStirrupIsTorsion, IsTorsion.ToString()));
            return elem;
        }
        public void CreateFromEmdElement(XEP_IEmdElement elem)
        {
            XEP_BaseEmdFile.CheckName(elem.Name, XEP_EmdNames.s_KeyStirrupBranch);
            Points.Clear();
            foreach (var item in elem.Elements)
            {
                XEP_IEmdPointData pointData = XEP_EmdReadWriteFactory.Instance().CreateEmdPointData();
                pointData.CreateFromEmdElement(item);
                Points.Add(pointData);
            }
            IsActive = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupIsActive).GetIntValue();
            IsDetailing = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupIsDetailing).GetIntValue();
            IsTorsion = elem.GetAttribute(XEP_EmdNames.s_KeyStirrupIsTorsion).GetIntValue();
        }
        #endregion
    }
}
