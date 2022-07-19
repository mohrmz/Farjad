namespace Farjad.Extensions.Logger.Abstractions;
public interface IScopeInformation
{
    Dictionary<string, string> HostScopeInfo { get; }
    Dictionary<string, string> RequestScopeInfo { get; }
}

