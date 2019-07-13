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

        internal ConfigurationDefiner() : this(new ConfigProperties())
        { }

        internal ConfigurationDefiner(IConfigProperties properties)
        {
            properties = properties ?? throw new NullReferenceException();
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
                result = Activator.CreateInstance(_implementorTypes.First());
                this.LifeTimeManagement.Instance = result;
            }                
            return result;
        }

        #endregion

    }
}
