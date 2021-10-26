using System;
using System.Collections.Generic;

namespace Passenger.Infrastructure.Settings
{
    public class JwtSettings
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public int ExpireMinutes { get; set; }
    }
}
