namespace Scorpion.Core.Contracts.Data.Queries;

/// <summary>
/// Basic structure for returning data when querying when paging.
/// </summary>
/// <typeparam name="T">Determines the type of data received from the query!</typeparam>
public class PagedData<T>
{
    public List<T>? QueryResult { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public int TotalCount { get; set; }
}