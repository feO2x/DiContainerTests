using FluentAssertions;
using Ninject;
using Ninject.Parameters;
using SampleTypes;
using Xunit;

namespace NinjectTests
{
    public class TestsForNinject : BaseTest
    {
        private readonly IKernel _container;

        public TestsForNinject()
        {
            _container = new StandardKernel();
            _container.Bind<ISampleInterface>().To<SampleClass>();
            _container.Bind<int>().ToConstant(Value2);
            _container.Bind<string>().ToConstant(Value1);
        }

        [Fact]
        public void CreationWithoutParameters()
        {
            var instance = _container.Get<ISampleInterface>();

            instance.Value1.Should().Be(Value1);
            instance.Value2.Should().Be(Value2);
        }

        [Fact]
        public void OverrideParameters()
        {
            var instance = _container.Get<SampleClass>(new ConstructorArgument("value1", "Bar"));
            instance.Value1.Should().Be("Bar");
            instance.Value2.Should().Be(Value2);
        }
    }
}