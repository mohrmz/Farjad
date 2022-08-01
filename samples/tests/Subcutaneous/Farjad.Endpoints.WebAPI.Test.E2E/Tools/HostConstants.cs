namespace Farjad.Endpoints.WebAPI.Test.E2E.Tools
{
    public static class HostConstants
    {
        public static readonly string CsProjectPath = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.FullName + "\\Farjad.Endpoints.WebAPI\\Farjad.Endpoints.WebAPI.csproj";
        public const int Port = 5001;
        public static readonly string Endpoint = $"https://localhost:{Port}/";
    }
}
