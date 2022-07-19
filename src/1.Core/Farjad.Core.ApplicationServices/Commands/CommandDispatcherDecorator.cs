using Farjad.Core.Contracts.ApplicationServices.Commands;

namespace Farjad.Core.ApplicationServices.Commands;

public abstract class CommandDispatcherDecorator : ICommandDispatcher
{
    #region Fields

    protected ICommandDispatcher _commandDispatcher;

    #endregion Fields

    #region Constructors

    public CommandDispatcherDecorator(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    #endregion Constructors

    #region Abstract Send Commands

    public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;

    public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;

    #endregion Abstract Send Commands
}