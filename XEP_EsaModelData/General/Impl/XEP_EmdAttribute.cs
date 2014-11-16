using System;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Xml.Linq;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdAttribute : XEP_IEmdAttribute
    {
        public XEP_EmdAttribute()
        {
            Name = String.Empty;
            Value = String.Empty;
        }

        public override string ToString()
        {
            return
                  "Name: " + Name + "|" +
                  "Value: " + Value;
        }
        
        #region PROPERTIES
        public string Name { get; set; }
        public string Value { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public double GetDoubleValue()
        {
            double number = 0;
            if (double.TryParse(Value, NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out number))
            {
                return number;
            }
            string valueComma = Value.Replace(".", ",");
            if (double.TryParse(valueComma, NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out number))
            {
                return number;
            }
            string valueFullStop = Value.Replace(",", ".");
            if (double.TryParse(valueFullStop, NumberStyles.Any, Thread.CurrentThread.CurrentCulture, out number))
            {
                return number;
            }
            return Double.MaxValue;
        }
        public int GetIntValue()
        {
            int number = 0;
            bool result = Int32.TryParse(Value, out number);
            if (result)
            {
                return number;
            }
            return Int32.MaxValue;
        }
        public XAttribute CreateXAttribute()
        {
            if (String.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException("There is no attribute name !");
            }
            XAttribute att = null;
            if (Name.StartsWith(XEP_EmdFileConstants.s_RefAttributEmdTag))
            {
                string correctXmlName = Name.Replace(XEP_EmdFileConstants.s_RefAttributEmdTag, XEP_EmdFileConstants.s_RefAttributEmdSubstitutionTag);
                att = new XAttribute(correctXmlName, Value);
            }
            else
            {
                att = new XAttribute(Name, Value);
            }
            return att;
        }
        public void LoadXAttribute(XAttribute xAtt)
        {
            Name = xAtt.Name.ToString();
            if (Name.StartsWith(XEP_EmdFileConstants.s_RefAttributEmdSubstitutionTag))
            {
                Name = Name.Replace(XEP_EmdFileConstants.s_RefAttributEmdSubstitutionTag, XEP_EmdFileConstants.s_RefAttributEmdTag);
            }
            Value = (string)xAtt;
        }
        public void Save(StreamWriter fileWriter)
        {
            if (String.IsNullOrEmpty(Name))
            {
                throw new InvalidOperationException("There is no attribute name !");
            }
            if (Name == XEP_EmdFileConstants.s_NoNameAttribut)
            {
                fileWriter.Write(" " + Value);
            }
            else
            {
                fileWriter.Write(" " + XEP_EmdFileConstants.s_AtributStart + Name + " " + Value);
            }
        }
        #endregion
    }
}