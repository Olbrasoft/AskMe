namespace Olbrasoft.Data.Unit.Tests
{
    public class SomQuery : QueryWithSorting<object, object>, ISomeQueryWithSorting
    {
        public int Id { get; set; }
    }
}