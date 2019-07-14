using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Building
{
    internal interface IConfigProperties
    {
        Dictionary<string, object> CtorParams { get; set; }
        Dictionary<string, object> PropertyParams { get; set; }
    }
}
