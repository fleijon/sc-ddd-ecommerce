using System;
using System.ComponentModel.DataAnnotations;

namespace Sales.Application.Carts
{
    public class AddToCartRequest
    {
        private const string field_is_mandatory = "The {0} field is mandatory";

        [Required(ErrorMessage = field_is_mandatory)]
        public Guid CustomerId { get; set; }

        [Required(ErrorMessage = field_is_mandatory)]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = field_is_mandatory)]
        public uint Quantity { get; set; }

        [Required(ErrorMessage = field_is_mandatory)]
        public string Currency { get; set; }
    }
}