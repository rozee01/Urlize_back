namespace Urlize_back.Dtos
{
    public class BusinessUpdateDto
    {
 
        public string businessName { get; set; }

        public string logo_url { get; set; }
        public string? categorie { get; set; }

        public string? description { get; set; }
        public string? colorPalette { get; set; }
        public string? designPref { get; set; }
        public string? brandDescription { get; set; }
        public string? goal { get; set; }
    }
}
