namespace Farjad.Core.Contracts.ApplicationServices.Commands;

/// <summary>
/// An TCommand command is received and the appropriate implementation manages this command.
/// </summary>
/// <typeparam name="TCommand">Specifies the command type</typeparam>
/// <typeparam name="TData">The data type returned from the command</typeparam>
public interface ICommandHandler<TCommand, TData> where TCommand : ICommand<TData>
{
    Task<CommandResult<TData>> Handle(TCommand request);
}

/// <summary>
/// An TCommand command is received and the appropriate implementation manages this command.
/// </summary>
/// <typeparam name="TCommand">Specifies the command type</typeparam>
public interface ICommandHandler<TCommand> where TCommand : ICommand
{
    Task<CommandResult> Handle(TCommand request);
}