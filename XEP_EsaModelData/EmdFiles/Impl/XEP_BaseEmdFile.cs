using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.EmdFiles.Impl
{
    internal abstract class XEP_BaseEmdFile
    {
        public XEP_BaseEmdFile(string docuName)
        {
            _emdDocument = XEP_EmdReadWriteFactory.Instance().CreateEmdDocument();
            _emdDocuName = docuName;
        }

        #region MEMBERS
        readonly protected XEP_IEmdDocument _emdDocument;
        readonly private string _emdDocuName;
        #endregion

        #region PROPERTIES
        #endregion

        #region INTERFACE IMPL
        public virtual void Load(Stream stream)
        {
            _emdDocument.Load(stream);
            if (_emdDocument.Root.Name != XEP_EmdFileConstants.s_FakeRootElementName)
            {
                CheckName(_emdDocument.Root.Name, _emdDocuName);   
            }
        }
        public void Save(Stream stream)
        {
            _emdDocument.Save(stream);
        }
        #endregion

        #region PROTECTED
        static protected void SaveElement(XEP_IEmdElement elem4Work, XEP_IEmdElement elem4Save, string name4Save)
        {
            CheckName(elem4Save.Name, name4Save);
            XEP_IEmdElement domEmdElem = GetElement(elem4Work, elem4Save.Name);
            if (domEmdElem == null)
            {
                elem4Work.Elements.Add(elem4Save);
            }
            else
            {
                domEmdElem.LoadEmdElement(elem4Save);
            }
        }
        static public void RemoveElements(XEP_IEmdElement elem4Work, string name)
        {
            List<XEP_IEmdElement> domEmdElems4Remove = elem4Work.Elements.Where(item => item.Name == name).ToList();
            if (domEmdElems4Remove == null || domEmdElems4Remove.Count == 0)
            {
                return;
            }
            foreach (var item in domEmdElems4Remove)
            {
                elem4Work.Elements.Remove(item);
            }
        }
        static public List<XEP_IEmdElement> GetElements(XEP_IEmdElement elem4Find, string name)
        {
            List<XEP_IEmdElement> domEmdElems = elem4Find.Elements.Where(item => item.Name == name).ToList();
            return domEmdElems;
        }
        static public XEP_IEmdElement GetElement(XEP_IEmdElement elem4Find, string name)
        {
            XEP_IEmdElement domEmdElem = elem4Find.Elements.Where(item => item.Name == name).First();
            return domEmdElem;
        }
        static public void CheckName(string name4Check, string wantedName)
        {
            if (name4Check != wantedName)
            {
                throw new InvalidOperationException("Invalid name for element save, actual: " + name4Check + " ,wanted :" + wantedName + " !");
            }
        }
        #endregion

    }
}
