using System;
using System.IO;
using System.Xml.Linq;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdDocument : XEP_EsaModelData.General.Interface.XEP_IEmdDocument
    {
        public XEP_EmdDocument()
        {
            _emdReader = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdFileReader();
        }
        #region MEMBERS
        readonly XEP_EsaModelData.General.Interface.XEP_IEmdFileReader _emdReader;
        #endregion
        
        #region PROPERTIES
        public XEP_EsaModelData.General.Interface.XEP_IEmdElement Root { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public void Load(Stream stream)
        {
            using (StreamReader reader = new StreamReader(stream))
            {
                _emdReader.Read(reader);
            }
            Root = _emdReader.Root.CreateEmdElement();
        }
        public void Load(XDocument xDocument)
        {
            Root = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            Root.LoadXElement(xDocument.Root);
        }
        public void Save(Stream stream)
        {
            using (StreamWriter fileWriter = new StreamWriter(stream))
            {
                XEP_EsaModelData.General.Interface.XEP_IEmdIntendationGetter intendationGetter = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdIntendationGetter();
                Root.Save(fileWriter, intendationGetter);
            }
        }
        #endregion
        #region METHODS PUBLIC
        #endregion
        #region METHODS PRIVATE
        #endregion
    }
}