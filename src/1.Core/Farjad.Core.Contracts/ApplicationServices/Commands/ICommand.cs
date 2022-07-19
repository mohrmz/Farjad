namespace Farjad.Core.Contracts.ApplicationServices.Commands;

/// <summary>
/// This interface is used to mark the class that has the input parameters of the command
/// </summary>
public interface ICommand
{
}

/// <summary>
/// This interface is used to mark the class that has the input parameters of the command
/// This interface is used if the output value should be returned for the sent command
/// </summary>
/// <typeparam name="TData">The data type to be returned by the command</typeparam>
public interface ICommand<TData>
{
}