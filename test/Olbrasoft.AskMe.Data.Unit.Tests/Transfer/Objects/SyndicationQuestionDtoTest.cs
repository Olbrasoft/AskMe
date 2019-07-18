using System;
using Altairis.AskMe.Data.Transfer.Objects;
using NUnit.Framework;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Transfer.Objects
{
    public class SyndicationQuestionDtoTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = int.MaxValue;

            //Act
            var question = new SyndicationQuestionDto
            {
                Id = id
            };

            //Assert
            Assert.AreEqual(id, question.Id);
        }

        [Test]
        public void QuestionText()
        {
            //Arrange
            const string text = "Awesome Text";

            //Act
            var question = new SyndicationQuestionDto
            {
                QuestionText = text
            };

            //Assert
            Assert.AreEqual(text, question.QuestionText);
        }


        [Test]
        public void DateAnswered()
        {
            //Arrange
            var date = DateTime.Now;

            //Act
            var question =  new SyndicationQuestionDto
            {
                DateAnswered = date
            };

            //Assert
            Assert.AreEqual(date, question.DateAnswered);
        }


        [Test]
        public void CategoryName()
        {
            //Arrange
            const string categoryName = "Awesome category name";

            //Act
            var question = new SyndicationQuestionDto
            {
                CategoryName = categoryName
            };

            //Assert
            Assert.AreEqual(categoryName,question.CategoryName);
        }

    }
}