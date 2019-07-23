using Altairis.AskMe.Data.Base.Objects;
using Altairis.AskMe.Data.Transfer.Objects;
using AutoMapper;

namespace Altairis.AskMe.Data.Mapping.Profiles
{
    public class CategoryToCategoryListItemDtoProfile :MapProfile<Category, CategoryListItemDto>
    {
        public CategoryToCategoryListItemDtoProfile()
        {
            Expression
                .ForMember(d => d.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(d=>d.Text , opt=>opt.MapFrom(src=>src.Name))
                ; 
        }
    }
}