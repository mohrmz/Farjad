using Scorpion.Core.Contracts.ApplicationServices.Common;

namespace Scorpion.Core.Contracts.ApplicationServices.Queries;

/// <summary>
/// Returns the result of a query
/// </summary>
/// <typeparam name="TData">Specifies the type of the returned data</typeparam>
public sealed class QueryResult<TData> : ApplicationServiceResult
{
    private TData? _data;

    public TData? Data
    {
        get
        {
            return _data;
        }
    }
}