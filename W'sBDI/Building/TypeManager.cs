using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    internal class TypeManager
    {
        internal Dictionary<Guid, IConfigurationDefiner> ConfigurationDefiners { get; set; }
        private Type _tempRegisterType;
        private List<Type> _tempImplementorTypes;
        private LyfeStyle? _lyfeStyle;
        private Guid _startGuid;

        internal TypeManager() : this(new Dictionary<Guid, IConfigurationDefiner>())
        { }

        internal TypeManager(Dictionary<Guid, IConfigurationDefiner> definers)
        {
            ConfigurationDefiners = definers;
            _tempImplementorTypes = new List<Type>();
        }

        internal void AddTypeRegister(Type tRegister)
        {
            _tempRegisterType = tRegister;
        }

        internal void AddTypeImplementor(Type tImpl)
        {
            _tempImplementorTypes.Add(tImpl);
        }

        internal void AddLifeStyle(LyfeStyle lyfeStyle)
        {
            if(_lyfeStyle == null) _lyfeStyle = lyfeStyle;
        }

        public void StructuringStorageTypes(Guid guidRegister)
        {
            var config = new ConfigurationDefiner();
            config.AddRegisterType(_tempRegisterType);
            config.AddImplementorTypes(_tempImplementorTypes);       
            config.LifeTimeManagement = new LifeTimeManagement(_lyfeStyle);
            ConfigurationDefiners.Add(guidRegister, config);
        }

        public object GetObject(Guid guid)
        {
            var c = ConfigurationDefiners[guid];
            return c.GetInstance();
        }
    }
}
