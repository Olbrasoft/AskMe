using System;
using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Transfer.Objects
{
    [AutoMap(typeof(Question), IncludeAllDerived = true)]
    public class UnansweredQuestionDto
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string QuestionText { get; set; }

        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}