using System;
using System.Collections.Generic;
using System.Text;
using Altairis.AskMe.Data.Base.Objects;
using FluentNHibernate.Mapping;
using NHibernate.Mapping;

namespace Olbrasoft.AskMe.Data.NHibernate.Maps
{
    class QuestionMap : ClassMap<Question>
    {
        public QuestionMap()
        {
            Table("Questions");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.DateCreated);
            Map(x => x.DateAnswered);
            Map(x => x.QuestionText).Not.Nullable();
            Map(x => x.DisplayName);
            Map(x => x.EmailAddress);
            Map(x => x.AnswerText);
            References(x => x.Category).Column("CategoryId").Not.Nullable();
        }
    }
    
}
