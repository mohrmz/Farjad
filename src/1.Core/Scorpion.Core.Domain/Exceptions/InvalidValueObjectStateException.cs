namespace Scorpion.Core.Domain.Exceptions
{
    /// <summary>
    /// Errors related to incorrect status in Value Objects are sent by this class.
    /// </summary>
    /// <param name="message">Error message or message pattern</param>
    /// <param name="parameters">Parameters that are placed in the message pattern if present</param>
    public class InvalidValueObjectStateException : DomainStateException
    {
        public InvalidValueObjectStateException(string message, params string[] parameters) : base(message, parameters)
        {
            Parameters = parameters;
        }
    }
}