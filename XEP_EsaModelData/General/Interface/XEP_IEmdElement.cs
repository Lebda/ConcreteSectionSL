using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace XEP_EsaModelData.General.Interface
{
    public interface XEP_IEmdElement
    {
        string Name { get; set; }
        List<XEP_IEmdElement> Elements { get; }
        /// <summary>
        /// Just copy of attributes => e.g. clear, add will not take effect
        /// </summary>
        List<XEP_IEmdAttribute> AttHelp { get; }
        void AddAttribute(XEP_IEmdAttribute att);
        XEP_IEmdAttribute GetAttribute(string attName);
        void LoadEmdElement(XEP_IEmdElement elem);
        void Save(StreamWriter fileWriter, XEP_EsaModelData.General.Interface.XEP_IEmdIntendationGetter intendationGetter);
        void LoadXElement(XElement elem);
        XElement CreateXElement();
    }
}