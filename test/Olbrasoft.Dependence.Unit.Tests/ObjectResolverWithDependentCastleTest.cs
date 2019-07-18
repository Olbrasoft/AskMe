using Castle.MicroKernel;
using Moq;
using NUnit.Framework;
using System;
using Olbrasoft.Dependence.Inversion.Of.Control.Containers.Castle;

namespace Olbrasoft.Dependence.Unit.Tests
{
    [TestFixture]
    internal class ObjectResolverWithDependentCastleTest
    {
        [Test]
        public void Instance_Implement_Interface_IResolver()
        {
            //Arrange
            var type = typeof(IResolver);
            var kernelMock = CreateKernelMock();

            //Act
            var resolver = new ObjectResolverWithDependentCastle(kernelMock.Object);

            //Assert
            Assert.IsInstanceOf(type, resolver);
        }

        private static Mock<IKernelInternal> CreateKernelMock()
        {
            return new Mock<IKernelInternal>();
        }

        [Test]
        public void Resolve()
        {
            //Arrange
            var obj = new object();
            var kernelMock = new Mock<IKernelInternal>();
            kernelMock.Setup(p => p.Resolve(It.IsAny<Type>())).Returns(obj);
            var resolver = new ObjectResolverWithDependentCastle(kernelMock.Object);

            //Act
            var result = resolver.Resolve(typeof(object));

            //Assert
            Assert.AreSame(result, obj);
        }
    }
}