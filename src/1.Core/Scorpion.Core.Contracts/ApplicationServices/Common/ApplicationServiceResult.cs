namespace Scorpion.Core.Contracts.ApplicationServices.Common;

/// <summary>
/// This class is desired for transfer application services result
/// </summary>
public abstract class ApplicationServiceResult : IApplicationServiceResult
{
    protected readonly List<string> _messages = new();

    public IEnumerable<string> Messages => _messages;

    public ApplicationServiceStatus Status { get; set; }

    public void AddMessage(string error) => _messages.Add(error);

    public void AddMessages(IEnumerable<string> errors) => _messages.AddRange(errors);

    public void ClearMessages() => _messages.Clear();
}