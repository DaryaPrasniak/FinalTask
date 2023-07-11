using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestRailFinalTask.Models.Enums;

namespace TestRailFinalTask.Models
{
    public record User
    {
        public UserType UserType { get; set; }
        public string? Username { get; init; } = string.Empty;
        public string? Password { get; init; } = string.Empty;
    }
}
