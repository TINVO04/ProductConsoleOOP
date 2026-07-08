using ProductConsoleOOP.Models;

List<Product> products = new List<Product>
{
    new Product(1, "Laptop", 15000000, 3),
    new Product(2, "Mouse", 250000, 10),
    new Product(3, "Keyboard", 750000, 5),
    new Product(4, "Monitor", 3500000, 2),
    new Product(5, "Headset", 1200000, 4)
};

bool isRunning = true;

while (isRunning)
{
    Console.WriteLine();
    Console.WriteLine("===== PRODUCT CONSOLE OOP =====");
    Console.WriteLine("1. Xem danh sach san pham");
    Console.WriteLine("0. Thoat");
    Console.Write("Nhap lua chon: ");

    string? choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine();
            Console.WriteLine("Danh sach san pham:");

            foreach (Product product in products)
            {
                Console.WriteLine(product);
            }
            break;

        case "0":
            isRunning = false;
            Console.WriteLine("Tam biet!");
            break;

        default:
            Console.WriteLine("Lua chon khong hop le. Vui long nhap lai.");
            break;
    }
}
