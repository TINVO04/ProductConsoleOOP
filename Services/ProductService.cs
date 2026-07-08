using ProductConsoleOOP.Interfaces;
using ProductConsoleOOP.Models;

namespace ProductConsoleOOP.Services;

public class ProductService : IProductService
{
    private readonly List<Product> _products = new List<Product>
    {
        new Product(1, "Laptop", 15000000, 3),
        new Product(2, "Mouse", 250000, 10),
        new Product(3, "Keyboard", 750000, 5),
        new Product(4, "Monitor", 3500000, 2),
        new Product(5, "Headset", 1200000, 4)
    };

    public List<Product> GetAll()
    {
        return _products;
    }

    public Product? GetById(int id)
    {
        return _products.FirstOrDefault(product => product.Id == id);
    }

    public List<Product> SearchByName(string keyword)
    {
        string normalizedKeyword = keyword.Trim();

        return _products
            .Where(product => product.Name.Contains(normalizedKeyword, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }


    public Product Create(string name, decimal price, int quantity)
    {
        int newId = _products.Count == 0 ? 1 : _products.Max(product => product.Id) + 1;
        Product newProduct = new Product(newId, name, price, quantity);

        _products.Add(newProduct);

        return newProduct;
    }

    public bool Update(int id, decimal newPrice, int newQuantity)
    {
        Product? productToUpdate = GetById(id);

        if (productToUpdate == null)
        {
            return false;
        }

        if (newPrice <= 0 || newQuantity < 0)
        {
            return false;
        }

        productToUpdate.Price = newPrice;

        int quantityDifference = newQuantity - productToUpdate.Quantity;

        if (quantityDifference > 0)
        {
            productToUpdate.IncreaseStock(quantityDifference);
        }
        else if (quantityDifference < 0)
        {
            productToUpdate.DecreaseStock(Math.Abs(quantityDifference));
        }

        return true;
    }

    public bool Delete(int id)
    {
        Product? productToDelete = GetById(id);

        if (productToDelete == null)
        {
            return false;
        }

        _products.Remove(productToDelete);
        return true;
    }

    public List<Product> GetLowStockProducts(int threshold)
    {
        return _products
            .Where(product => product.Quantity < threshold)
            .ToList();
    }
}
