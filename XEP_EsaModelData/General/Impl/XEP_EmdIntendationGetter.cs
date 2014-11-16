using System;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdIntendationGetter : XEP_EsaModelData.General.Interface.XEP_IEmdIntendationGetter
    {
        public XEP_EmdIntendationGetter()
        {
            IntendationLevel = 0;
        }

        #region MEMBERS
        public static readonly string s_OneIntendt = "  ";
        #endregion

        #region PROPERTIES
        public int IntendationLevel { get; set; }
        #endregion

        #region METHODS
        public string GetIntendation()
        {
            string retVal = String.Empty;
            for (int counter = 0; counter < IntendationLevel; counter++)
            {
                retVal += s_OneIntendt;
            }
            return retVal;
        }
        #endregion
    }
}
