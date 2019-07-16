using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Building
{
    internal class ConfigProperties : IConfigProperties
    {
        public Dictionary<string, object> CtorParams { get; set; }
        public Dictionary<string, object> PropertyParams { get; set; }
        public object ExistingObject { get; set; }

        public ConfigProperties()
        {
            CtorParams = new Dictionary<string, object>();
            PropertyParams = new Dictionary<string, object>();
        }

    }
}
