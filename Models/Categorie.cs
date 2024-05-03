using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Urlize_back.Dtos;

namespace Urlize_back.Models
{
    [Table("Categorie")]
    public class Categorie
    {
        public Categorie() { }
        [Key]
        public int Id { get; set; }
        [Column("designation")]
        string designation { get; set; }
        public ICollection<Business> businesses { get; set; }

    }
}