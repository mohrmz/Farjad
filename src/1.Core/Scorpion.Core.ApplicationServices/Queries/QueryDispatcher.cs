﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scorpion.Core.Contracts.ApplicationServices.Queries;
using Scorpion.Extensions.Logger.Abstractions;
using System.Diagnostics;


namespace Scorpion.Core.ApplicationServices.Queries;

public class QueryDispatcher : IQueryDispatcher
{
    #region Fields

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<QueryDispatcher> _logger;
    private readonly Stopwatch _stopwatch;

    #endregion Fields

    #region Constructors

    public QueryDispatcher(IServiceProvider serviceProvider, ILogger<QueryDispatcher> logger)
    {
        _serviceProvider = serviceProvider;
        _stopwatch = new Stopwatch();
        _logger = logger;
    }

    #endregion Constructors

    #region Query Dispatcher

    public Task<QueryResult<TData>> Execute<TQuery, TData>(TQuery query) where TQuery : class, IQuery<TData>
    {
        _stopwatch.Start();
        try
        {
            _logger.LogDebug("Routing query of type {QueryType} With value {Query}  Start at {StartDateTime}", query.GetType(), query, DateTime.Now);
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TData>>();
            return handler.Handle(query);
        }
        catch (InvalidOperationException ex)
        {
            _logger.LogError(ex, "There is not suitable handler for {QueryType} Routing failed at {StartDateTime}.", query.GetType(), DateTime.Now);
            throw;
        }
        finally
        {
            _stopwatch.Stop();
            _logger.LogInformation(ScorpionEventId.PerformanceMeasurement, "Processing the {QueryType} command tooks {Millisecconds} Millisecconds", query.GetType(), _stopwatch.ElapsedMilliseconds);
        }
    }

    #endregion Query Dispatcher
}