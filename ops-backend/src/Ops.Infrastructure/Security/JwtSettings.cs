using System;
using System.Collections.Generic;
using System.Text;

namespace Ops.Infrastructure.Security
{
    public class JwtSettings
    {
        public const string SectionName = "Jwt";

        public string Issuer { get; set; } = string.Empty;

        public string Audience { get; set; } = string.Empty;

        public string SecretKey { get; set; } = string.Empty;

        public int ExpiryInMinutes { get; set; }
    }
}
