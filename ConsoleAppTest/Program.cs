using System;
using W_sBDI;

namespace ConsoleAppTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.DefineType<IBaseObject>().As<BaseObject>();
            var container = builder.Build();
            IBaseObject baseObject = container.Resolve<IBaseObject>();
        }
    }

    interface IBaseObject
    {
        string Value { get; }
    }

    class BaseObject : IBaseObject
    {
        public string Value { get => "It's working"; }
    }
}
