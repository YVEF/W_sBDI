using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    public interface IConfigurationDefiner
    {
        TypesDefineWrapper StructuringStorageTypes();
        Type Source { get; set; }
        List<Type> Implementors { get; set; }
    }
}
