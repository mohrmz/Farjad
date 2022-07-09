using Scorpion.Core.Contracts.ApplicationServices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scorpion.Core.ApplicationServices.Commands;

public abstract class CommandDispatcherDecorator : ICommandDispatcher
{
    #region Fields
    protected ICommandDispatcher _commandDispatcher;
    #endregion

    #region Constructors
    public CommandDispatcherDecorator(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    #endregion

    #region Abstract Send Commands
    public abstract Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;

    public abstract Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
    #endregion
}