using ProductConsoleOOP.Models;

Console.WriteLine("Product Console OOP - Day 1");
Console.WriteLine("Danh sach san pham mau:");
Console.WriteLine();

Product laptop = new Product(1, "Laptop", 15000000, 3);
Product mouse = new Product(2, "Mouse", 250000, 10);
Product keyboard = new Product(3, "Keyboard", 750000, 5);
Product monitor = new Product(4, "Monitor", 3500000, 2);
Product headset = new Product(5, "Headset", 1200000, 4);

Console.WriteLine(laptop);
Console.WriteLine(mouse);
Console.WriteLine(keyboard);
Console.WriteLine(monitor);
Console.WriteLine(headset);


Console.WriteLine();
Console.WriteLine("Thong tin hoc vien mau:");

Student student = new Student(1, "Nguyen Van A", new DateTime(2004, 12, 20));

Console.WriteLine(student);
