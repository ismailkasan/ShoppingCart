using ShoppingCart.Domain;

namespace ShoppingCart.Business
{
    /// <summary>
    /// Shopping Service
    /// </summary>
    public class ShoppingService : IShoppingService
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
        public Store CreateStore(long storeId, string name, string title, string companyName, string companyAddress, string companyPhoneNumber)
        {
            return new Store
            {
                Id = storeId,
                Name = name,
                Title = title,
                CompanyName = companyName,
                CompanyAddress = companyAddress,
                CompanyPhoneNumber = companyPhoneNumber,
            };
        }

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
        public Product CreateProduct(long productId, ProductCategories productCategory, long storeId, string name, string description, int quantity, decimal unitPrice)
        {
            return new Product
            {
                Id = productId,
                ProductCategories = productCategory,
                StoreId = storeId,
                Name = name,
                Description = description,
                Quantity = quantity,
                UnitPrice = unitPrice,
            };
        }

        /// <summary>
        /// Create customer and return it.
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="firtsName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public Customer CreateCustomer(long customerId, string firtsName, string lastName, string email)
        {
            return new Customer
            {
                Id = customerId,
                FirstName = firtsName,
                LastName = lastName,
                Email = email,
            };
        }

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
        public Address CreateCustomerAddress(long addressId, long customerId, string addressTitle, string streetAddress, string zipPostalCode, string city, string countryCode, string phone)
        {
            return new Address
            {
                Id = addressId,
                CustomerId = customerId,
                AddressTitle = addressTitle,
                StreetAddress = streetAddress,
                ZipPostalCode = zipPostalCode,
                City = city,
                CountryCode = countryCode,
                Phone = phone
            };
        }

        /// <summary>
        /// Create cart and return it.
        /// </summary>
        /// <param name="cartId"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public Cart CreateCart(long cartId, Customer customer)
        {

            var cart = new Cart
            {
                Id = cartId,
                Customer = customer,
                CustomerId = customer.Id,
            };
            return cart;
        }

        /// <summary>
        /// Add product to cart and return updated cart.
        /// </summary>
        /// <param name="cart"></param>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public Cart AddProductToShoppingCart(Cart cart, ShoppingCartItem item)
        {
            if (!item.Product.InStock)
            {
                throw new ArgumentException("Product out of stock");
            }
            cart.ShoppingCartItems.Add(item);
            return cart;
        }

        /// <summary>
        /// Create order.
        /// </summary>
        /// <param name="orderId"></param>
        /// <param name="customer"></param>
        /// <param name="store"></param>
        /// <param name="address"></param>
        /// <param name="cart"></param>
        /// <returns></returns>
        public Order CreateOrder(long orderId, Customer customer, Store store, Address address, Cart cart)
        {
            return new Order
            {
                Id = orderId,
                CustomerId = customer.Id,
                Customer = customer,
                StoreId = store.Id,
                Store = store,
                CartId = cart.Id,
                Cart = cart
            };
        }
    }
}
