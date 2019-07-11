using System;
using System.Collections.Generic;
using System.Text;
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
        /// Default value for LyfeStyle is PerRequest
        /// </summary>
        internal LifeTimeManagement(LyfeStyle? lyfeStyle)
        {
            _lyfeStyle = lyfeStyle ?? LyfeStyle.PerRequest;
        }

        public object Instance
        {
            get
            {
                switch(_lyfeStyle)
                {
                    case LyfeStyle.PerRequest: return null;
                    case LyfeStyle.PerThread: return null;
                    case LyfeStyle.SingleInstance: return _instance;
                    default: return null;
                }
            }

            set
            {
                _instance = value;
            }
 
        }


    }
}
