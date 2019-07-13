using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using W_sBDI.Core;

namespace W_sBDI
{
    /// <summary>
    /// It's internal class for management lyfe cicle of registered types
    /// </summary>
    internal class LifeTimeManagement
    {
        
        private readonly LyfeStyle _lyfeStyle;
        private object _instance;
        /// <summary>
        /// instances for perthread config
        /// </summary>
        private Dictionary<int, object> _threadToInstanceBuff;

        /// <summary>
        /// Default value for LyfeStyle is PerRequest
        /// </summary>
        internal LifeTimeManagement(LyfeStyle? lyfeStyle)
        {
            _lyfeStyle = lyfeStyle ?? LyfeStyle.PerRequest;
            if (_lyfeStyle == LyfeStyle.PerThread) _threadToInstanceBuff = new Dictionary<int, object>();
        }

        public object Instance
        {
            get
            {
                _ApplicationOfRules(ref _instance, true);
                return _instance;
            }

            set
            {
                _instance = value;
                _ApplicationOfRules(ref _instance, false);
            } 
        }

        #region private methods

        private void _ApplicationOfRules(ref object inst, bool fromGetter)
        {
            switch (_lyfeStyle)
            {
                case LyfeStyle.PerRequest: inst = null; break;
                case LyfeStyle.PerThread:
                    {
                        var currentThread = Thread.CurrentThread.ManagedThreadId;
                        if(!fromGetter)
                        {
                            _threadToInstanceBuff.Add(currentThread, inst);
                        }
                        else
                        {
                            _threadToInstanceBuff.TryGetValue(currentThread, out var obj);
                            if (obj != null) inst = obj;
                            else inst = null;
                        }
                        break;
                    }
                case LyfeStyle.SingleInstance: break;
            }
        }

        #endregion

    }
}
