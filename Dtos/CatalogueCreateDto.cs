using System.ComponentModel.DataAnnotations;

namespace Urlize_back.Dtos
{
    public class CatalogueCreateDto
    {
        //mech arfa ya jmea chnou ydakhal ki ycreati catalogue badlou kima thebou
        [Required(ErrorMessage = "La Designation est requis.")]
        public string designation { get; set; }


    }
}
