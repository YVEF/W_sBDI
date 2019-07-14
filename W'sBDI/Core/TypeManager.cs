using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;
using System.Linq;
using W_sBDI.Building;

namespace W_sBDI.Core
{
    internal class TypeManager : IRegisterManager, IBuilderManager
    {
        public IConfigurationDefiner ConfigurationDefiner { get; set; }
        private List<Type> _tempImplementorTypes;
        private LyfeStyle? _lyfeStyle;

        internal TypeManager() : this(new ConfigurationDefiner())
        { }

        internal TypeManager(IConfigurationDefiner definer)
        {
            ConfigurationDefiner = definer;
            _tempImplementorTypes = new List<Type>();
        }

        public void AddTypeImplementor(Type tImpl)
        {
            _tempImplementorTypes.Add(tImpl);
        }

        public void AddLifeStyle(LyfeStyle lyfeStyle)
        {
            if(_lyfeStyle == null) _lyfeStyle = lyfeStyle;
        }

        public void StructuringStorageTypes()
        {
            ConfigurationDefiner.AddImplementorTypes(_tempImplementorTypes);
            ConfigurationDefiner.LifeTimeManagement = new LifeTimeManagement(_lyfeStyle);
            _tempImplementorTypes = null;
        }

        public void CreateStartupInstance()
        {
            ConfigurationDefiner.StartupBuildingObject();
        }

        public object GetObject()
        {
            return ConfigurationDefiner.GetInstance();
        }
    }
}
