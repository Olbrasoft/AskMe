using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Mapping.Profiles
{
    public class QuestionToUnansweredQuestionDtoProfile :Profile
    {
        public QuestionToUnansweredQuestionDtoProfile()
        {
            CreateMap<Question, UnansweredQuestionDto>();
        }
    }
}