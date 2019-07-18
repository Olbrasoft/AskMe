using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Mapping.Profiles
{
    public class QuestionToAnsweredQuestionDtoProfile : Profile
    {
        public QuestionToAnsweredQuestionDtoProfile()
        {
            CreateMap<Question, QuestionDto>();
        }
    }
}