using Scorpion.Core.Contracts.ApplicationServices.Commands;

namespace Scorpion.Samples.Core.Contracts.Peaple.Commands
{
    public class CreatePerson : ICommand<long>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
