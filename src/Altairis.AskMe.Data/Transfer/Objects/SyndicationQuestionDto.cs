using System;

namespace Altairis.AskMe.Data.Transfer.Objects
{
    public class SyndicationQuestionDto
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }
        public DateTime DateAnswered { get; set; }
        public string CategoryName { get; set; }
    }
}