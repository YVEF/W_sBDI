using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Core
{
    internal class DefineTypes
    {
        public DefineTypes(int typesCount)
        {
            Types = new Type[typesCount];
        }

        internal Type[] Types { get; set; }
    }
}
