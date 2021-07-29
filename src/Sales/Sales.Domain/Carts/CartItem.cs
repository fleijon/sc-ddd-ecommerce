using Sales.Domain.Catalog.Product;

namespace Sales.Domain.Carts
{
    public class CartItem
    {
        internal CartItem(ProductId productId, uint quantity)
        {
            ProductId = productId;
            Quantity = quantity;
        }

        public void ChangeQuantityTo(uint newQuantity)
        {
            Quantity = newQuantity;
        }

        public ProductId ProductId { get; }
        public uint Quantity { get; private set; }
    }
}