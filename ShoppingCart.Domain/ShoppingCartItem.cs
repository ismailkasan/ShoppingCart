namespace ShoppingCart.Domain
{
    public class ShoppingCartItem : AuditableEntity
    {

        public long ShoppingCartId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart item product id
        /// </summary>
        public long ProductId { get; set; }

        /// <summary>
        /// Gets or sets the shopping cart item amount
        /// </summary>
        public int Amount { get; set; }

        /// <summary>
        /// Gets the shopping cart item sub total
        /// </summary>
        public decimal SubTotal
        {
            get
            {
                return Amount * this.Product.UnitPrice;
            }
        }

        /// <summary>
        /// Gets or sets the product
        /// </summary>
        public virtual Product Product { get; set; }
    }
}
