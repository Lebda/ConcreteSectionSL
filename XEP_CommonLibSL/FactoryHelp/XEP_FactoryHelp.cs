using System;

namespace XEP_CommonLibSL.FactoryHelp
{
    public static class XEP_FactoryHelp
    {
        public static T Instance<T>(ref T singleton, object myLock, Func<T> creator)
            where T : class
        {
            if (singleton == null)
            { // 1st check
                lock (myLock)
                {
                    if (singleton == null)
                    { // 2nd (double) check
                        if (creator == null)
                        {
                            throw new NotImplementedException();
                        }
                        singleton = creator();
                    }
                }
            }
            return singleton;
        }
    }
}
