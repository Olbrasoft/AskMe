namespace Olbrasoft.Data.Unit.Tests
{
    public class AnotherQueryWithSortingQuery : QueryWithSorting<object, string>, IAnotherQuery
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
    }
}