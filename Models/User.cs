using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Urlize_back.Models
{
    public class User :IdentityUser
    {
        [Required]
        public string? LastName { get; set; }

        
    }
}
