using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Building
{
    internal interface IBuilderManager
    {
        void StructuringStorageTypes();
        void CreateStartupInstance();
        object GetObject();
    }
}
