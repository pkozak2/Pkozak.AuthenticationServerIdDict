using Pkozak.AuthenticationServerIdDict.Shared.Configuration.Enums;

namespace Pkozak.AuthenticationServerIdDict.Shared.Configuration
{
    public class LoginConfiguration
    {
        public LoginResolutionPolicy ResolutionPolicy { get; set; } = LoginResolutionPolicy.Username;
    }
}
