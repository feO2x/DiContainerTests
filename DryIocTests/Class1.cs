using DryIoc;
using FluentAssertions;
using SampleTypes;
using Xunit;

namespace DryIocTests
{
    public class TestsForDryIoc : BaseTest
    {
        private readonly Container _container;

        public TestsForDryIoc()
        {
            _container = new Container();
            _container.Register<ISampleInterface, SampleClass>();
            _container.RegisterInstance(typeof(int), Value2);
            _container.RegisterInstance(typeof(string), Value1);
        }

        [Fact]
        public void ResolveWithoutParameters()
        {
            var instance = _container.Resolve<ISampleInterface>();
            instance.Value1.Should().Be(Value1);
            instance.Value2.Should().Be(Value2);
        }

        // Cannot override parameters in DryIoc
    }
}