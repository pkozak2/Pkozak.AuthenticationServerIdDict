using Pkozak.AuthenticationServerIdDict.Shared.Configuration;

namespace Pkozak.AuthenticationServerIdDict.Configuration
{
    public interface IRootConfiguration
    {
        RegisterConfiguration RegisterConfiguration { get; }
    }

    public class RootConfiguration : IRootConfiguration
    {
        public RegisterConfiguration RegisterConfiguration { get; } = new RegisterConfiguration();
    }
}
