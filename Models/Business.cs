using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Urlize_back.Dtos;

namespace Urlize_back.Models
{
    [Table("Business")]
   public class Business
    {
        public Business() { }/*
        public Business(Guid id, BusinessCreateDto businessdto)
        {
            Id = id;
            this.businessName = businessdto.businessName;
            this.logo_url = businessdto.logo_url;
            this.description= businessdto.description;
            this.colorPalette = businessdto.colorPalette;
            this.designPref = businessdto.designPref;
            this.brandDescription = businessdto.brandDescription;
            this.goal = businessdto.goal;
        }*/

        [Key]
        public int Id { get; set; }
        [Column("Name")]
        [Required]
        public string businessName { get; set; }
        [Column("logo")]
        public string? logo_url {  get; set; }
       
        [Column("description")]
        [Required]
        public string? description { get; set; }
        [Column("colorPalette")]
        public string colorPalette { get; set; }

        [Column("designPref")]
        public string designPref { get; set; }

        [Column("brandDescription")]
        public string brandDescription { get; set; }

        [Column("goal")]
        public string goal { get; set;}
        public ICollection<Product> product { get; set; }
        public ICollection<Categorie> categorie { get; set; }
        public ICollection<Catalogue> catalogue { get; set; }

    }
}
/*
namespace Urlize_back
{
    public enum Categorie
    {
        Sports,
        Beaute,
        decoration,
        giftshop,
    }

    public enum DesignPref
    {
        Minimalist,
        Joyfull,
        Modern
    }

    public enum BrandDesc
    {
        Professional,
        Authoritative,
        Friendly
    }

    public enum Goal
    {
        Sell_Products,
        Promote_service,
        Showcase_partfolio,

    }

    public enum ColorPalette
    {
        palette1,
        palette2,
        palette3,
        palette4,
        palette5,
    }*/
