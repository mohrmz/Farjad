namespace Scorpion.Core.Contracts.ApplicationServices.Queries;

/// <summary>
/// Defining the structure required to process a query.
/// </summary>
/// <typeparam name="TQuery">Specifies the query type and input parameters</typeparam>
/// <typeparam name="TData">Specifies the type of the returned data</typeparam>
public interface IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    /// <summary>
    /// An TQuery qury is received and the appropriate implementation manages this query.
    /// </summary>
    /// <param name="request">Specifies the query type</param>
    /// <returns>Appropriate query data result</returns>
    Task<QueryResult<TData>> Handle(TQuery request);
}