using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Web.DotVVM {
    public static class MapperConfig {
        public static void Configure() {
            Mapper.Initialize(m => {
                m.CreateMap<Question, QuestionDto>();
                m.CreateMap<Question, UnansweredQuestionDto>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
