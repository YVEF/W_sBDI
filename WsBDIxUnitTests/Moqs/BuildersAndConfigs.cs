using System;
using System.Collections.Generic;
using System.Text;

namespace WsBDIxUnitTests.Moqs
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
