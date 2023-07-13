namespace ShoppingCart.Domain
{
    public class Address : AuditableEntity
    {     
        /// <summary>
        /// Gets or sets the customer Id
        /// </summary>
        public long CustomerId { get; set; }     

        /// <summary>
        /// Gets or sets the address title
        /// </summary>
        public string AddressTitle { get; set; }

        /// <summary>
        /// Gets or sets the street address
        /// </summary>
        public string StreetAddress { get; set; }

        /// <summary>
        /// Gets or sets the zip postal code
        /// </summary>
        public string ZipPostalCode { get; set; }

        /// <summary>
        /// Gets or sets the city
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the country code
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        /// Gets or sets the phone number
        /// </summary>
        public string Phone { get; set; }
    }
}
