using OpenIddict.EntityFrameworkCore.Models;
using System;

namespace Pkozak.AuthenticationServerIdDict.EntityFramework.Entities.OpenIdDict
{
    public class ServerAuthorization : OpenIddictEntityFrameworkCoreAuthorization<Guid, ServerApplication, ServerToken>
    {
    }
}
