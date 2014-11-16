using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdLine : XEP_IEmdLine
    {
        public XEP_EmdLine()
        {
            LineIndex = 0;
            IntendationLevel = 0;
            Name = String.Empty;
            Attributes = new List<XEP_IEmdAttribute>();
            Lines = new List<XEP_IEmdLine>();
        }

        public override string ToString()
        {
            return
                  "Name: " + Name + "|" +
                  "LineIndex: " + LineIndex.ToString() + "|" +
                  "LinesCount: " + Lines.Count.ToString() + "|" +
                  "AttributesCount: " + Attributes.Count.ToString() + "|" +
                  "IntendationLevel: " + IntendationLevel.ToString();
        }
        
        #region PROPERTIES
        public int LineIndex { get; set; }
        public int IntendationLevel { get; set; }
        public string Name { get; set; }
        public List<XEP_IEmdAttribute> Attributes { get; set; }
        public List<XEP_IEmdLine> Lines { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public void CreateFakeRoot()
        {
            LineIndex = -1;
            IntendationLevel = -1;
            Name = XEP_EmdFileConstants.s_FakeRootElementName;
            Attributes.Clear();
            Lines.Clear();
        }
        public XEP_IEmdElement CreateEmdElement()
        {
            XEP_IEmdElement emdElem = XEP_EmdReadWriteFactory.Instance().CreateEmdElement();
            emdElem.Name = Name;
            foreach (var attribut in Attributes)
            {
                emdElem.AddAttribute(attribut);
            }
            foreach (var childElem in Lines)
            {
                emdElem.Elements.Add(childElem.CreateEmdElement());
            }
            return emdElem; 
        }
        public void Parse(string line, int lineIndex)
        {
            LineIndex = lineIndex;
            IntendationLevel = 0;
            Name = String.Empty;
            Attributes.Clear();
            Lines.Clear();
            if (!String.IsNullOrWhiteSpace(line))
            {
                char[] chars = line.ToCharArray();
                foreach (var charItem in chars)
                {
                    if (Char.IsWhiteSpace(charItem))
                    {
                        IntendationLevel++;
                        continue;
                    }
                    break;
                }
                ReadElementName(ref line);
                ReadAtributes(line);
            }
        }
        public void ReverseLines()
        {
            foreach (var lineEmd in Lines)
            {
                lineEmd.ReverseLines();
            }
            if (Lines.Count > 1)
            {
                Lines = Enumerable.Reverse(Lines).ToList();   
            }
        }
        #endregion
        
        #region METHODS PRIVATE
        private void ReadElementName(ref string line)
        {
            if (!line.Contains(XEP_EmdFileConstants.s_ElementStart))
            {
                throw new NotImplementedException("Invalid Emd element tag !");
            }
            string lineNoWhiteSpaceStart = RemoveIntendation(line);
            string lineNoStartTag = RemoveStartTag(lineNoWhiteSpaceStart);
            Name = ReadOneString(ref lineNoStartTag);
            line = lineNoStartTag;
        }
        private void ReadAtributes(string line)
        {
            bool bNormalAtt = line.Contains(XEP_EmdFileConstants.s_AtributStart);
            if (bNormalAtt)
            {
                while (line.Contains(XEP_EmdFileConstants.s_AtributStart))
                {
                    line = RemoveAttributeStartTag(line);
                    XEP_IEmdAttribute attribute = XEP_EmdReadWriteFactory.Instance().CreateEmdAttribute();
                    attribute.Name = ReadOneString(ref line);
                    line = RemoveWhiteSpace(line);
                    if (line.StartsWith(XEP_EmdFileConstants.s_AttributeValueStringStart))
                    {
                        int foundS1 = line.IndexOf(XEP_EmdFileConstants.s_AttributeValueStringStart);
                        int foundS2 = line.IndexOf(XEP_EmdFileConstants.s_AttributeValueStringStart, foundS1 + 1);
                        attribute.Value = line.Substring(foundS1, foundS2 - foundS1 + 1);
                        line = line.Remove(0, foundS2 + 1);
                    }
                    else
                    {
                        attribute.Value = ReadOneString(ref line);
                    }
                    Attributes.Add(attribute);
                }   
            }
            else
            {
                if (Regex.IsMatch(line, @"\w"))
                { // stupid (:IsPhased 0 ) idiotic syntax
                    XEP_IEmdAttribute attribute = XEP_EmdReadWriteFactory.Instance().CreateEmdAttribute();
                    attribute.Name = XEP_EmdFileConstants.s_NoNameAttribut;
                    line = RemoveWhiteSpace(line);
                    attribute.Value = ReadOneString(ref line);
                    Attributes.Add(attribute);
                }
            }
        }
        static private string ReadOneString(ref string line)
        {
            string retVal = String.Empty;
            int followingWhiteSpaceIndex = line.IndexOf(" ");
            if (followingWhiteSpaceIndex >= 0)
            {
                retVal = line.Remove(followingWhiteSpaceIndex);
                line = line.Remove(0, followingWhiteSpaceIndex);
            }
            return retVal;
        }
        static private string RemoveAttributeStartTag(string line)
        {
            return line.TrimStart(' ', ':');
        }
        static private string RemoveWhiteSpace(string line)
        {
            return line.TrimStart(' ');
        }
        static private string RemoveIntendation(string line)
        {
            return line.TrimStart(' ');
        }
        static private string RemoveStartTag(string line)
        {
            return line.TrimStart('(', ':');
        }
        #endregion
    }
}