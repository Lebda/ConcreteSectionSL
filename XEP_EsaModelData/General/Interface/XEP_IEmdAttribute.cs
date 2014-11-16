using System;
using System.IO;
using System.Xml.Linq;

namespace XEP_EsaModelData.General.Interface
{
    public interface XEP_IEmdAttribute
    {
        void Save(StreamWriter fileWriter);
        void LoadXAttribute(XAttribute xAtt);
        XAttribute CreateXAttribute();
        string Name { get; set; }
        string Value { get; set; }
        double GetDoubleValue();
        int GetIntValue();
    }
}