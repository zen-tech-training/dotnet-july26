using Ops.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Application.DTOs.User
{
    public class CreateUserDto
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public UserRole Role { get; set; }
        public string MobileNumber { get; set; } = string.Empty;
        public string? Email { get; set; }
    }
}
