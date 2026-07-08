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
    Console.WriteLine("2. Tim san pham theo ten");
    Console.WriteLine("3. Cap nhat gia va so luong san pham");
    Console.WriteLine("4. Xoa san pham");
    Console.WriteLine("5. Them san pham");
    Console.WriteLine("6. Loc san pham ton kho thap");
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

        case "2":
            Console.Write("Nhap ten san pham can tim: ");
            string? keyword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Tu khoa tim kiem khong duoc rong.");
                break;
            }

            List<Product> foundProducts = products
                .Where(product => product.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (foundProducts.Count == 0)
            {
                Console.WriteLine("Khong tim thay san pham phu hop.");
            }
            else
            {
                Console.WriteLine("Ket qua tim kiem:");

                foreach (Product product in foundProducts)
                {
                    Console.WriteLine(product);
                }
            }
            break;

        case "3":
            Console.Write("Nhap Id san pham can cap nhat: ");
            string? updateIdInput = Console.ReadLine();

            if (!int.TryParse(updateIdInput, out int updateId))
            {
                Console.WriteLine("Id khong hop le.");
                break;
            }

            Product? productToUpdate = products.FirstOrDefault(product => product.Id == updateId);

            if (productToUpdate == null)
            {
                Console.WriteLine("Khong tim thay san pham can cap nhat.");
                break;
            }

            Console.WriteLine("San pham hien tai:");
            Console.WriteLine(productToUpdate);

            Console.Write("Nhap gia moi: ");
            string? newPriceInput = Console.ReadLine();

            if (!decimal.TryParse(newPriceInput, out decimal newPrice) || newPrice <= 0)
            {
                Console.WriteLine("Gia moi khong hop le.");
                break;
            }

            Console.Write("Nhap so luong moi: ");
            string? newQuantityInput = Console.ReadLine();

            if (!int.TryParse(newQuantityInput, out int newQuantity) || newQuantity < 0)
            {
                Console.WriteLine("So luong moi khong hop le.");
                break;
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

            Console.WriteLine("Cap nhat san pham thanh cong:");
            Console.WriteLine(productToUpdate);
            break;

        case "4":
            Console.Write("Nhap Id san pham can xoa: ");
            string? deleteIdInput = Console.ReadLine();

            if (!int.TryParse(deleteIdInput, out int deleteId))
            {
                Console.WriteLine("Id khong hop le.");
                break;
            }

            Product? productToDelete = products.FirstOrDefault(product => product.Id == deleteId);

            if (productToDelete == null)
            {
                Console.WriteLine("Khong tim thay san pham can xoa.");
                break;
            }

            products.Remove(productToDelete);
            Console.WriteLine("Xoa san pham thanh cong.");
            break;

        case "5":
            Console.Write("Nhap ten san pham: ");
            string? newName = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newName))
            {
                Console.WriteLine("Ten san pham khong duoc rong.");
                break;
            }

            Console.Write("Nhap gia san pham: ");
            string? createPriceInput = Console.ReadLine();

            if (!decimal.TryParse(createPriceInput, out decimal createPrice) || createPrice <= 0)
            {
                Console.WriteLine("Gia san pham khong hop le.");
                break;
            }

            Console.Write("Nhap so luong san pham: ");
            string? createQuantityInput = Console.ReadLine();

            if (!int.TryParse(createQuantityInput, out int createQuantity) || createQuantity < 0)
            {
                Console.WriteLine("So luong san pham khong hop le.");
                break;
            }

            int newId = products.Count == 0 ? 1 : products.Max(product => product.Id) + 1;
            Product newProduct = new Product(newId, newName, createPrice, createQuantity);

            products.Add(newProduct);

            Console.WriteLine("Them san pham thanh cong:");
            Console.WriteLine(newProduct);
            break;

        case "6":
            List<Product> lowStockProducts = products
                .Where(product => product.Quantity < 5)
                .ToList();

            if (lowStockProducts.Count == 0)
            {
                Console.WriteLine("Khong co san pham ton kho thap.");
            }
            else
            {
                Console.WriteLine("Danh sach san pham ton kho thap:");

                foreach (Product product in lowStockProducts)
                {
                    Console.WriteLine(product);
                }
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
