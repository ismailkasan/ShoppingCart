using ShoppingCart.Domain;

namespace ShoppingCart.Business
{
    /// <summary>
    /// Shopping Service Interface
    /// </summary>
    public interface IShoppingService
    {
        /// <summary>
        /// Create store and return it.
        /// </summary>
        /// <param name="storeId"></param>
        /// <param name="name"></param>
        /// <param name="title"></param>
        /// <param name="companyName"></param>
        /// <param name="companyAddress"></param>
        /// <param name="companyPhoneNumber"></param>
        /// <returns></returns>
        Store CreateStore(long storeId, string name, string title, string companyName, string companyAddress, string companyPhoneNumber);

        /// <summary>
        /// Create product and return it.
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="productCategory"></param>
        /// <param name="storeId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="quantity"></param>
        /// <param name="unitPrice"></param>
        /// <returns></returns>
        Product CreateProduct(long productId, ProductCategories productCategory, long storeId, string name, string description, int quantity, decimal unitPrice);

        /// <summary>
        /// Create customer and return it.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="firtsName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        Customer CreateCustomer(long customerId, string firtsName, string lastName, string email);

        /// <summary>
        /// Create customer address and return it.
        /// </summary>
        /// <param name="addressId"></param>
        /// <param name="customerId"></param>
        /// <param name="addressTitle"></param>
        /// <param name="streetAddress"></param>
        /// <param name="zipPostalCode"></param>
        /// <param name="city"></param>
        /// <param name="countryCode"></param>
        /// <param name="phone"></param>
        /// <returns></returns>
        Address CreateCustomerAddress(long addressId, long customerId, string addressTitle, string streetAddress, string zipPostalCode, string city, string countryCode, string phone);

        /// <summary>
        /// Create cart and return it.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        Cart CreateCart(long cartId, Customer customer);

        /// <summary>
        /// Add product to cart and return updated cart.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        Cart AddProductToShoppingCart(Cart cart, ShoppingCartItem item);

        /// <summary>
        /// Create order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="customer"></param>
        /// <param name="store"></param>
        /// <param name="address"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        Order CreateOrder(long orderId, Customer customer, Store store, Address address, Cart cart);
    }
}
