﻿using Microsoft.Extensions.Logging;
using Scorpion.Extensions.MessageBus.Abstractions;

namespace Scorpion.Extensions.MessageBus.Abstractions.Fakes;

public class FakeReceiveMessageBus : IReceiveMessageBus
{
    private readonly ILogger<FakeSendMessageBus> _logger;

    public FakeReceiveMessageBus(ILogger<FakeSendMessageBus> logger)
    {
        _logger = logger;
    }

    public void Receive(string commandName)
    {
        _logger.LogInformation("fake message bus receive {commandName}", commandName);
    }

    public void Subscribe(string serviceId, string eventName)
    {
        _logger.LogInformation("fake message bus subscribe for event: {eventName} from service {serviceId}", eventName, serviceId);
    }
}
