using System;
using System.Collections.Generic;

class Order
{
    private List<Product> _products;
    private Customer _customer;

    public Order(Customer customer)
    {
        _products = new List<Product>();
        _customer = customer;
    }

    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    public double GetTotalPrice()
    {
        double total = 0;
        foreach (var product in _products)
        {
            total += product.GetTotalCost();
        }
        // Shipping cost: $5 if in the USA, otherwise $35
        total += _customer.IsInUSA() ? 5 : 35;
        return total;
    }

    public string GetPackingLabel()
    {
        string label = "PACKING LABEL:\n";
        foreach (var product in _products)
        {
            label += $"- {product.GetProductDetails()}\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"SHIPPING LABEL:\n{_customer.GetCustomerDetails()}";
    }
}
