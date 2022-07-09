using Scorpion.Core.Contracts.ApplicationServices.Common;
using Scorpion.Core.Contracts.ApplicationServices.Queries;
using Scorpion.Utilities;

namespace Scorpion.Core.ApplicationServices.Queries;
public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    protected readonly ScorpionServices _scorpionServices;
    protected readonly QueryResult<TData> result = new();

    protected virtual Task<QueryResult<TData>> ResultAsync(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return Task.FromResult(result);
    }

    protected virtual QueryResult<TData> Result(TData data, ApplicationServiceStatus status)
    {
        result._data = data;
        result.Status = status;
        return result;
    }


    protected virtual Task<QueryResult<TData>> ResultAsync(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return ResultAsync(data, status);
    }

    protected virtual QueryResult<TData> Result(TData data)
    {
        var status = data != null ? ApplicationServiceStatus.Ok : ApplicationServiceStatus.NotFound;
        return Result(data, status);
    }

    public QueryHandler(ScorpionServices scorpionServices)
    {
        _scorpionServices = scorpionServices;
    }

    public abstract Task<QueryResult<TData>> Handle(TQuery request);
}
