using System;
using System.Collections.Generic;
using System.IO;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdFileReader : XEP_EsaModelData.General.Interface.XEP_IEmdFileReader
    {
        public XEP_EmdFileReader()
        {
            _domCreator = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdLinesParser();
        }
        #region MEMBERS
        XEP_EsaModelData.General.Interface.XEP_IEmdDom _domCreator;
        #endregion
        
        #region PROPERTIES
        public XEP_EsaModelData.General.Interface.XEP_IEmdLine Root
        {
            get { return _domCreator.Root; }
        }
        #endregion
        
        #region INTERFACE IMPL
        public void Read(StreamReader reader)
        {
            _domCreator = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdLinesParser();
            List<XEP_EsaModelData.General.Interface.XEP_IEmdLine> linesEmd = new List<XEP_EsaModelData.General.Interface.XEP_IEmdLine>();
            string line;
            int counter = 0;
            while ((line = reader.ReadLine()) != null)
            {
                XEP_EsaModelData.General.Interface.XEP_IEmdLine
                element = XEP_EsaModelData.Infrastructure.XEP_EmdReadWriteFactory.Instance().CreateEmdLine();
                element.Parse(line, counter);
                linesEmd.Add(element);
                counter++;
            }
            _domCreator.CreateDom(linesEmd);
        }
        #endregion
    }
}