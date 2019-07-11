using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using W_sBDI.Building;

namespace W_sBDI.Core
{
    internal class Container : IContainer
    {
        private TypeManager _typeManager;
        private Dictionary<Type, Guid> _typeToGuid;

        public Container(TypeManager typeManager, Dictionary<Type, Guid> typeToGuid)
        {
            _typeManager = typeManager;
            _typeToGuid = typeToGuid;
        }

        public TAbstract Resolve<TAbstract>() where TAbstract : class
        {
            var guid = _typeToGuid[typeof(TAbstract)];
            var result = _typeManager.GetObject(guid);
            return result as TAbstract;
        }

        public void Dispose()
        {
            
        }
    }
}
