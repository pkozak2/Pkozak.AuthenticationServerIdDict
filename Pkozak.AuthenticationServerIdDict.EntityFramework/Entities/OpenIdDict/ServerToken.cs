using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Pkozak.AuthenticationServerIdDict.EntityFramework.Entities.OpenIdDict
{
    public class ServerToken : OpenIddictEntityFrameworkCoreToken<Guid, ServerApplication, ServerAuthorization>
    {
    }
}
