using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDI
{
    /// <summary>
    /// It's public interface of container for management di resolving
    /// </summary>
    public interface IContainer : IDisposable
    {
        /// <summary>
        /// Get registered instance from abstract type
        /// </summary>
        /// <typeparam name="TAbstract"></typeparam>
        /// <returns></returns>
        TAbstract Resolve<TAbstract>() where TAbstract : class;
    }
}
