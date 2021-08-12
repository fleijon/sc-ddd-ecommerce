using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.Carts.AddToCart
{
    public class AddToCartRequest
    {
        [Required(ErrorMessage = "The {0} field is mandatory")]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public uint Quantity { get; set; }

        [Required(ErrorMessage = "The {0} field is mandatory")]
        public string Currency { get; set; }
    }
}