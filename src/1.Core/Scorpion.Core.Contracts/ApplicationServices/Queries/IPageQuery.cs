namespace Scorpion.Core.Contracts.ApplicationServices.Queries;

/// <summary>
/// An interface to be used as a marker for classes that define input parameters for searching!
/// This interface is used if the search requires pagination.
/// </summary>
public interface IPageQuery<TData> : IQuery<TData>
{
    /// <summary>
    /// Page number from which information should be loaded.
    /// </summary>
    public int PageNumber { get; set; }

    /// <summary>
    /// Number of records per page.
    /// </summary>
    public int PageSize { get; set; }

    /// <summary>
    /// The number of records that must be skipped from the beginning of the result to reach the desired records.
    /// </summary>
    public int SkipCount => (PageNumber - 1) * PageSize;

    /// <summary>
    /// Determines whether the total number of records in the search also needs to be returned.
    /// </summary>
    public bool NeedTotalCount { get; set; }

    /// <summary>
    /// Specify the column on which to ascending sort.
    /// </summary>
    public string SortBy { get; set; }

    /// <summary>
    /// To sort the data in ascending or descending order.
    /// </summary>
    public bool SortAscending { get; set; }
}