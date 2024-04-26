using Microsoft.AspNetCore.Identity;

namespace Urlize_back.Models
{
    public class User :IdentityUser
    {
        public string? BusinessName { get; set; }
        public string? Categories { get; set;}

        public string? StudentCard { get; set; }
    }
}
