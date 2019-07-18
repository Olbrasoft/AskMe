using System.Collections.Generic;

namespace Olbrasoft.Data
{
    public interface IHaveLocalizedTypes<T>
    {
        ICollection<T> LocalizedSuggestionCategories { get; }
    }
}