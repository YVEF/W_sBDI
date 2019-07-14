using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    internal class ConfigurationDefiner : IConfigurationDefiner
    {
        private List<Type> _implementorTypes;
        public LifeTimeManagement LifeTimeManagement { get; set; }
        public IConfigProperties ConfigProperties { get; set; }

        internal ConfigurationDefiner() : this(new ConfigProperties())
        { }

        internal ConfigurationDefiner(IConfigProperties properties)
        {
            ConfigProperties = properties ?? throw new NullReferenceException("property value can not be null");
            _implementorTypes = new List<Type>();
        }

        public void AddImplementorTypes(IList<Type> type)
        {
            _implementorTypes.AddRange(type);
        }        

        public object GetInstance()
        {
            return _CreateInstance();
        }

        public void StartupBuildingObject()
        {
            _CreateInstance();
        }

        #region private methods

        private object _CreateInstance()
        {
            object result = this.LifeTimeManagement.Instance;
            if (result == null)
            {
                using(var activator = ActivatorFactory.GetActivator(ConfigProperties))
                {
                    result = activator.CreateInstance(_implementorTypes);
                    this.LifeTimeManagement.Instance = result;
                }                
            }                
            return result;
        }

        #endregion

    }
}
