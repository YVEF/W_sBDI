using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI
{
    public interface IContainer : IDisposable
    {
        TAbstract Resolve<TAbstract>() where TAbstract : class;
    }
}
