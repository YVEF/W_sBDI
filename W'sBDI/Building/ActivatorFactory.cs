using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI.Building
{
    internal static class ActivatorFactory
    {
        public static IActivator GetActivator(IConfigProperties configProperties)
        {
            return new InstanceActivator(configProperties);
        }
    }
}
