namespace ProductConsoleOOP.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public Product()
    {
        Name = string.Empty;
    }

    public Product(int id, string name, decimal price, int quantity)
    {
        Id = id;
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    public decimal GetTotalValue()
    {
        return Price * Quantity;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Total: {GetTotalValue()}";
    }
}
