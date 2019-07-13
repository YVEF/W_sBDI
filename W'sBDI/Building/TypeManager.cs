using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;
using System.Linq;

namespace W_sBDI.Building
{
    internal class TypeManager
    {
        internal IList<IConfigurationDefiner> ConfigurationDefiners { get; set; }
        private List<Type> _tempImplementorTypes;
        private LyfeStyle? _lyfeStyle;

        internal TypeManager() : this(new List<IConfigurationDefiner>())
        { }

        internal TypeManager(List<IConfigurationDefiner> definers)
        {
            ConfigurationDefiners = definers;
            _tempImplementorTypes = new List<Type>();
        }

        internal void AddTypeImplementor(Type tImpl)
        {
            _tempImplementorTypes.Add(tImpl);
        }

        internal void AddLifeStyle(LyfeStyle lyfeStyle)
        {
            if(_lyfeStyle == null) _lyfeStyle = lyfeStyle;
        }

        public void StructuringStorageTypes()
        {
            var config = new ConfigurationDefiner();
            config.AddImplementorTypes(_tempImplementorTypes);       
            config.LifeTimeManagement = new LifeTimeManagement(_lyfeStyle);
            ConfigurationDefiners.Add(config);
            _tempImplementorTypes = null;
        }

        public void CreateStartupInstance()
        {
            var confDef = ConfigurationDefiners.FirstOrDefault();
            confDef.StartupBuildingObject();
        }

        public object GetObject()
        {
            var confDef = ConfigurationDefiners.FirstOrDefault();
            return confDef.GetInstance();
        }
    }
}
