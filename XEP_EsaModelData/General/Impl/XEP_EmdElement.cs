using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdElement : XEP_IEmdElement
    {
        public XEP_EmdElement()
        {
            _attributes = new Dictionary<string, XEP_EmdAttributeWithPos>();
            Elements = new List<XEP_IEmdElement>();
            Name = String.Empty;
            _attCounter = 0;
        }

        public override string ToString()
        {
            return
                  "Name: " + Name + "|" +
                  "ElemCount: " + Elements.Count.ToString() + "|" +
                  "AttCount: " + _attributes.Count.ToString();
        }
        #region MEMBERS
        private List<XEP_IEmdAttribute> _attHelp;
        public List<XEP_IEmdAttribute> AttHelp
        {
            get
            {
                if (_attHelp == null)
                {
                    _attHelp = new List<XEP_IEmdAttribute>();
                    IOrderedEnumerable<KeyValuePair<string, XEP_EmdAttributeWithPos>> sortHelp = _attributes.OrderByDescending(x => x.Value.Pos);
                    foreach (var item in sortHelp)
                    {
                        _attHelp.Add(item.Value.Att);
                    }
                }
                return _attHelp;
            }
            private set 
            {
                _attHelp = value; 
            }
        }
        int _attCounter;
        readonly Dictionary<string, XEP_EmdAttributeWithPos> _attributes;
        #endregion

        #region PROPERTIES
        public string Name { get; set; }
        public List<XEP_IEmdElement> Elements { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public void AddAttribute(XEP_IEmdAttribute att)
        {
            AttHelp = null;
            _attributes.Add(att.Name, new XEP_EmdAttributeWithPos(att, _attCounter));
            _attCounter++;
        }
        public XEP_IEmdAttribute GetAttribute(string attName)
        {
            if (_attributes.ContainsKey(attName))
            {
                return _attributes[attName].Att;
            }
            return null;
        }
        public XElement CreateXElement()
        {
            XElement xElem = new XElement(Name);
            foreach (var attribut in AttHelp)
            {
                xElem.Add(attribut.CreateXAttribute());
            }
            foreach (var childElem in Elements)
            {
                xElem.Add(childElem.CreateXElement());
            }
            return xElem;
        }
        public void Save(StreamWriter fileWriter, XEP_IEmdIntendationGetter intendationGetter)
        {
            fileWriter.Write(intendationGetter.GetIntendation() + XEP_EmdFileConstants.s_ElementStart + Name);
            foreach (var att in AttHelp)
            {
                att.Save(fileWriter);
            }
            fileWriter.Write(XEP_EmdFileConstants.s_ElementEnd);
            fileWriter.Write(Environment.NewLine);
            if (Elements.Count > 0)
            {
                XEP_IEmdIntendationGetter intendationGetter4MyElems = XEP_EmdReadWriteFactory.Instance().CreateEmdIntendationGetter();
                intendationGetter4MyElems.IntendationLevel = intendationGetter.IntendationLevel + 1;
                foreach (var elem in Elements)
                {
                    elem.Save(fileWriter, intendationGetter4MyElems);
                }
            }
        }
        public void LoadXElement(XElement elem)
        {
            Name = elem.Name.ToString();
            _attributes.Clear();
            Elements.Clear();
            foreach (var actItem in elem.Attributes())
            {
                XEP_IEmdAttribute attribute = XEP_EmdReadWriteFactory.Instance().CreateEmdAttribute();
                attribute.LoadXAttribute(actItem);
                AddAttribute(attribute);
            }
            foreach (var actItem in elem.Elements())
            {
                XEP_IEmdElement elemEmd = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
                elemEmd.LoadXElement(actItem);
                Elements.Add(elemEmd);
            }
        }
        public void LoadEmdElement(XEP_IEmdElement elem)
        {
            Name = elem.Name;
            Elements.Clear();
            _attributes.Clear();
            foreach (var attribut in elem.AttHelp)
            {
                AddAttribute(attribut);
            }
            foreach (var childElem in elem.Elements)
            {
                Elements.Add(childElem);
            }
        }
        #endregion    
  

        #region PRIVATE
        private class XEP_EmdAttributeWithPos
        {
            public XEP_EmdAttributeWithPos(XEP_IEmdAttribute att, int pos)
            {
                Att = att;
                Pos = pos;
            }
            public XEP_IEmdAttribute Att { get; set; }
            public int Pos { get; set; }
        }
        #endregion

    }
}