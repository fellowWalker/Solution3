using System;
using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Domain.Models
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        public DateTime DatePlaced { get; set; }
        public string UserEmail { get; set; }
    }
}
