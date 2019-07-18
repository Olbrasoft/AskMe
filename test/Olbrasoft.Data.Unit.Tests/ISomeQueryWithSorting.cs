namespace Olbrasoft.Data.Unit.Tests
{
    public interface ISomeQueryWithSorting : IQueryWithSorting<object, object>
    {
        int Id { get; set; }
    }
}