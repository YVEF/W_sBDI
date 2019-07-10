using NUnit.Framework;
using W_sBDI;
using W_sBDITest1.Moqs;

namespace Tests
{
    public class ContainerTest
    {
        ContainerBuilder builder;

        [SetUp]
        public void Setup()
        {
            builder = new ContainerBuilder();
        }

        [Test]
        public void ContainerIsBuilded()
        {
            Assert.IsNotNull(builder);
        }

        [Test]
        public void TypesAreResolved()
        {
            builder.DefineType<IBaseObject>().As<BaseObject>();
            var container = builder.Build();
            IBaseObject baseObject = container.Resolve<IBaseObject>();
            Assert.IsNotNull(baseObject);
            Assert.AreEqual("It's working", baseObject.Value);
        }
    }



}