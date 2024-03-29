﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Queries;
using Altairis.AskMe.Data.Transfer.Objects;
using Moq;
using NUnit.Framework;
using Olbrasoft.AskMe.Business.Services;
using Olbrasoft.Commanding;
using Olbrasoft.Querying;
using Olbrasoft.Querying.Business;

namespace Olbrasoft.AskMe.Business.Tests.Services
{
    public class CategoryServiceTest
    {
        [Test]
        public void Instance_Is_Service()
        {
            //Arrange
            var type = typeof(ServiceWithQueryFactory);

            //Act
            var service = CategoryService();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void Instance_Implement_Interface_ICategories()
        {
            //Arrange
            var type = typeof(ICategories);

            //Act
            var service = CategoryService();

            //Assert
            Assert.IsInstanceOf(type, service);
        }

        [Test]
        public void GetAsync_Returns_Task_Of_IEnumerable_CategoryListItemDto()
        {
            //Arrange
            var service = CategoryService();

            //Act
            var result = service.GetAsync();

            //Assert
            Assert.IsInstanceOf<Task<IEnumerable<CategoryListItemDto>>>(result);
        }

        private static CategoryService CategoryService()
        {
            var queryFactoryMock = new Mock<IQueryFactory>();

            var dispatcherMock = new Mock<IQueryDispatcher>();

            queryFactoryMock.Setup(p => p.CreateQuery<CategoriesListItemsQuery>())
                .Returns(new CategoriesListItemsQuery(dispatcherMock.Object));

            var service = new CategoryService(queryFactoryMock.Object);
            return service;
        }
    }
}