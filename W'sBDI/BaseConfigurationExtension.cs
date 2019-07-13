using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Building;
using W_sBDI;
using W_sBDI.Core;

namespace W_sBDI
{
    public static class BaseConfigurationExtension
    {
        private static ContainerBuilder _builder;
        private static TypeManager _currentManager;

        public static IStartupConfigurationWrapper DefineType<TRegister>(this ContainerBuilder builder)
        {
            _builder = builder;
            _currentManager = new TypeManager();
            _currentManager.AddTypeRegister(typeof(TRegister));
            var guid = Guid.NewGuid();
            _builder.TypeManagerList.Add(guid, _currentManager);
            _builder.TypeToGuid.Add(typeof(TRegister), guid);
            return _builder.CreateConfigurationWrapper();
        }

        public static IStartupConfigurationWrapper As<TImplementor>(this IStartupConfigurationWrapper manager)
        {
            _currentManager.AddTypeImplementor(typeof(TImplementor));
            return manager;
        }

        public static IStartupConfigurationWrapper SingleInstance(this IStartupConfigurationWrapper manager)
        {
            _currentManager.AddLifeStyle(LyfeStyle.SingleInstance);
            return manager;
        }

        public static IStartupConfigurationWrapper PerRequest(this IStartupConfigurationWrapper manager)
        {
            _currentManager.AddLifeStyle(LyfeStyle.PerRequest);
            return manager;
        }

        public static IStartupConfigurationWrapper PerThread(this IStartupConfigurationWrapper manager)
        {
            _currentManager.AddLifeStyle(LyfeStyle.PerThread);
            return manager;
        }
    }
}
