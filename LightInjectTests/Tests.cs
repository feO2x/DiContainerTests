﻿using FluentAssertions;
using LightInject;
using SampleTypes;
using Xunit;

namespace LightInjectTests
{
    public sealed class TestsForLightInject : BaseTest
    {
        private readonly ServiceContainer _serviceContainer = new ServiceContainer();

        public TestsForLightInject()
        {
            _serviceContainer.RegisterInstance(Value1);
            _serviceContainer.RegisterInstance(Value2);
            _serviceContainer.Register<ISampleInterface, SampleClass>();
            _serviceContainer.Register<string, ISampleInterface>((factory, value) => new SampleClass(value, factory.GetInstance<int>()));
        }

        [Fact]
        public void SampleInterfaceCanBeCreatedWithoutParameters()
        {
            var instance = _serviceContainer.GetInstance<ISampleInterface>();
            instance.Value1.Should().Be(Value1);
            instance.Value2.Should().Be(Value2);
        }

        [Fact]
        public void ParametersCanBeOverriddenWithLightInject()
        {
            var instance = _serviceContainer.GetInstance<string, ISampleInterface>("Bar");
            instance.Value1.Should().Be("Bar").And.NotBe(Value1);
            instance.Value2.Should().Be(Value2);
        }
    }
}