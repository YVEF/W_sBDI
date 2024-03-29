﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace W_sBDI.Building
{
    internal class InstanceActivator : IActivator
    {
        private readonly IConfigProperties _configProperties;

        internal InstanceActivator(IConfigProperties configProperties)
        {
            _configProperties = configProperties;
        }

        public object CreateInstance(IEnumerable<Type> types)
        {
            if (_configProperties.ExistingObject != null) return _FullObjectCopy(_configProperties.ExistingObject);
            var type = types.First();
            if (_configProperties.CtorParams.Count == 0) return Activator.CreateInstance(type);
            var findedType = type.GetConstructors().FirstOrDefault(x => x.GetParameters().All(z => _configProperties.CtorParams.Keys.Contains(z.Name)));
            if (findedType == null) return null;

            int length = _configProperties.CtorParams.Values.Count;
            var res = new object[length];
            var param = findedType.GetParameters();
            for (int i = 0; i < length; i++)
                res[i] = _configProperties.CtorParams[param[i].Name];
            return findedType.Invoke(res);
        }

        private object _FullObjectCopy(object obj)
        {
            var memberwiseClone = obj.GetType().GetMethod("MemberwiseClone", BindingFlags.Instance | BindingFlags.NonPublic);
            return memberwiseClone.Invoke(obj, null);
        }

        public void Dispose()
        {
            
        }
    }
}
