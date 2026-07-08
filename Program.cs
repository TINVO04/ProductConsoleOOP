using ProductConsoleOOP.Interfaces;
using ProductConsoleOOP.Models;
using ProductConsoleOOP.Services;

IProductService productService = new ProductService();

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

            foreach (Product product in productService.GetAll())
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

            List<Product> foundProducts = productService.SearchByName(keyword);

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

            Product? productToUpdate = productService.GetById(updateId);

            if (productToUpdate == null)
            {
                Console.WriteLine("Khong tim thay san pham can cap nhat.");
                break;
            }

            Console.WriteLine("San pham hien tai:");
            Console.WriteLine(productToUpdate);

            Console.Write("Nhap gia moi: ");
            string? newPriceInput = Console.ReadLine();

            if (!decimal.TryParse(newPriceInput, out decimal newPrice))
            {
                Console.WriteLine("Gia moi khong hop le.");
                break;
            }

            Console.Write("Nhap so luong moi: ");
            string? newQuantityInput = Console.ReadLine();

            if (!int.TryParse(newQuantityInput, out int newQuantity))
            {
                Console.WriteLine("So luong moi khong hop le.");
                break;
            }

            bool isUpdated = productService.Update(updateId, newPrice, newQuantity);

            if (!isUpdated)
            {
                Console.WriteLine("Cap nhat san pham that bai. Vui long kiem tra gia va so luong.");
                break;
            }

            Console.WriteLine("Cap nhat san pham thanh cong:");
            Console.WriteLine(productService.GetById(updateId));
            break;

        case "4":
            Console.Write("Nhap Id san pham can xoa: ");
            string? deleteIdInput = Console.ReadLine();

            if (!int.TryParse(deleteIdInput, out int deleteId))
            {
                Console.WriteLine("Id khong hop le.");
                break;
            }

            bool isDeleted = productService.Delete(deleteId);

            if (!isDeleted)
            {
                Console.WriteLine("Khong tim thay san pham can xoa.");
                break;
            }

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

            Product newProduct = productService.Create(newName, createPrice, createQuantity);

            Console.WriteLine("Them san pham thanh cong:");
            Console.WriteLine(newProduct);
            break;

        case "6":
            List<Product> lowStockProducts = productService.GetLowStockProducts(5);

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
