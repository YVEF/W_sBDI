using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace W_sBDI.Core
{
    internal class Container : IContainer
    {
        private TypesDefineWrapper _typesWrapper;
        public Container(TypesDefineWrapper wrapper)
        {
            _typesWrapper = wrapper;
        }

        public TAbstract Resolve<TAbstract>() where TAbstract : class
        {
            var key = _typesWrapper.TypesRegistered.Keys.FirstOrDefault(x => x.Type == typeof(TAbstract));
            var implementor = _typesWrapper.TypesRegistered[key].Types.FirstOrDefault();
            return Activator.CreateInstance(implementor) as TAbstract ?? null;
        }




        public void Dispose()
        {
            
        }
    }
}
