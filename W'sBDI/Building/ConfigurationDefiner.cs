using System;
using System.Collections.Generic;
using System.Text;
using W_sBDI.Core;

namespace W_sBDI.Building
{
    internal class ConfigurationDefiner : IConfigurationDefiner
    {

        public Type Source { get; set; }
        public List<Type> Implementors { get; set; }

        public ConfigurationDefiner() : this(new ConfigProperties())
        { }

        public ConfigurationDefiner(IConfigProperties properties)
        {
            properties = properties ?? throw new NullReferenceException();
        }

        public TypesDefineWrapper StructuringStorageTypes()
        {
            var typesDefine = new Dictionary<SourceType, DefineTypes>();
            var source = new SourceType();
            source.Type = Source;
            var define = new DefineTypes(Implementors.Count);
            define.Types = Implementors.ToArray();
            typesDefine.Add(source, define);

            return new TypesDefineWrapper(typesDefine);
        }
    }
}
