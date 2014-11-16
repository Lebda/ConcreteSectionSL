using System;

namespace XEP_EsaModelData.Infrastructure
{
    public static class XEP_EmdFileConstants
    {
        public static readonly string s_FakeRootElementName = "Root";
        public static readonly string s_ElementStart = "(:";
        public static readonly string s_ElementEnd = " )";
        public static readonly string s_AtributStart = ":";
        public static readonly string s_AtributValue = " ";
        public static readonly string s_NoNameAttribut = "NoNameAttribut";
        public static readonly string s_RefAttributEmdTag = "@";
        public static readonly string s_RefAttributEmdSubstitutionTag = "Ref_";
        public static readonly string s_AttributeValueStringStart = "\"";
    }
}
