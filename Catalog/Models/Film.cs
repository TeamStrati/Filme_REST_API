using System.ComponentModel.DataAnnotations;

namespace Catalog.Models
{
    public class Film
    {

        [Required]
        public Guid Id { get; set; }


        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        
        [Required]
        public decimal PriceInCent { get; set; }
        
        [Required]
        public string Director { get; set; }

        // [Required]
        //public string Studio { get; set; }

        // [Required]
        // public string Categorie { get; set; }

        [Required]
        public string Writers { get; set; }

        [Required]
        public string Tagline { get; set; }

        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        public decimal RuntimeInMinutes { get; set; }

        [Required]
        public decimal BudgetInUSDollar { get; set; }

        [Range(1,10)]
        [Required]
        public decimal Rating { get; set; }
    }
}
