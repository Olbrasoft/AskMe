using Altairis.AskMe.Data.Base.Objects;
using AutoMapper;
using AutoMapper.Configuration.Annotations;

namespace Altairis.AskMe.Data.Transfer.Objects {

    [AutoMap(typeof(Category))]
    public class CategoryListItemDto {

        [SourceMember(nameof(Category.Name) )]
        public string Text { get; set; }

        [SourceMember(nameof(Category.Id))]
        public int Value { get; set; }
    }
}
