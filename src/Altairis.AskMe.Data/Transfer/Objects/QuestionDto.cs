using System;

namespace Altairis.AskMe.Data.Transfer.Objects
{
    public class QuestionDto : UnansweredQuestionDto
    {
        public DateTime DateAnswered { get; set; }

        public string AnswerText { get; set; }
    }
}