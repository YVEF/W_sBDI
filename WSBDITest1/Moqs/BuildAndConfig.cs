using System;
using System.Collections.Generic;
using System.Text;

namespace W_sBDITest1.Moqs
{
    interface IBaseObject
    {
        string Value { get; }
    }

    class BaseObject : IBaseObject
    {
        public string Value { get => "It's working"; }
    }
}
