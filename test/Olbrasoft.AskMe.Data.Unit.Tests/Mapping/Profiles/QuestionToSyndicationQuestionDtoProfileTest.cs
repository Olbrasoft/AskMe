﻿using Altairis.AskMe.Data.Mapping.Profiles;
using AutoMapper;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Mapping.Profiles
{
    public class QuestionToSyndicationQuestionDtoProfileTest
    {
        [Test]
        public void Instance_Is_Profile()
        {
            //Arrange
            var type = typeof(Profile);

            //Act
            var profile = new QuestionToSyndicationQuestionDtoProfile();

            //Assert
            Assert.IsInstanceOf(type,profile);
        }
    }
}
