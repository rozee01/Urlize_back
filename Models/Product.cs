using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Urlize_back.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column("Name")]
        public string? Name { get; set; }
        [Column("Description")]
        public string? Description { get; set; }
        [Column("Price")]
        public float Price { get; set; }
        [Column("Available")]
        public bool Available { get; set; }
        [Column("Image")]
        public string? Image {  get; set; }
        [ForeignKey("Business")]
        public int businessId { get; set; }
        public Business business { get; set; }
    }
}
