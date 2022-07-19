namespace Farjad.Core.Contracts.ApplicationServices.Queries;

/// <summary>
/// Base class to be used as a marker for classes that define input parameters for searching!
/// This class is used if the search requires pagination.
/// </summary>
public class PageQuery<TData> : IPageQuery<TData>
{
    /// <summary>
    /// Page number from which information should be loaded.
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// Number of records per page.
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// The number of records that must be skipped from the beginning of the result to reach the desired records.
    /// </summary>
    public int SkipCount => (PageNumber - 1) * PageSize;

    /// <summary>
    /// Determines whether the total number of records in the search also needs to be returned.
    /// </summary>
    public bool NeedTotalCount { get; set; }

    /// <summary>
    /// Specify the column on which to sort.
    /// Default value is Id
    /// </summary>
    public string SortBy { get; set; } = "Id";

    /// <summary>
    /// To sort the data in ascending or descending order.
    /// </summary>
    public bool SortAscending { get; set; }
}

/// <summary>
/// The base record to use as a marker for the records that define the input parameters for the search!
/// This class is used if the search requires pagination.
/// </summary>
public record PageQueryRecord<TData> : IPageQuery<TData>
{
    /// <summary>
    /// Page number from which information should be loaded.
    /// Default page number is 1
    /// </summary>
    public int PageNumber { get; set; } = 1;

    /// <summary>
    /// The number of records that must be skipped from the beginning of the result to reach the desired records.
    /// Default page size is 10.
    /// </summary>
    public int PageSize { get; set; } = 10;

    /// <summary>
    /// The number of records that must be skipped from the beginning of the result to reach the desired records.
    /// </summary>
    public int SkipCount => (PageNumber - 1) * PageSize;

    /// <summary>
    /// Determines whether the total number of records in the search also needs to be returned.
    /// </summary>
    public bool NeedTotalCount { get; set; }

    /// <summary>
    /// Specify the column on which to sort.
    /// Default value is Id
    /// </summary>
    public string SortBy { get; set; } = "Id";

    /// <summary>
    /// To sort the data in ascending or descending order.
    /// </summary>
    public bool SortAscending { get; set; }
}