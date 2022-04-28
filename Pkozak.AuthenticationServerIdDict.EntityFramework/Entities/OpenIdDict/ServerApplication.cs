using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Pkozak.AuthenticationServerIdDict.EntityFramework.Entities.OpenIdDict
{
    public class ServerApplication : OpenIddictEntityFrameworkCoreApplication<Guid, ServerAuthorization, ServerToken>
    {
    }
}
