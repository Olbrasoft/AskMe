using System;

namespace Altairis.AskMe.Data.Transfer.Objects
{
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