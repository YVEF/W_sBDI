using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Building;
using W_sBDI;
using W_sBDI.Core;
using System.Dynamic;
using System.Linq;

namespace W_sBDI
{
    public static class BaseConfigurationExtension
    {
        private static ContainerBuilder _builder;
        private static IRegisterManager _registerManager;
        private static IConfigurationDefiner _configurationDefiner;
        private static IConfigProperties _configProperties;

        public static IStartupConfigurationWrapper DefineType<TRegister>(this ContainerBuilder builder)
        {
            _builder = builder;
            _configProperties = new ConfigProperties();
            _configurationDefiner = new ConfigurationDefiner(_configProperties);
            _registerManager = new TypeManager(_configurationDefiner);
            var guid = Guid.NewGuid();
            _builder.TypeManagerList.Add(guid, _registerManager as IBuilderManager);
            _builder.TypeToGuid.Add(typeof(TRegister), guid);
            return _builder.CreateConfigurationWrapper();
        }

        public static IStartupConfigurationWrapper Define<TRegister>(this ContainerBuilder builder)
        {
            return _builder.CreateConfigurationWrapper();
        }

        public static IStartupConfigurationWrapper As<TImplementor>(this IStartupConfigurationWrapper manager)
        {
            _registerManager.AddTypeImplementor(typeof(TImplementor));
            return manager;
        }

        public static IStartupConfigurationWrapper As(this IStartupConfigurationWrapper manager, Func<object, object> objectImplementor)
        {
            _configProperties.ExistingObject = objectImplementor?.Invoke(objectImplementor);
            return manager;
        }

        public static IStartupConfigurationWrapper WithConstructorArguments(this IStartupConfigurationWrapper manager, string paramenterName, object value)
        {
            _configProperties.CtorParams.Add(paramenterName, value);
            return manager;
        }



        public static IStartupConfigurationWrapper FindImplementor(this IStartupConfigurationWrapper manager)
        {
            Type registerType = _builder.TypeToGuid.Keys.LastOrDefault();
            Type implementorType = registerType.Assembly.GetTypes().FirstOrDefault(x => x.GetInterfaces().Any(y => y == registerType));
            if (implementorType == null) throw new NullReferenceException();
            _registerManager.AddTypeImplementor(implementorType);
            return manager;
        }



        public static IStartupConfigurationWrapper SingleInstance(this IStartupConfigurationWrapper manager)
        {
            _registerManager.AddLifeStyle(LyfeStyle.SingleInstance);
            return manager;
        }

        public static IStartupConfigurationWrapper PerRequest(this IStartupConfigurationWrapper manager)
        {
            _registerManager.AddLifeStyle(LyfeStyle.PerRequest);
            return manager;
        }

        public static IStartupConfigurationWrapper PerThread(this IStartupConfigurationWrapper manager)
        {
            _registerManager.AddLifeStyle(LyfeStyle.PerThread);
            return manager;
        }
    }
}
