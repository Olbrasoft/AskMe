using Altairis.AskMe.Data.Base.Objects;
using FluentNHibernate.Mapping;

namespace Olbrasoft.AskMe.Data.NHibernate.Maps
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Not.Nullable();
        }
    }
}