namespace Scorpion.Core.Contracts.ApplicationServices.Common;

/// <summary>
/// Application service different status results
/// </summary>
public enum ApplicationServiceStatus
{
    Ok = 1,
    NotFound = 2,
    ValidationError = 3,
    InvalidDomainState = 4,
    Exception = 5,
}