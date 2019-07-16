using System;
using System.Threading;
using W_sBDI;
using WsBDIxUnitTests.Moqs;
using Xunit;

namespace WsBDIxUnitTests
{
    public class BaseTests
    {
        ContainerBuilder builder;
        IContainer container;
        IBaseObject baseObject;

        public BaseTests()
        {
            builder = new ContainerBuilder();
            builder.DefineType<IBaseObject>().As<BaseObject>().SingleInstance();
            builder.DefineType<IObjThread>().As<ObjThread>().PerThread();
            container = builder.Build();
            baseObject = container.Resolve<IBaseObject>();
        }

        [Fact]
        public void ContainerIsBuilded()
        {
            Assert.NotNull(builder);
        }

        [Fact]
        public void TypesAreResolvedByDefaulConfiguration()
        {
            
            Assert.NotNull(baseObject);
            Assert.Equal("It's working", baseObject.Value);
            var baseObject2 = container.Resolve<IBaseObject>();
            
        }

        [Fact]
        public void SingleInstanceIsWorking()
        {
            var newObj = container.Resolve<IBaseObject>();
            Assert.Equal(baseObject, newObj);
        }

        [Fact]
        public void RegisterAndResolveTwoTypes()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.DefineType<IObj>().As<Obj>();
            newBuilder.DefineType<IObj2>().As<Obj2>();
            var cont = newBuilder.Build();
            var obj2 = cont.Resolve<IObj2>();
            var obj1 = cont.Resolve<IObj>();
            Assert.Equal("It'm Obj", obj1.Value);
            Assert.Equal("It'm Obj2", obj2.Value);
        }

        [Fact]
        public void ResolvePerThreadIsWorking()
        {
            IObjThread obj3 = null;
            var obj1 = container.Resolve<IObjThread>();
            var obj2 = container.Resolve<IObjThread>();
            var thread = new Thread(() =>
            {
                obj3 = container.Resolve<IObjThread>();
            });
            thread.Start();
            thread.Join();
            Assert.Equal(obj1, obj2);
            Assert.NotEqual(obj3, obj1);            
        }

        [Fact]
        public void DefineWithOneConstructorArguments()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.DefineType<IMoqWithCtorArgs>().As<MoqWithCtorArgs>().WithConstructorArguments("value", "call the ctor");
            var cont = newBuilder.Build();
            var moq = cont.Resolve<IMoqWithCtorArgs>();
            Assert.Equal("call the ctor", moq.Value);
        }


        [Fact]
        public void AsDelegateDefiner()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.DefineType<IObj1>().As(t => new Obj1("Hi from obj1"));
            var cont = newBuilder.Build();
            var obj1 = cont.Resolve<IObj1>();
            var obj12 = cont.Resolve<IObj1>();
            Assert.NotNull(obj1);            
            Assert.NotEqual(obj1, obj12);
            Assert.Equal(obj1.Value, obj12.Value);
        }

        [Fact]
        public void AsSingletoneDelegateDefiner()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.DefineType<IObj1>().As(t => new Obj1("Hi from obj1")).SingleInstance();
            var cont = newBuilder.Build();
            var obj1 = cont.Resolve<IObj1>();
            var obj12 = cont.Resolve<IObj1>();
            Assert.NotNull(obj1);
            Assert.Equal(obj1, obj12);
            Assert.Equal(obj1.Value, obj12.Value);
        }

        [Fact]
        public void FindImplementorsIsWorking()
        {
            var newBuilder = new ContainerBuilder();
            newBuilder.DefineType<IObj2>().FindImplementor();
            var cont = newBuilder.Build();
            var obj1 = cont.Resolve<IObj2>();
            Assert.NotNull(obj1);
        }
    }
}
