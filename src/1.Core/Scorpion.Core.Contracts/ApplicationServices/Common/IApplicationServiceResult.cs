namespace Scorpion.Core.Contracts.ApplicationServices.Common;

/// <summary>
/// This interface is desired for transfer application services result
/// </summary>
public interface IApplicationServiceResult
{
    IEnumerable<string> Messages { get; }
    ApplicationServiceStatus Status { get; set; }
}