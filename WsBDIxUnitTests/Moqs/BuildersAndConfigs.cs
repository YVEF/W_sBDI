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


    interface IObj
    {
        string Value { get; }
    }

    class Obj : IObj
    {
        public string Value { get => "It'm Obj"; }
    }

    interface IObj2
    {
        string Value { get; }
    }

    class Obj2 : IObj2
    {
        public string Value { get => "It'm Obj2"; }
    }
}
