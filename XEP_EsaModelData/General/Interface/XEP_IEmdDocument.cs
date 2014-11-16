using System.IO;
using System.Xml.Linq;

namespace XEP_EsaModelData.General.Interface
{
    public interface XEP_IEmdDocument
    {
        void Save(Stream stream);
        XEP_IEmdElement Root { get; }
        void Load(Stream stream);
        void Load(XDocument xDocument);
    }
}