using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Mapping.Profiles
{
    public class QuestionToSyndicationQuestionDtoProfile :Profile
    {
        public QuestionToSyndicationQuestionDtoProfile()
        {
            CreateMap<Question, SyndicationQuestionDto>();
        }
    }
}