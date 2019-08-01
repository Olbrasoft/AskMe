using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Web.DotVVM {
    public static class MapperConfig {
        public static void Configure() {
#pragma warning disable 618
            Mapper.Initialize(m => {
#pragma warning restore 618
                m.CreateMap<Question, QuestionDto>();
                m.CreateMap<Question, UnansweredQuestionDto>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
