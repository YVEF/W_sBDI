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

        public static IStartupConfigurationWrapper DefineType<TRegister>(this ContainerBuilder builder)
        {
            _builder = builder;
            _builder.TypeManager = new TypeManager();
            _builder.TypeManager.AddTypeRegister(typeof(TRegister));
            _builder.guid = Guid.NewGuid();
            _builder.TypeToGuid.Add(typeof(TRegister), _builder.guid);
            return _builder.CreateConfigurationWrapper();
        }

        public static IStartupConfigurationWrapper As<TImplementor>(this IStartupConfigurationWrapper manager)
        {
            _builder.TypeManager.AddTypeImplementor(typeof(TImplementor));
            return manager;
        }

        public static IStartupConfigurationWrapper SingleInstance(this IStartupConfigurationWrapper manager)
        {
            _builder.TypeManager.AddLifeStyle(LyfeStyle.SingleInstance);
            return manager;
        }
    }
}
