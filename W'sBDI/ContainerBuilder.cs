using System;
using System.Collections.Generic;
using W_sBDI.Building;
using W_sBDI.Core;

namespace W_sBDI
{
    public class ContainerBuilder
    {
        internal TypeManager TypeManager { get; set; }
        internal Dictionary<Type, Guid> TypeToGuid { get; set; }
        internal Guid guid { get; set; }

        public ContainerBuilder()
        {
            TypeToGuid = new Dictionary<Type, Guid>();
        }

        public IContainer Build()
        {
            TypeManager.StructuringStorageTypes(guid);
            return new Container(TypeManager, TypeToGuid);
        }

        public IStartupConfigurationWrapper CreateConfigurationWrapper()
        {
            return new StartupConfigurationWrapper();
        }
    }
}
