using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Building;
using W_sBDI;

namespace W_sBDI
{
    public static class DefineTypesExtension
    {
        private static ContainerBuilder _builder;
        

        public static IConfigurationDefiner DefineType<TRegister>(this ContainerBuilder builder)
        {
            _builder = builder;
            _builder.ConfigurationDefiner.Source = typeof(TRegister);
            return _builder.ConfigurationDefiner;
        }

        public static IConfigurationDefiner As<TImplementor>(this IConfigurationDefiner definer)
        {
            _builder.ConfigurationDefiner.Implementors.Add(typeof(TImplementor));
            return _builder.ConfigurationDefiner;
        }
    }
}
