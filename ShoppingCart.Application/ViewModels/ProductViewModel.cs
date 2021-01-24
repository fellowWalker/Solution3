using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Application.ViewModels
{
    public class ProductViewModel
    {
        [Required]
        public Guid Id { get; set; }
            
        [Required(ErrorMessage ="Please input a name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please input a price")]
        [Range(typeof(double), "0", "9999", ErrorMessage = 
            "{0} must be a decimal/number between {1} and {2}.")]
        public double Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public CategoryViewModel Category { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
