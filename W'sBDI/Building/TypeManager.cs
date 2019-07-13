﻿using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;
using System.Linq;

namespace W_sBDI.Building
{
    internal class TypeManager
    {
        internal IList<IConfigurationDefiner> ConfigurationDefiners { get; set; }
        //private Type _tempRegisterType;
        private List<Type> _tempImplementorTypes;
        private LyfeStyle? _lyfeStyle;
        private Guid _startGuid;

        internal TypeManager() : this(new List<IConfigurationDefiner>())
        { }

        internal TypeManager(List<IConfigurationDefiner> definers)
        {
            ConfigurationDefiners = definers;
            _tempImplementorTypes = new List<Type>();
        }

        internal void AddTypeRegister(Type tRegister)
        {
            //_tempRegisterType = tRegister;
        }

        internal void AddTypeImplementor(Type tImpl)
        {
            _tempImplementorTypes.Add(tImpl);
        }

        internal void AddLifeStyle(LyfeStyle lyfeStyle)
        {
            if(_lyfeStyle == null) _lyfeStyle = lyfeStyle;
        }

        public void StructuringStorageTypes(/*Guid guidRegister*/)
        {
            var config = new ConfigurationDefiner();
            //config.AddRegisterType(_tempRegisterType);
            config.AddImplementorTypes(_tempImplementorTypes);       
            config.LifeTimeManagement = new LifeTimeManagement(_lyfeStyle);
            ConfigurationDefiners.Add(config);
        }

        public object GetObject(/*Guid guid*/)
        {
            var c = ConfigurationDefiners.FirstOrDefault();
            return c.GetInstance();
        }
    }
}
