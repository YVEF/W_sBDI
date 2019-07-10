using System;
using W_sBDI.Building;
using W_sBDI.Core;

namespace W_sBDI
{
    public class ContainerBuilder
    {
        public readonly IConfigurationDefiner ConfigurationDefiner = new ConfigurationDefiner();


        public ContainerBuilder()
        { }

        public IContainer Build()
        {
            var typeStorage = ConfigurationDefiner.StructuringStorageTypes();
            return new Container(typeStorage);
        }
    }
}
