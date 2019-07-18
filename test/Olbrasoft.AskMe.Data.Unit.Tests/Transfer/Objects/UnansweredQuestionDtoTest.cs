using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Altairis.AskMe.Data.Transfer.Objects;
using NUnit.Framework;
using static System.Int32;

namespace Olbrasoft.AskMe.Data.Unit.Tests.Transfer.Objects
{
    public class UnansweredQuestionDtoTest
    {
        [Test]
        public void Id()
        {
            //Arrange
            const int id = 1976;

            //Act
            var question = new UnansweredQuestionDto()
            {
                Id = id
            };

            
            //Assert
            Assert.AreEqual(id,question.Id);
        }


        [Test]
        public void DateCreated()
        {
            //Arrange
            var dateCreated = DateTime.Now;

            //Act
            var question = new UnansweredQuestionDto
            {
                DateCreated = dateCreated
            };

            //Assert
            Assert.AreEqual(dateCreated,question.DateCreated);
        }


        [Test]
        public void QuestionText()
        {
            //Arrange
            const string questionText = "Some question text";

            //Act
            var question = new UnansweredQuestionDto()
            {
                QuestionText = questionText
            };

            //Assert
            Assert.AreEqual(questionText,question.QuestionText);

        }


        [Test]
        public void DisplayName()
        {
            //Arrange
            const string displayName = "Some Display Name";

            //Act
            var question = new UnansweredQuestionDto()
            {
                DisplayName = displayName
            };

            //Assert
            Assert.AreEqual(displayName, question.DisplayName);

        }


        [Test]
        public void CategoryId()
        {
            //Arrange
            const int categoryId = MaxValue;

            //Act
            var question = new UnansweredQuestionDto()
            {
                CategoryId = categoryId
            };


            //Assert
            Assert.AreEqual(categoryId,question.CategoryId);
        }
        

        [Test]
        public void CategoryName()
        {
            //Arrange
            const string categoryName = "Some category name";

            //Act
            var question = new UnansweredQuestionDto()
            {
                CategoryName = categoryName
            };
            
            //Assert
            Assert.AreEqual(categoryName,question.CategoryName);
        }

    }
}
