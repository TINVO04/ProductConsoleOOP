# ProductConsoleOOP

## 1. Mục tiêu project

Project này là bài thực hành Day 1 của tuần 2 trong lộ trình học .NET.

Mục tiêu chính:

- Hiểu class và object trong C#.
- Biết khai báo property.
- Biết tạo constructor không tham số và constructor có tham số.
- Biết viết method xử lý logic nhỏ trong class.
- Biết tách model ra thư mục riêng.
- Biết tạo object và in dữ liệu ra màn hình Console.

## 2. Công nghệ sử dụng

- C#
- .NET Console App
- Git và GitHub

## 3. Cấu trúc thư mục

```text
ProductConsoleOOP/
├── Models/
│   ├── Product.cs
│   └── Student.cs
├── Program.cs
├── ProductConsoleOOP.csproj
├── .gitignore
└── README.md
```

Giải thích:

- `Models/Product.cs`: chứa class Product đại diện cho sản phẩm.
- `Models/Student.cs`: chứa class Student dùng cho mini challenge tính tuổi.
- `Program.cs`: điểm bắt đầu chạy chương trình, dùng để tạo object và in dữ liệu.
- `ProductConsoleOOP.csproj`: file cấu hình project .NET.
- `.gitignore`: khai báo các file/thư mục không đưa lên Git.

## 4. Cách chạy project

Yêu cầu máy đã cài .NET SDK.

Kiểm tra version .NET:

```powershell
dotnet --version
```

Chạy project:

```powershell
dotnet run
```

Kết quả chương trình sẽ in ra:

- Danh sách 5 sản phẩm mẫu.
- Tổng giá trị từng sản phẩm = Price * Quantity.
- Thông tin học viên mẫu và tuổi tính từ DateOfBirth.

## 5. Nội dung đã làm trong Day 1

### Product model

File `Models/Product.cs` có:

- `Id`: mã sản phẩm.
- `Name`: tên sản phẩm.
- `Price`: giá sản phẩm.
- `Quantity`: số lượng tồn kho.
- Constructor không tham số.
- Constructor có tham số.
- Method `GetTotalValue()` để tính tổng giá trị tồn kho.
- Method `ToString()` để hiển thị thông tin sản phẩm.

### Student model

File `Models/Student.cs` có:

- `Id`: mã học viên.
- `FullName`: họ tên học viên.
- `DateOfBirth`: ngày sinh.
- Method `GetAge()` để tính tuổi.
- Method `ToString()` để hiển thị thông tin học viên.

## 6. Kiến thức đã học

### Class

Class là bản thiết kế để tạo ra object. Ví dụ `Product` là bản thiết kế cho một sản phẩm.

### Object

Object là một đối tượng cụ thể được tạo ra từ class. Ví dụ:

```csharp
Product laptop = new Product(1, "Laptop", 15000000, 3);
```

### Property

Property là dữ liệu của object, ví dụ `Name`, `Price`, `Quantity`.

### Constructor

Constructor là method đặc biệt chạy khi tạo object, dùng để khởi tạo dữ liệu ban đầu.

### Method

Method là hành động hoặc logic xử lý trong class. Ví dụ `GetTotalValue()` dùng để tính tổng giá trị sản phẩm.

### ToString

`ToString()` dùng để quy định cách object được hiển thị khi in ra màn hình.

## 7. Git workflow đã thực hành

Branch đang dùng:

```text
feature/week2-day01-tinvo
```

Một số commit đã thực hiện:

```text
chore: initialize console project
feat: add product model
feat: print sample products
feat: add student age calculation
fix: add product model content
```

## 8. Ghi chú học tập

- Trước khi commit nên chạy `git status` để xem file nào đang thay đổi.
- Nên dùng `git diff` để xem nội dung thay đổi trước khi commit.
- Nên dùng `git diff --staged` để kiểm tra nội dung đã add trước khi commit.
- Không nên dùng `git add .` khi chưa chắc muốn commit toàn bộ file.
- File tài liệu khóa học và file local nên được đưa vào `.gitignore`.

## 9. Checklist Day 1

- [x] Tạo project Console .NET.
- [x] Tạo thư mục Models.
- [x] Tạo class Product.
- [x] Tạo 5 object Product và in ra màn hình.
- [x] Viết method tính TotalValue = Price * Quantity.
- [x] Tạo class Student và tính tuổi từ DateOfBirth.
- [x] Commit theo từng bước nhỏ.
- [x] Viết README hướng dẫn chạy project.
