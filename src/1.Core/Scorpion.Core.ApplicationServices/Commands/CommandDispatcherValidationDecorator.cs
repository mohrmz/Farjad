﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Scorpion.Core.Contracts.ApplicationServices.Commands;
using Scorpion.Core.Contracts.ApplicationServices.Common;
using Scorpion.Extensions.Logger.Abstractions;

namespace Scorpion.Core.ApplicationServices.Commands;

public class CommandDispatcherValidationDecorator : CommandDispatcherDecorator
{
    #region Fields

    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<CommandDispatcherValidationDecorator> _logger;

    #endregion Fields

    #region Constructors

    public CommandDispatcherValidationDecorator(CommandDispatcherDomainExceptionHandlerDecorator commandDispatcher,
                                                IServiceProvider serviceProvider, ILogger<CommandDispatcherValidationDecorator> logger)
                                                : base(commandDispatcher)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    #endregion Constructors

    #region Send Commands

    public override async Task<CommandResult> Send<TCommand>(TCommand command)
    {
        _logger.LogDebug(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  start at :{StartDateTime}", command.GetType(), command, DateTime.Now);
        var validationResult = Validate<TCommand, CommandResult>(command);

        if (validationResult != null)
        {
            _logger.LogInformation(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  failed. Validation errors are: {ValidationErrors}", command.GetType(), command, validationResult.Messages);
            return validationResult;
        }
        _logger.LogDebug(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  finished at :{EndDateTime}", command.GetType(), command, DateTime.Now);
        return await _commandDispatcher.Send(command);
    }

    public override async Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command)
    {
        _logger.LogDebug(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  start at :{StartDateTime}", command.GetType(), command, DateTime.Now);

        var validationResult = Validate<TCommand, CommandResult<TData>>(command);

        if (validationResult != null)
        {
            _logger.LogInformation(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  failed. Validation errors are: {ValidationErrors}", command.GetType(), command, validationResult.Messages);
            return validationResult;
        }
        _logger.LogDebug(ScorpionEventId.CommandValidation, "Validating command of type {CommandType} With value {Command}  finished at :{EndDateTime}", command.GetType(), command, DateTime.Now);
        return await _commandDispatcher.Send<TCommand, TData>(command);
    }

    #endregion Send Commands

    #region Privaite Methods

    private TValidationResult Validate<TCommand, TValidationResult>(TCommand command) where TValidationResult : ApplicationServiceResult, new()
    {
        var validator = _serviceProvider.GetService<IValidator<TCommand>>();
        TValidationResult res = null;

        if (validator != null)
        {
            var validationResult = validator.Validate(command);
            if (!validationResult.IsValid)
            {
                res = new()
                {
                    Status = ApplicationServiceStatus.ValidationError
                };
                foreach (var item in validationResult.Errors)
                {
                    res.AddMessage(item.ErrorMessage);
                }
            }
        }
        else
        {
            _logger.LogInformation(ScorpionEventId.CommandValidation, "There is not any validator for {CommandType}", command.GetType());
        }
        return res;
    }

    #endregion Privaite Methods
}