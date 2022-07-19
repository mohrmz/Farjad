namespace Farjad.Core.Domain.Exceptions
{
    public class InvalidEntityStateException : DomainStateException
    {
        /// <summary>
        /// Errors related to incorrect status in Entities are sent by this class.
        /// </summary>
        /// <param name="message">Error message or message pattern</param>
        /// <param name="parameters">Parameters that are placed in the message template if present</param>
        public InvalidEntityStateException(string message, params string[] parameters) : base(message)
        {
            Parameters = parameters;
        }
    }
}