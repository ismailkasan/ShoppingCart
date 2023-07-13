namespace ShoppingCart.Domain
{
    public class Cart : AuditableEntity
    {
        public Cart()
        {
            ShoppingCartItems = new();
        }

        /// <summary>
        /// Gets and sets the cart id
        /// </summary>
        public long CartId { get; set; }

        /// <summary>
        /// Gets and sets the customer id
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets and sets the customer
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Gets the order total price according to shopping cart items
        /// </summary>
        public decimal CartTotalPrice
        {
            get
            {
                return this.ShoppingCartItems.Sum(a => a.SubTotal);
            }
        }

        /// <summary>
        /// Gets the order total amount according to shopping cart items
        /// </summary>
        public int CartTotalAmount
        {
            get
            {
                return this.ShoppingCartItems.Sum(a => a.Amount);
            }
        }

        /// <summary>
        /// Gets the order shopping cart items
        /// </summary>
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
