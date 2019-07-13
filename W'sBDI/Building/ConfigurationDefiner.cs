using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    internal class ConfigurationDefiner : IConfigurationDefiner
    {

        //private Type _registerType;
        private List<Type> _implementorTypes;
        public LifeTimeManagement LifeTimeManagement { get; set; }

        internal ConfigurationDefiner() : this(new ConfigProperties())
        { }

        internal ConfigurationDefiner(IConfigProperties properties)
        {
            properties = properties ?? throw new NullReferenceException();
            _implementorTypes = new List<Type>();
        }

        //public void AddRegisterType(Type type)
        //{
        //    _registerType = type;
        //}

        public void AddImplementorTypes(IList<Type> type)
        {
            _implementorTypes.AddRange(type);
        }

        public object GetInstance()
        {
            Object resolverInst = this.LifeTimeManagement.Instance;
            if(resolverInst == null) resolverInst = Activator.CreateInstance(_implementorTypes.First());
            this.LifeTimeManagement.Instance = resolverInst;
            return resolverInst;
        }
    }
}
