using Ops.Domain.Common;
using Ops.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Domain.Entities
{
    public class User : BaseEntity
    {
        public string? UserName { get; set; }
        public string? PasswordHash { get; set; }
        public UserRole Role { get; set; } //0-Admin, 1-Superuser, 2-User
        public string MobileNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
