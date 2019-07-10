using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI
{
    public class TypesDefineWrapper
    {
        internal Dictionary<SourceType, DefineTypes> TypesRegistered { get; private set; }

        internal TypesDefineWrapper(Dictionary<SourceType, DefineTypes> types)
        {
            TypesRegistered = types;
        }
    }
}
