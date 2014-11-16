using System;
using System.Windows;
using XEP_EsaModelData.EmdData.Interface;
using XEP_EsaModelData.EmdFiles.Impl;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdData.Impl
{
    internal class XEP_EmdPointData : XEP_IEmdPointData
    {
        public XEP_EmdPointData()
        {
            X = 0.0;
            Y = 0.0;
        }
        
        #region PROPERTIES
        public double X { get; set; }
        public double Y { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public void CreateFrom(Point actPoint)
        {
            X = actPoint.X;
            Y = actPoint.Y;
        }
        public Point Create()
        {
            Point retVal = new Point();
            retVal.X = X;
            retVal.Y = Y;
            return retVal;
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_EmdReadWriteFactory fac = XEP_EmdReadWriteFactory.Instance();
            XEP_IEmdElement elemEmd = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            elemEmd.Name = XEP_EmdNames.s_KeyPoint;
            //
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyPointX, X.ToString()));
            elemEmd.AddAttribute(fac.CreateEmdAttribute(XEP_EmdNames.s_KeyPointY, Y.ToString()));
            return elemEmd;
        }
        public void CreateFromEmdElement(XEP_IEmdElement elem)
        {
            XEP_BaseEmdFile.CheckName(elem.Name, XEP_EmdNames.s_KeyPoint);
            X = elem.GetAttribute(XEP_EmdNames.s_KeyPointX).GetDoubleValue();
            Y = elem.GetAttribute(XEP_EmdNames.s_KeyPointY).GetDoubleValue();
        }
        #endregion
    }
}