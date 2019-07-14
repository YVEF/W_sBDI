using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Building
{
    internal interface IActivator : IDisposable
    {
        object CreateInstance(IEnumerable<Type> types);
    }
}
