namespace Scorpion.Core.Domain.Exceptions
{
    /// <summary>
    /// Domain layer errors related to Entities and Value Objects are sent to higher layers with the help of Extension.
    /// Considering that both Entity and Value Object send the error in the same way, an Exception class has been designed and implemented.
    /// In order to be able to recognize the difference between the error and its place of occurrence in the higher layers, the MicroType pattern is used.
    /// </summary>
    public abstract class DomainStateException : Exception
    {
        /// <summary>
        /// List of error parameters
        /// If there is a parameter, send the message as a template and the values of the parameters are placed in a special place in the template.
        /// </summary>
        public string[]? Parameters { get; set; }

        /// <summary>
        /// Domain state exception message builder
        /// </summary>
        /// <param name="message">Error message or message pattern</param>
        /// <param name="parameters">Parameters that are placed in the message pattern if present</param>
        public DomainStateException(string message, params string[] parameters) : base(message)
        {
            Parameters = parameters;
        }

        /// <summary>
        /// Converts domain dtate exception to string
        /// </summary>
        /// <returns>Domain state exception message string</returns>
        public override string ToString()
        {
            if (Parameters?.Length < 1)
            {
                return Message;
            }
            string result = Message;

            for (int i = 0; i < Parameters?.Length; i++)
            {
                string placeHolder = $"{{{i}}}";
                result = result.Replace(placeHolder, Parameters[i]);
            }

            return result;
        }
    }
}