using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ShoppingCart.Domain.Models
{
    public class CartProduct
    {
        public Guid id { get; set; }

        [ForeignKey("Cart")]
        public Guid CartFK { get; set; }
        public virtual Cart Cart { get; set; }

        [ForeignKey("Product")]
        public Guid ProductFK { get; set; }

        public virtual Product Product { get; set; }
        public System.DateTime OrderDate { get; set; }
        public int Quantity { get; set; }
    }
}
