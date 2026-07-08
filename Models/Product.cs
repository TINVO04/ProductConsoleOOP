namespace ProductConsoleOOP.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; private set; }

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

    public bool IncreaseStock(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        Quantity += amount;
        return true;
    }

    public bool DecreaseStock(int amount)
    {
        if (amount <= 0)
        {
            return false;
        }

        if (amount > Quantity)
        {
            return false;
        }

        Quantity -= amount;
        return true;
    }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, Price: {Price}, Quantity: {Quantity}, Total: {GetTotalValue()}";
    }
}
