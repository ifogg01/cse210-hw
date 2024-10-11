using System;
using System.Collections.Generic;


public class Product
{
    private string _name;
    private string _productId;
    private double _price;
    private int _quantity;

    
    public Product(string name, string productId, double price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string ProductId
    {
        get { return _productId; }
        set { _productId = value; }
    }

    public double Price
    {
        get { return _price; }
        set { _price = value; }
    }

    public int Quantity
    {
        get { return _quantity; }
        set { _quantity = value; }
    }

    
    public double GetTotalPrice()
    {
        return _price * _quantity;
    }
}


public class Address
{
    private string _street;
    private string _city;
    private string _state;
    private string _country;

    
    public Address(string street, string city, string state, string country)
    {
        _street = street;
        _city = city;
        _state = state;
        _country = country;
    }

    
    public string Street
    {
        get { return _street; }
        set { _street = value; }
    }

    public string City
    {
        get { return _city; }
        set { _city = value; }
    }

    public string State
    {
        get { return _state; }
        set { _state = value; }
    }

    public string Country
    {
        get { return _country; }
        set { _country = value; }
    }

    
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    
    public string GetFullAddress()
    {
        return $"{_street}\n{_city}, {_state}\n{_country}";
    }
}


public class Customer
{
    private string _name;
    private Address _address;

    
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public Address Address
    {
        get { return _address; }
        set { _address = value; }
    }

    
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}


public class Order
{
    private List<Product> _products;
    private Customer _customer;

    
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    
    public List<Product> Products
    {
        get { return _products; }
    }

    public Customer Customer
    {
        get { return _customer; }
        set { _customer = value; }
    }

    
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    
    public double CalculateTotalCost()
    {
        double total = 0;

        
        foreach (Product product in _products)
        {
            total += product.GetTotalPrice();
        }

        
        total += _customer.LivesInUSA() ? 5.00 : 35.00;

        return total;
    }

    
    public string GetPackingLabel()
    {
        string label = "Product Enclosed:\n";
        foreach (Product product in _products)
        {
            label += $"Product: {product.Name}, ID: {product.ProductId}\n";
        }
        return label;
    }

    
    public string GetShippingLabel()
    {
        return $"Shipping to:\n{_customer.Name}\n{_customer.Address.GetFullAddress()}";
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("");
        Address address1 = new Address("123 Nephi St", "Bountiful", "UT", "USA");
        Address address2 = new Address("456 Gardener St", "Toronto", "ON", "Canada");

        
        Customer customer1 = new Customer("Joseph Smith", address1);
        Customer customer2 = new Customer("Hugh B. Brown", address2);

        
        Product product1 = new Product("Sword of Laban", "UT123", 999.99, 1);
        Product product2 = new Product("Urim & Thummim", "S456", 599.99, 2);

        
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        
        Product product3 = new Product("LDS Church History/Audio Library ", "LDS789", 599.99, 1);
        Product product4 = new Product("Gardening Tools", "G321", 19.99, 3);
        
        Order order2 = new Order(customer2);
        order2.AddProduct(product3);
        order2.AddProduct(product4);

        
        Console.WriteLine("Order 1 Summary:");
        Console.WriteLine($"Total cost: ${order1.CalculateTotalCost():0.00}");
        Console.WriteLine("\n===PACKING LABEL===");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine("\n===SHIPPING LABEL===");
        Console.WriteLine(order1.GetShippingLabel());

        
        Console.WriteLine("\n\nOrder 2 Summary:");
        Console.WriteLine($"Total cost: ${order2.CalculateTotalCost():0.00}");
        Console.WriteLine("\n===PACKING LABEL===");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine("\n===SHIPPING LABEL===");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine("");

    }
}
