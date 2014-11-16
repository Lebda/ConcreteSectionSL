using System;
using System.Collections.Generic;
using System.Linq;
using XEP_EsaModelData.General.Interface;
using XEP_EsaModelData.Infrastructure;

namespace XEP_EsaModelData.General.Impl
{
    internal class XEP_EmdDom : XEP_IEmdDom
    {
        public XEP_EmdDom ()
        {
        }
        
        #region PROPERTIES
        public XEP_IEmdLine Root { get; set; }
        #endregion
        
        #region INTERFACE IMPL
        public void CreateDom(List<XEP_IEmdLine> linesEmd)
        {
            List<XEP_IEmdLine> linesEmd4Dom = linesEmd;
            List<XEP_IEmdLine> roots = linesEmd4Dom.Where(item => item.IntendationLevel == 0).ToList();
            Root = PrepareRoot(roots);
            List<XEP_IEmdLine> linesEmd4DomReversed = Enumerable.Reverse(linesEmd4Dom).ToList();
            foreach (var actLineEmd in linesEmd4DomReversed)
            {
                if (actLineEmd.IntendationLevel == 0)
                {
                    continue;
                }
                XEP_IEmdLine ownerLine = FindOwnerInReversed(linesEmd4DomReversed, actLineEmd);
                ownerLine.Lines.Add(actLineEmd);
            }
            Root.ReverseLines();
        }
        #endregion        
    
        #region METHODS PRIVATE
        static private XEP_IEmdLine PrepareRoot(List<XEP_IEmdLine> roots)
        {
            if (roots == null || roots.Count == 0)
            {
                throw new InvalidOperationException("There are no roots eleemnts !");
            }
            if (roots.Count > 1)
            {
                XEP_IEmdLine fakeRoot = XEP_EmdReadWriteFactory.Instance().CreateEmdLine();
                fakeRoot.CreateFakeRoot();
                foreach (var root in roots)
                {
                    fakeRoot.Lines.Add(root);
                }
                return fakeRoot;
            }
            else
            {
                return roots[0];
            }
        }
        static private XEP_IEmdLine FindOwnerInReversed(List<XEP_IEmdLine> linesEmd4DomReversed, XEP_IEmdLine actLineEmd)
        {
            foreach (var actItem in linesEmd4DomReversed)
            {
                if (actItem.LineIndex > actLineEmd.LineIndex)
                {
                    continue;
                }
                if (actItem.IntendationLevel < actLineEmd.IntendationLevel)
                {
                    return actItem;
                }
            }
            throw new InvalidOperationException("Element does not have a owner !");
        }
        #endregion
    }
}