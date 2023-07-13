using Moq;

namespace ShoppingCart.Test
{
    [TestClass]
    public class ShoppingServiceTest
    {
        public readonly IShoppingService _mockService;
        public ShoppingServiceTest()
        {
            // Mock lists 
            var storeList = new List<Store>();
            var productList = new List<Product>();
            var customerList = new List<Customer>();
            var addressList = new List<Address>();
            var cartList = new List<Cart>();
            var orderList = new List<Order>();

            // Create Mock service 
            var mockService = new Mock<IShoppingService>();

            #region Configuration Setups

            // Store Mock Setup
            mockService
                .Setup(c => c.CreateStore(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((long storeId, string name, string title, string companyName, string companyAddress, string companyPhoneNumber) =>
                {
                    Store store = new()
                    {
                        Id = storeId,
                        Name = name,
                        Title = title,
                        CompanyName = companyName,
                        CompanyAddress = companyAddress,
                        CompanyPhoneNumber = companyPhoneNumber,
                    };
                    if (storeList.Any(a => a.Id != storeId))
                        storeList.Add(store);
                    return store;
                });

            // Product Mock Setup
            mockService
                .Setup(c => c.CreateProduct(It.IsAny<long>(), It.IsAny<ProductCategories>(), It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<int>(), It.IsAny<decimal>()))
                .Returns((long productId, ProductCategories productCategory, long storeId, string name, string description, int quantity, decimal unitPrice) =>
                {
                    Product product = new()
                    {
                        Id = productId,
                        ProductCategories = productCategory,
                        StoreId = storeId,
                        Name = name,
                        Description = description,
                        Quantity = quantity,
                        UnitPrice = unitPrice,
                    };
                    if (productList.Any(a => a.Id != productId))
                        productList.Add(product);
                    return product;
                });

            // Customer Mock Setup
            mockService
                .Setup(c => c.CreateCustomer(It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((long customerId, string firtsName, string lastName, string email) =>
                {
                    Customer customer = new()
                    {
                        Id = customerId,
                        FirstName = firtsName,
                        LastName = lastName,
                        Email = email,
                    };
                    if (customerList.Any(a => a.Id != customerId))
                        customerList.Add(customer);
                    return customer;
                });

            // Address Mock Setup
            mockService
                .Setup(c => c.CreateCustomerAddress(It.IsAny<long>(), It.IsAny<long>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns((long addressId, long customerId, string addressTitle, string streetAddress, string zipPostalCode, string city, string countryCode, string phone) =>
                {
                    Address address = new()
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
                    if (addressList.Any(a => a.Id != addressId))
                        addressList.Add(address);
                    return address;
                });

            // Cart Mock Setup
            mockService
                .Setup(c => c.CreateCart(It.IsAny<long>(), It.IsAny<Customer>()))
                .Returns((long cartId, Customer customer) =>
                {
                    var cart = new Cart
                    {
                        Id = cartId,
                        CustomerId = customer.Id,
                        Customer = customer
                    };
                    if (cartList.Any(a => a.Id != cartId))
                        cartList.Add(cart);
                    return cart;
                });

            // AddProductToShoppingCart Mock Setup
            mockService
                .Setup(c => c.AddProductToShoppingCart(It.IsAny<Cart>(), It.IsAny<ShoppingCartItem>()))
                .Returns((Cart cart, ShoppingCartItem item) =>
                {
                    cart.ShoppingCartItems.Add(item);
                    return cart;
                });

            // Create GetTotalPriceOfCart Setup
            mockService
                .Setup(c => c.CreateOrder(It.IsAny<long>(), It.IsAny<Customer>(), It.IsAny<Store>(), It.IsAny<Address>(), It.IsAny<Cart>()))
                .Returns((long orderId, Customer customer, Store store, Address address, Cart cart) =>
                {

                    var order = new Order
                    {
                        Id = orderId,
                        CustomerId = customer.Id,
                        Customer = customer,
                        StoreId = store.Id,
                        Store = store,
                        AddressId = address.Id,
                        Address = address,
                        CartId = cart.Id,
                        Cart = cart
                    };
                    if (orderList.Any(a => a.Id != orderId))
                        orderList.Add(order);
                    return order;
                });

            #endregion Configuration Setups

            // Set Mock object.
            this._mockService = mockService.Object;
        }

        /// <summary>
        /// Test Store with name "Clothes Store".
        /// </summary>
        [TestMethod]
        public void Create_Store_Should_Not_Empty_With_Name_Book_Store_Test_Method()
        {
            var expected = this._mockService.CreateStore(1, "Clothes Store", "Clothes World", "Clothes Co", "Address", "+90 201245863698");

            // store is not null.
            Assert.IsNotNull(expected);

            // store is not deleted.
            Assert.IsTrue(!expected.IsDeleted);

            // store name sholud correct.
            Assert.IsTrue(expected.Name == "Clothes Store");
        }

        /// <summary>
        /// Test Product with name "Denim L T-Shirts". and category TShirts
        /// </summary>
        [TestMethod]
        public void Create_Product_Should_Not_Empty_With_Category_TShirt_Test_Method()
        {
            decimal unitPrice = 25.5m;
            var expected = this._mockService.CreateProduct(1, ProductCategories.TShirts, 1, "Denim L T-Shirts", "Large size cotton fabrik", 10, unitPrice);

            // product is not null.
            Assert.IsNotNull(expected);

            // product is not deleted.
            Assert.IsTrue(!expected.IsDeleted);

            // product name and category sholud correct.
            Assert.IsTrue(expected.Name == "Denim L T-Shirts");
            Assert.IsTrue(expected.ProductCategories == ProductCategories.TShirts);
        }

        /// <summary>
        /// Test customer with email "ismailkasan63@gmail.com"
        /// </summary>
        [TestMethod]
        public void Create_Customer_Should_Not_Empty_With_Correct_Email_Test_Method()
        {
            var expected = this._mockService.CreateCustomer(1, "Ýsmail", "Kaþan", "ismailkasan63@gmail.com");

            // customer is not null.
            Assert.IsNotNull(expected);

            // store is not deleted.
            Assert.IsTrue(!expected.IsDeleted);

            // store email sholud correct.
            Assert.IsTrue(expected.Email == "ismailkasan63@gmail.com");
        }

        /// <summary>
        /// Test address with countryCode "90"
        /// </summary>
        [TestMethod]
        public void Create_Address_Should_Not_Empty_With_Correct_Country_Code_Test_Method()
        {
            var expected = this._mockService.CreateCustomerAddress(1, 1, "Home Address", "Washinton D.C street", "06970", "Ankara", "90", "03129854125");

            // address is not null.
            Assert.IsNotNull(expected);

            // address is not deleted.
            Assert.IsTrue(!expected.IsDeleted);

            // address country code sholud correct.
            Assert.IsTrue(expected.CountryCode == "90");
            Assert.IsTrue(expected.AddressTitle == "Home Address");
        }

        /// <summary>
        /// Test Cart with Id 1
        /// </summary>
        [TestMethod]
        public void Create_Cart_Should_Not_Empty_With_Correct_Id_Test_Method()
        {

            var customer = this._mockService.CreateCustomer(1, "Ýsmail", "Kaþan", "ismailkasan63@gmail.com");
            var expected = this._mockService.CreateCart(1, customer);

            // cart is not null.
            Assert.IsNotNull(expected);

            // cart is not deleted.
            Assert.IsTrue(!expected.IsDeleted);

            // cart id sholud correct.
            Assert.IsNotNull(expected.Customer);
            Assert.IsTrue(expected.Id == 1);
            Assert.IsTrue(expected.CustomerId == 1);
        }

        /// <summary>
        /// Test Add Product To Shopping Cart
        /// </summary>
        [TestMethod]
        public void Add_Product_To_Shopping_Cart_Should_Correct_Total_Amount_And_Price_Test_Method()
        {
            var store = this._mockService.CreateStore(1, "Clothes Store", "Clothes World", "Clothes Co", "Address", "+90 201245863698");

            decimal tisortUnitPrice = 15.5m;
            var tshirt = this._mockService.CreateProduct(1, ProductCategories.TShirts, store.Id, "Denim L T-Shirts", "Large size cotton fabric", 10, tisortUnitPrice);

            decimal jeanstUnitPrice = 25.2m;
            var jeans = this._mockService.CreateProduct(2, ProductCategories.Jeans, store.Id, "Slim size Jean", "Large size cotton fabric", 10, jeanstUnitPrice);

            var customer = this._mockService.CreateCustomer(1, "Ýsmail", "Kaþan", "ismailkasan63@gmail.com");
            var cart = this._mockService.CreateCart(1, customer);

            // tshirt item
            var tshirtItem = new ShoppingCartItem
            {
                Amount = 5,
                Id = 1,
                ProductId = tshirt.Id,
                ShoppingCartId = cart.Id,
                Product = tshirt,
            };

            // jeans item
            var jeansItem = new ShoppingCartItem
            {
                Amount = 3,
                Id = 1,
                ProductId = jeans.Id,
                ShoppingCartId = cart.Id,
                Product = jeans,
            };

            // Add to cart
            this._mockService.AddProductToShoppingCart(cart, tshirtItem);
            var expectedCart = this._mockService.AddProductToShoppingCart(cart, jeansItem);

            // cart is not null.
            Assert.IsNotNull(expectedCart);

            // cart is not deleted.
            Assert.IsTrue(!expectedCart.IsDeleted);

            // cart total amount and price.
            Assert.IsTrue(expectedCart.CartTotalAmount == 8);
            Assert.IsTrue(expectedCart.CartTotalPrice == 153.1m);
        }

        /// <summary>
        /// Test Add Product To Shopping Cart and Create Order
        /// </summary>
        [TestMethod]
        public void Add_Product_To_Shopping_Cart_And_Create_Order_Should_Correct_With_Total_Amount_And_Total_Price_And_Order_Status_Test_Method()
        {
            var store = this._mockService.CreateStore(1, "Clothes Store", "Clothes World", "Clothes Co", "Address", "+90 201245863698");

            decimal tisortUnitPrice = 15.5m;
            var tshirt = this._mockService.CreateProduct(1, ProductCategories.TShirts, store.Id, "Denim L T-Shirts", "Large size cotton fabric", 10, tisortUnitPrice);

            decimal jeanstUnitPrice = 25.2m;
            var jeans = this._mockService.CreateProduct(2, ProductCategories.Jeans, store.Id, "Slim size Jean", "Large size cotton fabric", 10, jeanstUnitPrice);

            var customer = this._mockService.CreateCustomer(1, "Ýsmail", "Kaþan", "ismailkasan63@gmail.com");
            var address = this._mockService.CreateCustomerAddress(1, customer.Id, "Home Address", "Washinton D.C street", "06970", "Ankara", "90", "03129854125");

            var cart = this._mockService.CreateCart(1, customer);

            // tshirt item
            var tshirtItem = new ShoppingCartItem
            {
                Amount = 5,
                Id = 1,
                ProductId = tshirt.Id,
                ShoppingCartId = cart.Id,
                Product = tshirt,
            };

            // jeans item
            var jeansItem = new ShoppingCartItem
            {
                Amount = 3,
                Id = 1,
                ProductId = jeans.Id,
                ShoppingCartId = cart.Id,
                Product = jeans,
            };

            // Add to cart
            this._mockService.AddProductToShoppingCart(cart, tshirtItem);
            var expectedCart = this._mockService.AddProductToShoppingCart(cart, jeansItem);

            // create order
            var expectedOrder = this._mockService.CreateOrder(1, customer, store, address, cart);


            // objects should not be null.
            Assert.IsNotNull(store);
            Assert.IsNotNull(tshirt);
            Assert.IsNotNull(jeans);
            Assert.IsNotNull(customer);
            Assert.IsNotNull(address);
            Assert.IsNotNull(expectedCart);
            Assert.IsNotNull(expectedOrder);

            // order is not deleted.
            Assert.IsTrue(!expectedOrder.IsDeleted);

            // order properties sholud correct.
            Assert.IsTrue(expectedOrder.Cart.CartTotalAmount == 8);
            Assert.IsTrue(expectedOrder.Cart.CartTotalPrice == 153.1m);
            Assert.IsTrue(expectedOrder.OrderStatus == OrderStatus.New);
        }

    }
}