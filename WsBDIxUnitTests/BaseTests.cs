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


    }
}
