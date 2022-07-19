using Farjad.Core.Contracts.ApplicationServices.Common;

namespace Farjad.Core.Contracts.ApplicationServices.Commands;

/// <summary>
/// The result of each operation is returned with the help of this class.
/// You can see the reasons for using this template and the full implementation of this template in the link below.
/// https://github.com/vkhorikov/CqrsInPractice
/// </summary>
public class CommandResult : ApplicationServiceResult
{
}

/// <summary>
/// The result of each operation is returned with the help of this class.
/// You can see the reasons for using this template and the full implementation of this template in the link below.
/// This structure is used if output value is needed for operation.
/// https://github.com/vkhorikov/CqrsInPractice
/// </summary>
/// <typeparam name="TData">The data type to return.</typeparam>
public class CommandResult<TData> : CommandResult
{
    public TData? _data;
    public TData? Data => _data;
}