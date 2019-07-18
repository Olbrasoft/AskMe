using Altairis.AskMe.Data.Mapping;
using AutoMapper;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Mapping
{
    public class MapperConfigurationProviderTest
    {
        [NUnit.Framework.Test]
        public void Instance_Is_MapperConfiguration()
        {
            //Arrange
            var type = typeof(MapperConfiguration);

            //Act
            var provider = new MapperConfigurationProvider();

            //Assert
            Assert.IsInstanceOf(type, provider);
        }
    }
}