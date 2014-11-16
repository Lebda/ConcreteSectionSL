using System;
using System.Linq;
using XEP_EsaModelData.EmdFiles.Interface;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal class XEP_Reinf4StirrupsProxy : XEP_IReinf4StirrupsProxy
    {
        public XEP_Reinf4StirrupsProxy(XEP_IEmdElement elem4Work)
        {
            _elem4Work = elem4Work;
        }

        #region MEMBERS
        private XEP_IEmdElement _reinf4Stirrups;
        private readonly XEP_IEmdElement _elem4Work;
        #endregion

        #region PROPERTIES
        public XEP_IEmdElement Reinf4Stirrups
        {
            get
            {
                if (_reinf4Stirrups == null)
                {
                    _reinf4Stirrups = FindReinforcementElement4StirrupZones(_elem4Work);
                }
                return _reinf4Stirrups;
            }
        }
        #endregion

        #region INTERFACE IMPL

        #endregion

        #region METHODS PRIVATE
        static XEP_IEmdElement FindReinforcementElement4StirrupZones(XEP_IEmdElement elem4Work)
        {
            XEP_IEmdElement reinfElem = elem4Work;
            if (elem4Work.Name == XEP_EmdFileConstants.s_FakeRootElementName)
            { // more sections
                reinfElem = XEP_BaseEmdFile.GetElement(elem4Work, XEP_EmdNames.s_KeyReinforcement);
            }
            if (reinfElem == null)
            {
                throw new InvalidOperationException("There is not reinforcemnt element for stirrups !");
            }
            XEP_BaseEmdFile.CheckName(reinfElem.Name, XEP_EmdNames.s_KeyReinforcement);
            return reinfElem;
        }
        #endregion
    }
}
