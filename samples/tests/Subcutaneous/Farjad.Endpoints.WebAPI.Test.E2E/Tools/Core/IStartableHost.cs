namespace Farjad.Endpoints.WebAPI.Test.E2E.Tools.Core
{
    public interface IStartableHost : IHost
    {
        void Start();
        void Stop();
    }
}
