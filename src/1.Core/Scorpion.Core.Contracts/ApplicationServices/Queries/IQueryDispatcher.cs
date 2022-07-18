namespace Scorpion.Core.Contracts.ApplicationServices.Queries;

/// <summary>
/// Defining the structure of the Mediator pattern to easily connect queries to handlers.
/// </summary>
public interface IQueryDispatcher
{
    /// <summary>
    /// An TQuery query is received and the appropriate implementation is found to manage this query and the work is handed over to that implementation to continue processing.
    /// </summary>
    /// <typeparam name="TQuery">Specifies the query type</typeparam>
    /// <typeparam name="TData">The data type returned from the query</typeparam>
    /// <param name="query">The name of the query</param>
    /// <returns>Appropriate query result data</returns>
    Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>;
}