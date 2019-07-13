using System;
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


    }
}
