﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Farjad.Extensions.Serializers.Abstractions;
using Farjad.Extensions.UsersManagement.Abstractions;
using Farjad.Infrastructures.Data.SqlServer.Commands.Extensions;
using Farjad.Infrastructures.Data.SqlServer.Commands.OutBoxEventItems;


namespace Farjad.Infrastructures.Data.SqlServer.Commands;

public abstract class BaseOutboxCommandDbContext : BaseCommandDbContext
{
    public DbSet<OutBoxEventItem> OutBoxEventItems { get; set; }

    public BaseOutboxCommandDbContext(DbContextOptions options) : base(options)
    {
    }

    protected BaseOutboxCommandDbContext()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfiguration(new OutBoxEventItemConfig());
    }

    protected override void BeforeSaveTriggers()
    {
        base.BeforeSaveTriggers();
        AddOutboxEvetItems();
    }

    private void AddOutboxEvetItems()
    {
        var changedAggregates = ChangeTracker.GetAggregatesWithEvent();
        var userInfoService = this.GetService<IUserInfoService>();
        var serializer = this.GetService<IJsonSerializer>();
        foreach (var aggregate in changedAggregates)
        {
            var events = aggregate.GetEvents();
            foreach (var @event in events)
            {
                OutBoxEventItems.Add(new OutBoxEventItem
                {
                    EventId = Guid.NewGuid(),
                    AccuredByUserId = userInfoService.UserId().ToString(),
                    AccuredOn = DateTime.Now,
                    AggregateId = aggregate.BusinessId.ToString(),
                    AggregateName = aggregate.GetType().Name,
                    AggregateTypeName = aggregate.GetType().FullName,
                    EventName = @event.GetType().Name,
                    EventTypeName = @event.GetType().FullName,
                    EventPayload = serializer.Serialize(@event),
                    IsProcessed = false
                });
            }
        }
    }
}