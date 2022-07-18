namespace Scorpion.Core.Contracts.ApplicationServices.Commands;

/// <summary>
/// Define structure to manage commands. Implementation of the Mediator pattern.
/// This pattern is used to reduce the complexity of calling commands.
/// </summary>
public interface ICommandDispatcher
{
    /// <summary>
    /// An TCommand command is received and the appropriate implementation is found to manage this command and the work is handed over to that implementation to continue processing.
    /// </summary>
    /// <typeparam name="TCommand">Specifies the command type</typeparam>
    /// <param name="command">The name of the command</param>
    /// <returns>Appropriate command  result</returns>
    Task<CommandResult> Send<TCommand>(TCommand command) where TCommand : class, ICommand;

    /// <summary>
    /// An TCommand command is received and the appropriate implementation is found to manage this command and the work is handed over to that implementation to continue processing.
    /// </summary>
    /// <typeparam name="TCommand">Specifies the command type</typeparam>
    /// <typeparam name="TData">The data type returned from the command</typeparam>
    /// <param name="command">The name of the command</param>
    /// <returns>Appropriate command  result with data</returns>
    Task<CommandResult<TData>> Send<TCommand, TData>(TCommand command) where TCommand : class, ICommand<TData>;
}