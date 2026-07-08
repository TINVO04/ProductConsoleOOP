# ProductConsoleOOP

## Mục lục

- [1. Mục tiêu project](#1-mục-tiêu-project)
- [2. Công nghệ sử dụng](#2-công-nghệ-sử-dụng)
- [3. Cấu trúc thư mục](#3-cấu-trúc-thư-mục)
- [4. Cách chạy project](#4-cách-chạy-project)
- [5. Nội dung đã làm trong Day 1](#5-nội-dung-đã-làm-trong-day-1)
- [6. Nội dung đã làm trong Day 2](#6-nội-dung-đã-làm-trong-day-2)
- [7. Kiến thức đã học](#7-kiến-thức-đã-học)
- [8. Git workflow đã thực hành](#8-git-workflow-đã-thực-hành)
- [9. Ghi chú học tập](#9-ghi-chú-học-tập)
- [10. Checklist Day 1](#10-checklist-day-1)
- [11. Checklist Day 2](#11-checklist-day-2)

## 1. Mục tiêu project

Project này là bài thực hành tuần 2 trong lộ trình học .NET, tập trung vào OOP trong C# và mini project Console có cấu trúc.

Mục tiêu chính:

- Hiểu class và object trong C#.
- Biết khai báo property.
- Biết tạo constructor không tham số và constructor có tham số.
- Biết viết method xử lý logic nhỏ trong class.
- Biết áp dụng encapsulation để kiểm soát dữ liệu.
- Biết validate dữ liệu trước khi sử dụng.
- Biết tách code theo thư mục rõ ràng.
- Biết tạo object và in dữ liệu ra màn hình Console.

## 2. Công nghệ sử dụng

- C#
- .NET Console App
- Git và GitHub
- GitHub Actions CI

## 3. Cấu trúc thư mục

```text
ProductConsoleOOP/
├── .github/
│   └── workflows/
│       └── dotnet-ci.yml
├── Models/
│   ├── Product.cs
│   └── Student.cs
├── Validators/
│   └── ProductValidator.cs
├── Program.cs
├── ProductConsoleOOP.csproj
├── .gitignore
└── README.md
```

Giải thích:

- `Models/Product.cs`: chứa class Product đại diện cho sản phẩm.
- `Models/Student.cs`: chứa class Student dùng cho mini challenge tính tuổi.
- `Validators/ProductValidator.cs`: chứa class kiểm tra dữ liệu sản phẩm.
- `Program.cs`: điểm bắt đầu chạy chương trình, dùng để tạo object và test flow.
- `ProductConsoleOOP.csproj`: file cấu hình project .NET.
- `.github/workflows/dotnet-ci.yml`: workflow CI để tự động restore và build project.
- `.gitignore`: khai báo các file/thư mục không đưa lên Git.

## 4. Cách chạy project

Yêu cầu máy đã cài .NET SDK.

Kiểm tra version .NET:

```powershell
dotnet --version
```

Restore dependencies:

```powershell
dotnet restore
```

Build project:

```powershell
dotnet build
```

Chạy project:

```powershell
dotnet run
```

Kết quả chương trình sẽ in ra:

- Danh sách 5 sản phẩm mẫu.
- Tổng giá trị từng sản phẩm = Price * Quantity.
- Thông tin học viên mẫu và tuổi tính từ DateOfBirth.
- Kết quả test nhập kho và xuất kho.
- Kết quả validate sản phẩm sai dữ liệu.

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

## 6. Nội dung đã làm trong Day 2

### Mục tiêu

Day 2 tập trung vào method, access modifier, encapsulation và validate dữ liệu.

### Product stock methods

File `Models/Product.cs` được cập nhật:

- `Quantity` dùng `private set` để không cho code bên ngoài sửa trực tiếp số lượng tồn kho.
- Thêm method `IncreaseStock(int amount)` để nhập kho.
- Thêm method `DecreaseStock(int amount)` để xuất kho.
- Không cho nhập/xuất kho với số lượng nhỏ hơn hoặc bằng 0.
- Không cho xuất kho lớn hơn số lượng tồn kho hiện tại.

### Product validator

File `Validators/ProductValidator.cs` được tạo để kiểm tra dữ liệu sản phẩm:

- `Validate(Product product)`: trả về danh sách lỗi dạng `List<string>`.
- `IsValid(Product product)`: trả về `true` nếu sản phẩm hợp lệ, ngược lại trả về `false`.
- Kiểm tra `Name` không được rỗng.
- Kiểm tra `Price` phải lớn hơn 0.
- Kiểm tra `Quantity` không được âm.

### Program.cs test flow

File `Program.cs` có thêm phần test:

- Nhập kho bằng `IncreaseStock(2)`.
- Xuất kho hợp lệ bằng `DecreaseStock(1)`.
- Xuất kho sai bằng `DecreaseStock(100)`.
- Kiểm tra sau khi xuất kho sai thì `Quantity` không bị âm.
- Tạo sản phẩm sai dữ liệu để test `ProductValidator`.
- In danh sách lỗi validate ra màn hình.

## 7. Kiến thức đã học

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

### Access modifier

Access modifier quy định phạm vi truy cập của class, property hoặc method.

- `public`: bên ngoài class có thể truy cập.
- `private`: chỉ bên trong class được truy cập.
- `protected`: class hiện tại và class con có thể truy cập.

### Encapsulation

Encapsulation là đóng gói dữ liệu và kiểm soát cách dữ liệu bị thay đổi.

Ví dụ:

```csharp
public int Quantity { get; private set; }
```

Dòng này cho phép bên ngoài đọc `Quantity`, nhưng chỉ class `Product` mới được sửa `Quantity`.

### Validate

Validate là kiểm tra dữ liệu có hợp lệ không trước khi sử dụng.

Ví dụ sản phẩm hợp lệ cần:

- Tên không rỗng.
- Giá lớn hơn 0.
- Số lượng không âm.

### List<string>

`List<string>` dùng để lưu danh sách chuỗi. Trong project này, `List<string>` được dùng để lưu nhiều lỗi validate cùng lúc.

### ToString

`ToString()` dùng để quy định cách object được hiển thị khi in ra màn hình.

## 8. Git workflow đã thực hành

Branch Day 1:

```text
feature/week2-day01-tinvo
```

Branch Day 2:

```text
feature/week2-day02-tinvo
```

Một số commit đã thực hiện:

```text
chore: initialize console project
feat: add product model
feat: print sample products
feat: add student age calculation
fix: add product model content
docs: update day 1 readme
ci: add dotnet build workflow
feat: add product stock methods
feat: add product validator
feat: test product validation and stock methods
```

## 9. Ghi chú học tập

- Trước khi commit nên chạy `git status` để xem file nào đang thay đổi.
- Nên dùng `git diff` để xem nội dung thay đổi trước khi commit.
- Nên dùng `git diff --staged` để kiểm tra nội dung đã add trước khi commit.
- Không nên dùng `git add .` khi chưa chắc muốn commit toàn bộ file.
- File tài liệu khóa học và file local nên được đưa vào `.gitignore`.
- Nếu GitHub báo hai branch có lịch sử khác nhau, có thể cần merge với `--allow-unrelated-histories`.
- Khi gặp conflict, phải mở file bị conflict, giữ nội dung đúng, xóa các conflict marker rồi commit merge.
- Sau mỗi ngày nên tạo branch riêng và Pull Request riêng.

## 10. Checklist Day 1

- [x] Tạo project Console .NET.
- [x] Tạo thư mục Models.
- [x] Tạo class Product.
- [x] Tạo 5 object Product và in ra màn hình.
- [x] Viết method tính TotalValue = Price * Quantity.
- [x] Tạo class Student và tính tuổi từ DateOfBirth.
- [x] Commit theo từng bước nhỏ.
- [x] Viết README hướng dẫn chạy project.

## 11. Checklist Day 2

- [x] Đồng bộ local sau khi merge Day 1.
- [x] Tạo branch `feature/week2-day02-tinvo`.
- [x] Product có `Quantity` dùng `private set`.
- [x] Có `IncreaseStock(int amount)`.
- [x] Có `DecreaseStock(int amount)`.
- [x] Không cho nhập/xuất kho với số lượng không hợp lệ.
- [x] Không cho xuất kho lớn hơn tồn kho.
- [x] Có `ProductValidator`.
- [x] `ProductValidator` kiểm tra `Name`, `Price`, `Quantity`.
- [x] `Program.cs` có test các case đúng/sai.
- [x] Có CI build project bằng GitHub Actions.
