using ProductConsoleOOP.Models;
using ProductConsoleOOP.Validators;


Console.WriteLine("Product Console OOP - Day 1");
Console.WriteLine("Danh sach san pham mau:");
Console.WriteLine();

List<Product> products = new List<Product>
{
    new Product(1, "Laptop", 15000000, 3),
    new Product(2, "Mouse", 250000, 10),
    new Product(3, "Keyboard", 750000, 5),
    new Product(4, "Monitor", 3500000, 2),
    new Product(5, "Headset", 1200000, 4)
};

foreach (Product product in products)
{
    Console.WriteLine(product);
}


Console.WriteLine();
Console.WriteLine("Thong tin hoc vien mau:");

Student student = new Student(1, "Nguyen Van A", new DateTime(2004, 12, 20));
Console.WriteLine(student);

//dùng First ở đây được vì mình biết chắc list mẫu có sản phẩm Id == 1.
Product laptop = products.First(product => product.Id == 1);

Console.WriteLine();
Console.WriteLine("Day 2 - Stock methods test:");

Console.WriteLine($"Before increase stock: {laptop}");

bool increaseResult = laptop.IncreaseStock(2);
Console.WriteLine($"Increase stock by 2 result: {increaseResult}");
Console.WriteLine($"After increase stock: {laptop}");

bool decreaseResult = laptop.DecreaseStock(1);
Console.WriteLine($"Decrease stock by 1 result: {decreaseResult}");
Console.WriteLine($"After decrease stock: {laptop}");

bool invalidDecreaseResult = laptop.DecreaseStock(100);
Console.WriteLine($"Decrease stock by 100 result: {invalidDecreaseResult}");
Console.WriteLine($"After invalid decrease stock: {laptop}");

Console.WriteLine();
Console.WriteLine("Day 2 - Product validator test:");

ProductValidator validator = new ProductValidator();
Product invalidProduct = new Product(6, "", -5000, -3);

List<string> errors = validator.Validate(invalidProduct);

if (errors.Count == 0)
{
    Console.WriteLine("Invalid product is valid.");
}
else
{
    Console.WriteLine("Invalid product has errors:");

    foreach (string error in errors)
    {
        Console.WriteLine($"- {error}");
    }
}
