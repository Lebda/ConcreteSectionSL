using System;
using System.Collections.Generic;
using System.Linq;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_Reinf4BarsProxy : XEP_IReinf4BarsProxy
    {
        public XEP_Reinf4BarsProxy(XEP_IEmdElement elem4Work)
        {
            _elem4Work = elem4Work;
        }

        #region MEMBERS
        private int _sectionID;
        private XEP_IEmdElement _reinf4Bars;
        private readonly XEP_IEmdElement _elem4Work;
        #endregion

        #region PROPERTIES
        public XEP_IEmdElement Reinf4Bars
        {
            get
            {
                if (_reinf4Bars == null)
                {
                    if (_sectionID < 0)
                    {
                        throw new InvalidOperationException("SectionID is invalid actual value is: " + _sectionID.ToString());
                    }
                    _reinf4Bars = FindReinforcementElement(_elem4Work, _sectionID);
                }
                return _reinf4Bars;
            }
        }
        public int SectionID
        {
            set 
            { 
                if (_sectionID != value)
	            {
		            _reinf4Bars = null;
	            }
                _sectionID = value;
            }
        }
        #endregion

        #region INTERFACE IMPL

        #endregion

        #region METHODS PRIVATE
        static XEP_IEmdElement FindReinforcementElement(XEP_IEmdElement elem4Work, int sectionID)
        {
            XEP_IEmdElement reinfElem = elem4Work;
            if (elem4Work.Name == XEP_EmdFileConstants.s_FakeRootElementName)
            { // more sections
                List<XEP_IEmdElement> sections = XEP_BaseEmdFile.GetElements(elem4Work, XEP_EmdNames.s_KeySection);
                XEP_IEmdElement needSection = sections.Where(item => item.GetAttribute(XEP_EmdNames.s_KeyID).GetIntValue() == sectionID).First();
                XEP_IEmdAttribute attID = needSection.GetAttribute(XEP_EmdNames.s_KeyID);
                if (attID == null)
                {
                    throw new InvalidOperationException("Section in reinforcement file does not have attribute: " + XEP_EmdNames.s_KeyID);
                }
                if (attID.Value != sectionID.ToString())
                {
                    throw new InvalidOperationException("Section ID attribute is not equals section ID inputed, actual:" + attID.Value + " wanted: " + sectionID.ToString());
                }
                reinfElem = XEP_BaseEmdFile.GetElement(needSection, XEP_EmdNames.s_KeyReinforcement);
            }
            if (reinfElem == null)
            {
                throw new InvalidOperationException("There is not reinforcemnt element for sectionID: " + sectionID.ToString());
            }
            XEP_BaseEmdFile.CheckName(reinfElem.Name, XEP_EmdNames.s_KeyReinforcement);
            return reinfElem;
        }
        #endregion
    }
}
