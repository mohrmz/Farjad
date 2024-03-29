﻿using Farjad.Core.Contracts.Data.Queries;

namespace Farjad.Infrastructures.Data.SqlServer.Queries;

public class BaseQueryRepository<TDbContext> : IQueryRepository
    where TDbContext : BaseQueryDbContext
{
    protected readonly TDbContext _dbContext;

    public BaseQueryRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}