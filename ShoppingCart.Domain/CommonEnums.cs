using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.Domain
{
    public enum ProductCategories
    {
        /// <summary>
        /// Define T-Shirts 
        /// </summary>
        [Display(Name = "T-Shirts")]
        TShirts = 0,

        /// <summary>
        /// Define Jeans
        /// </summary>
        [Display(Name = "Jeans")]
        Jeans = 1
    }

    public enum OrderStatus
    {
        /// <summary>
        /// New
        /// </summary>
        [Display(Name = "New")]
        New = 0,

        /// <summary>
        /// Processing
        /// </summary>
        [Display(Name = "Processing")]
        Processing = 1,

        /// <summary>
        /// Waiting Payment
        /// </summary>
        [Display(Name = "Waiting Payment")]
        WaitingPayment = 2,

        /// <summary>
        /// Paid
        /// </summary>
        [Display(Name = "Paid")]
        Paid = 3
    }
    public enum ShippingStatus
    {
        /// <summary>
        /// Not yet shipped
        /// </summary>
        [Display(Name = "Not yet shipped")]
        NotYetShipped = 0,

        /// <summary>
        /// Shipped
        /// </summary>
        [Display(Name = "Shipped")]
        Shipped = 1,

        /// <summary>
        /// Delivered
        /// </summary>
        [Display(Name = "Delivered")]
        Delivered = 2
    }
}
