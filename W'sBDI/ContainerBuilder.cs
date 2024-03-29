﻿using System;
using System.Collections.Generic;
using W_sBDI.Building;
using W_sBDI.Core;

namespace W_sBDI
{
    public class ContainerBuilder
    {
        internal Dictionary<Guid, IBuilderManager> TypeManagerList { get; set; }
        internal Dictionary<Type, Guid> TypeToGuid { get; set; }

        public ContainerBuilder()
        {
            TypeManagerList = new Dictionary<Guid, IBuilderManager>();
            TypeToGuid = new Dictionary<Type, Guid>();
        }

        public IContainer Build()
        {
            foreach (var manager in TypeManagerList.Values)
            {
                manager.StructuringStorageTypes();
                manager.CreateStartupInstance();
            }                
            return new Container(TypeManagerList, TypeToGuid);
        }

        public IStartupConfigurationWrapper CreateConfigurationWrapper()
        {
            return new StartupConfigurationWrapper();
        }
    }
}
