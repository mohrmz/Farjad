using Farjad.Core.Contracts.ApplicationServices.Common;
using Farjad.Core.Contracts.ApplicationServices.Queries;
using Farjad.Utilities;

namespace Farjad.Core.ApplicationServices.Queries;

public abstract class QueryHandler<TQuery, TData> : IQueryHandler<TQuery, TData>
    where TQuery : class, IQuery<TData>
{
    protected readonly FarjadServices _FarjadServices;
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

    public QueryHandler(FarjadServices FarjadServices)
    {
        _FarjadServices = FarjadServices;
    }

    public abstract Task<QueryResult<TData>> Handle(TQuery request);
}