using System;
using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Transfer.Objects
{
    [AutoMap(typeof(Question))]
    public class SyndicationQuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public DateTime DateAnswered { get; set; }
        public string CategoryName { get; set; }
    }
}