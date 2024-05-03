using System.ComponentModel.DataAnnotations;

namespace Urlize_back.Dtos
{
    public class CategorieCreateDto
    {
        [Required(ErrorMessage = "La Designation est requis.")]
        public string? designation { get; set; }


    }
}
