namespace ShoppingCart.Domain
{
    public class Order : AuditableEntity
    {
        public Order()
        {
            OrderDateUtc = DateTime.UtcNow;
            OrderStatus = OrderStatus.New;
            ShippingStatus = ShippingStatus.NotYetShipped;
        }

        /// <summary>
        /// Gets or sets the order customer id
        /// </summary>
        public long CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the order store id
        /// </summary>
        public long StoreId { get; set; }

        /// <summary>
        /// Gets or sets the order cart id
        /// </summary>
        public long CartId { get; set; }

        /// <summary>
        /// Gets or sets the order address id
        /// </summary>
        public long AddressId { get; set; }

        /// <summary>
        /// Gets or sets the order date utc
        /// </summary>
        public DateTime OrderDateUtc { get; set; }

        /// <summary>
        /// Gets or sets the order status id
        /// </summary>
        private int OrderStatusId { get; set; }

        /// <summary>
        /// Gets or sets the shipping status id
        /// </summary>
        private int ShippingStatusId { get; set; }

        /// <summary>
        /// Gets or sets the order number status
        /// </summary>
        public OrderStatus OrderStatus
        {
            get => (OrderStatus)OrderStatusId;
            set => OrderStatusId = (int)value;
        }

        /// <summary>
        /// Gets or sets the order shipping number status
        /// </summary>
        public ShippingStatus ShippingStatus
        {
            get => (ShippingStatus)ShippingStatusId;
            set => ShippingStatusId = (int)value;
        }

        /// <summary>
        /// Gets or sets the customer address
        /// </summary>
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the customer 
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the store
        /// </summary>
        public virtual Store Store { get; set; }

        /// <summary>
        /// Gets or sets the cart
        /// </summary>
        public virtual Cart Cart { get; set; }
    }

}
