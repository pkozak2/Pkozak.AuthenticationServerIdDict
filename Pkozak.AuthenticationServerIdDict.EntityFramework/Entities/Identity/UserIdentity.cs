using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pkozak.AuthenticationServerIdDict.EntityFramework.Entities.Identity
{
    public class UserIdentity : IdentityUser<Guid>
    {
        [MaxLength(64)]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(64)]
        public string LastName { get; set; } = string.Empty;

        public string FullName => $"{FirstName} {LastName}";
    }
}
