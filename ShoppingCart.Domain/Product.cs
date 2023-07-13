namespace ShoppingCart.Domain
{
    public class Product : AuditableEntity
    {


        /// <summary>
        /// Gets or sets the product store id
        /// </summary>
        public long StoreId { get; set; }

        /// <summary>
        /// Gets or sets the product category
        /// </summary>
        private int ProductCategoryId { get; set; }

        /// <summary>
        /// Gets or sets the product name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the product description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the product quantity
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the product unit price
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the product category number status
        /// </summary>
        public ProductCategories ProductCategories
        {
            get => (ProductCategories)ProductCategoryId;
            set => ProductCategoryId = (int)value;
        }

        /// <summary>
        /// Gets the product stock status
        /// </summary>
        public bool InStock
        {
            get
            {
                return Quantity > 0;
            }
        }
    }
}
