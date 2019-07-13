using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using W_sBDI.Building;

namespace W_sBDI.Core
{
    internal class Container : IContainer
    {
        private Dictionary<Guid, TypeManager> _typeManagerList;
        private Dictionary<Type, Guid> _typeToGuid;

        public Container(Dictionary<Guid, TypeManager> typeManagerList, Dictionary<Type, Guid> typeToGuid)
        {
            _typeManagerList = typeManagerList;
            _typeToGuid = typeToGuid;
        }

        public TAbstract Resolve<TAbstract>() where TAbstract : class
        {
            var guid = _typeToGuid[typeof(TAbstract)];
            var result = _typeManagerList[guid].GetObject();
            return result as TAbstract;
        }

        public void Dispose()
        {
            
        }
    }
}
