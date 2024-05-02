using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Urlize_back.Dtos;

namespace Urlize_back.Models
{
    [Table("Catalogue")]
    public class Catalogue
    {
        public Catalogue() { }
        [Key]
        public int Id { get; set; }

        [ForeignKey("CategorieId")]
        public int CategorieId { get; set; }
        public Categorie ?categorie { get; set; }
        public ICollection<Business> business { get; set; }

    }
}