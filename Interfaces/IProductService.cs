using ProductConsoleOOP.Models;

namespace ProductConsoleOOP.Interfaces;

public interface IProductService
{
    List<Product> GetAll();
    Product? GetById(int id);
    List<Product> SearchByName(string keyword);
    Product Create(string name, decimal price, int quantity);
    bool Update(int id, decimal newPrice, int newQuantity);
    bool Delete(int id);
    List<Product> GetLowStockProducts(int threshold);
}
