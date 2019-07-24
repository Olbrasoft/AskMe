using Xunit;

namespace Olbrasoft.Extensions
{
    public class TypeExtensionTest
    {
        [Fact]
        public void ImplementsGenericInterface()
        {
            var type = typeof(AwesomeClassImplementsGenericInterface);

            var typeInterface = typeof(IAwesomeGenericInterface<>);

            Assert.True(type.ImplementsGenericInterface(typeInterface));
        }

        [Fact]
        public void ImplementsGenericInterface_When_TypeInterface_Is_TypeOf_GenericClass_Return_False()
        {
            var type = typeof(AwesomeClass);

            var typeGenericClass = typeof(AwesomeGenericClass<>);

            Assert.False(type.ImplementsGenericInterface(typeGenericClass));
        }
    }

    public class AwesomeClass : AwesomeGenericClass<bool>
    {
    }

    // ReSharper disable once UnusedTypeParameter
    public class AwesomeGenericClass<T>
    {
    }

    // ReSharper disable once UnusedTypeParameter
    public interface IAwesomeGenericInterface<T>
    {
    }

    public class AwesomeClassImplementsGenericInterface : IAwesomeGenericInterface<bool>
    {
    }
}