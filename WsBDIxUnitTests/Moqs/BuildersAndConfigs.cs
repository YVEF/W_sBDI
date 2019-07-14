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

    interface IObj1
    {
        string Value { get; set; }
    }

    class Obj1 : IObj1
    {
        public Obj1(string val) => Value = val;

        public string Value { get; set; }
    }

    interface IObj2
    {
        string Value { get; }
    }

    class Obj2 : IObj2
    {
        public string Value { get => "It'm Obj2"; }
    }

    interface IObjThread
    {
        string Value { get; }
    }

    class ObjThread : IObjThread
    {
        public string Value { get => "It'm ObjThread"; }
    }

    interface IMoqWithCtorArgs
    {
        string Value { get; set; }
    }

    class MoqWithCtorArgs : IMoqWithCtorArgs
    {
        public MoqWithCtorArgs(string value) => Value = value;
        public string Value { get; set; }
    }
}
