# ProductConsoleOOP

Mini project Console App dùng để thực hành OOP trong C# theo lộ trình tuần 2 của khóa .NET.

Project hiện tập trung vào quản lý sản phẩm bằng dữ liệu in-memory với `List<Product>`, có menu CRUD, validate dữ liệu, xử lý tồn kho, tách logic qua service/interface và CI build tự động bằng GitHub Actions.

---

## Mục lục

- [Tổng quan](#tổng-quan)
- [Công nghệ sử dụng](#công-nghệ-sử-dụng)
- [Tính năng hiện có](#tính-năng-hiện-có)
- [Cách chạy project](#cách-chạy-project)
- [Cấu trúc thư mục](#cấu-trúc-thư-mục)
- [Kiến thức đã thực hành](#kiến-thức-đã-thực-hành)
- [Tiến độ theo ngày](#tiến-độ-theo-ngày)
- [Git workflow](#git-workflow)
- [Ghi chú học tập](#ghi-chú-học-tập)

---

## Tổng quan

Mục tiêu của project:

- Hiểu class và object trong C#.
- Biết khai báo property, constructor và method.
- Biết áp dụng encapsulation để kiểm soát dữ liệu.
- Biết validate dữ liệu trước khi sử dụng.
- Biết dùng `List<Product>` để quản lý danh sách object.
- Biết làm CRUD in-memory trong Console App.
- Biết tách code theo thư mục rõ ràng.
- Biết tách logic xử lý sang service và interface.
- Biết review, refactor và kiểm tra lại mini project trước khi chốt.
- Biết dùng Git branch, commit, Pull Request và CI cơ bản.

---

## Công nghệ sử dụng

- C#
- .NET Console App
- Git và GitHub
- GitHub Actions CI

---

## Tính năng hiện có

Menu hiện tại hỗ trợ:

```text
1. Xem danh sach san pham
2. Tim san pham theo ten
3. Cap nhat gia va so luong san pham
4. Xoa san pham
5. Them san pham
6. Loc san pham ton kho thap
0. Thoat
```

Chi tiết chức năng:

- Xem danh sách sản phẩm.
- Tìm sản phẩm theo tên, không phân biệt chữ hoa/thường.
- Tự xử lý khoảng trắng thừa khi tìm kiếm, ví dụ `lap ` vẫn tìm được `Laptop`.
- Thêm sản phẩm mới.
- Cập nhật giá và số lượng sản phẩm theo Id.
- Xóa sản phẩm theo Id.
- Lọc sản phẩm tồn kho thấp với điều kiện `Quantity < 5`.
- Xử lý input sai bằng `TryParse`.
- Xử lý trường hợp không tìm thấy dữ liệu.
- Xử lý trường hợp danh sách rỗng khi sinh Id mới.
- Service tự validate dữ liệu quan trọng trước khi tạo sản phẩm.
- Service trả bản copy danh sách để hạn chế code bên ngoài sửa trực tiếp dữ liệu nội bộ.

Lưu ý: dữ liệu hiện là in-memory, nên khi tắt chương trình và chạy lại, danh sách sẽ quay về dữ liệu mẫu ban đầu.

---

## Cách chạy project

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

---

## Cấu trúc thư mục

```text
ProductConsoleOOP/
├── .github/
│   └── workflows/
│       └── dotnet-ci.yml
├── Interfaces/
│   └── IProductService.cs
├── Models/
│   ├── Product.cs
│   └── Student.cs
├── Services/
│   └── ProductService.cs
├── Validators/
│   └── ProductValidator.cs
├── Program.cs
├── ProductConsoleOOP.csproj
├── .gitignore
└── README.md
```

Giải thích nhanh:

| Đường dẫn | Vai trò |
|---|---|
| `Program.cs` | Điểm bắt đầu chạy chương trình, chứa menu Console và gọi service. |
| `Interfaces/IProductService.cs` | Interface mô tả các hành động quản lý sản phẩm. |
| `Services/ProductService.cs` | Service chứa dữ liệu mẫu, logic CRUD và validate nghiệp vụ sản phẩm. |
| `Models/Product.cs` | Class Product, đại diện cho sản phẩm. |
| `Models/Student.cs` | Class Student, dùng cho mini challenge tính tuổi. |
| `Validators/ProductValidator.cs` | Class kiểm tra dữ liệu sản phẩm, dùng để thực hành validate ở Day 2. |
| `ProductConsoleOOP.csproj` | File cấu hình project .NET. |
| `.github/workflows/dotnet-ci.yml` | Workflow CI để restore và build project tự động. |
| `.gitignore` | Khai báo file/thư mục không đưa lên Git. |

---

## Kiến thức đã thực hành

### OOP cơ bản

- `class`: bản thiết kế để tạo object.
- `object`: đối tượng cụ thể được tạo ra từ class.
- `property`: dữ liệu của object.
- `constructor`: method đặc biệt chạy khi tạo object.
- `method`: hành động hoặc logic xử lý trong class.
- `ToString()`: quy định cách object được hiển thị khi in ra màn hình.

Ví dụ object:

```csharp
Product laptop = new Product(1, "Laptop", 15000000, 3);
```

### Encapsulation và validate

- `public`: bên ngoài class có thể truy cập.
- `private`: chỉ bên trong class được truy cập.
- `protected`: class hiện tại và class con có thể truy cập.
- `private set`: cho phép đọc từ bên ngoài nhưng chỉ class hiện tại được sửa giá trị.
- Validate dữ liệu để tránh tên rỗng, giá không hợp lệ hoặc số lượng âm.

Ví dụ encapsulation:

```csharp
public int Quantity { get; private set; }
```

### List và CRUD

- `List<Product>`: danh sách chứa nhiều object Product.
- CRUD: Create, Read, Update, Delete.
- `foreach`: duyệt từng phần tử trong danh sách.
- `FirstOrDefault`: tìm một phần tử, có thể trả về null nếu không tìm thấy.
- `Where`: lọc nhiều phần tử theo điều kiện.
- `ToList`: chuyển kết quả lọc thành danh sách hoặc tạo bản copy danh sách.
- `TryParse`: chuyển input từ chuỗi sang số một cách an toàn.
- `Max`: lấy giá trị lớn nhất trong danh sách.
- Toán tử 3 ngôi: `condition ? valueIfTrue : valueIfFalse`.

### Service và Interface

- `interface`: hợp đồng mô tả class cần có những method nào.
- `service`: class chứa logic xử lý nghiệp vụ chính.
- `IProductService`: mô tả các hành động quản lý sản phẩm.
- `ProductService`: thực thi các hành động như lấy danh sách, tìm kiếm, thêm, sửa, xóa và lọc tồn kho thấp.
- `Program.cs` chỉ nên lo nhập/xuất Console và gọi service, không nên chứa toàn bộ logic CRUD.
- Tách service giúp code dễ đọc hơn, dễ test hơn và dễ mở rộng hơn.

Ví dụ dùng interface trong menu:

```csharp
IProductService productService = new ProductService();
```

### Review và refactor

- Refactor là sửa cấu trúc code để code sạch hơn nhưng không làm thay đổi chức năng chính.
- Khi refactor cần build và test lại để chắc chắn hành vi cũ không bị hỏng.
- Service nên tự bảo vệ dữ liệu nội bộ, ví dụ không trả thẳng danh sách private ra ngoài.
- Service nên validate dữ liệu đầu vào để tránh phụ thuộc hoàn toàn vào UI hoặc Console.
- Có thể giữ ghi chú trong code khi học, nhưng về sau nên chuyển kiến thức dài sang README hoặc tài liệu riêng.

---

## Tiến độ theo ngày

### Day 1 - Class, object, property và constructor

Đã làm:

- Tạo project Console .NET.
- Tạo thư mục `Models`.
- Tạo class `Product`.
- Tạo 5 object Product mẫu.
- Viết method `GetTotalValue()` để tính tổng giá trị tồn kho.
- Override `ToString()` để in sản phẩm dễ đọc.
- Tạo class `Student` và tính tuổi từ `DateOfBirth`.
- Viết README hướng dẫn chạy project.

Checklist:

- [x] Tạo project Console .NET.
- [x] Tạo class Product.
- [x] Tạo object Product.
- [x] Viết constructor.
- [x] Viết method tính TotalValue.
- [x] Tạo Student mini challenge.

---

### Day 2 - Method, access modifier, encapsulation và validate

Đã làm:

- Cập nhật `Product.Quantity` dùng `private set`.
- Thêm `IncreaseStock(int amount)` để nhập kho.
- Thêm `DecreaseStock(int amount)` để xuất kho.
- Không cho nhập/xuất kho với số lượng nhỏ hơn hoặc bằng 0.
- Không cho xuất kho lớn hơn tồn kho.
- Tạo `ProductValidator`.
- Validate `Name`, `Price`, `Quantity`.
- Test logic nhập kho, xuất kho và validate trong `Program.cs`.

Checklist:

- [x] Product có `Quantity` dùng `private set`.
- [x] Có `IncreaseStock(int amount)`.
- [x] Có `DecreaseStock(int amount)`.
- [x] Có `ProductValidator`.
- [x] Có validate dữ liệu sản phẩm.
- [x] Có CI build project bằng GitHub Actions.

---

### Day 3 - List object, CRUD và tìm kiếm/lọc

Đã làm:

- Refactor `Program.cs` để dùng `List<Product>`.
- Tạo menu Console bằng `while` và `switch`.
- Xem danh sách sản phẩm.
- Tìm sản phẩm theo tên.
- Thêm sản phẩm mới.
- Cập nhật giá và số lượng sản phẩm.
- Xóa sản phẩm.
- Lọc sản phẩm tồn kho thấp.
- Xử lý input sai bằng `TryParse`.
- Xử lý không tìm thấy dữ liệu.
- Xử lý danh sách rỗng khi sinh Id mới.

Checklist:

- [x] Có `List<Product>`.
- [x] Có menu xem danh sách.
- [x] Có menu tìm kiếm theo tên.
- [x] Có menu thêm sản phẩm.
- [x] Có menu cập nhật sản phẩm.
- [x] Có menu xóa sản phẩm.
- [x] Có lọc tồn kho thấp.
- [x] Có xử lý input sai và không tìm thấy dữ liệu.

---

### Day 4 - Service, Interface và tách trách nhiệm

Đã làm:

- Tạo thư mục `Interfaces`.
- Tạo `IProductService` để mô tả các hành động quản lý sản phẩm.
- Tạo thư mục `Services`.
- Tạo `ProductService` để chứa dữ liệu mẫu và logic CRUD.
- Chuyển logic lấy danh sách, tìm kiếm, thêm, cập nhật, xóa và lọc tồn kho thấp từ `Program.cs` sang `ProductService`.
- Refactor `Program.cs` để chỉ còn xử lý menu, nhập input, in output và gọi service.
- Sửa tìm kiếm để tự `Trim()` keyword, giúp input như `lap ` vẫn tìm được `Laptop`.
- Build project thành công.
- Test lại menu bằng `dotnet run` và xác nhận các chức năng chính vẫn hoạt động.

Checklist:

- [x] Có `Interfaces/IProductService.cs`.
- [x] Có `Services/ProductService.cs`.
- [x] `ProductService` implement `IProductService`.
- [x] `Program.cs` gọi service thay vì tự xử lý toàn bộ CRUD.
- [x] Tìm kiếm xử lý khoảng trắng thừa bằng `Trim()`.
- [x] Build pass sau khi refactor.
- [x] Test lại xem danh sách, tìm kiếm, thêm, cập nhật, xóa và lọc tồn kho thấp.

---

### Day 5 - Review, refactor và chốt mini project

Đã làm:

- Review tổng thể kiến trúc hiện tại của `Program.cs`, `Product`, `IProductService` và `ProductService`.
- Xác định một số điểm có thể cải thiện trước khi chốt mini project.
- Cập nhật `ProductService.GetAll()` để trả bản copy danh sách thay vì trả trực tiếp danh sách nội bộ.
- Cập nhật `ProductService.SearchByName()` để trả danh sách rỗng nếu keyword rỗng sau khi `Trim()`.
- Cập nhật `ProductService.Create()` để validate `name`, `price`, `quantity` ở tầng service.
- Cập nhật `ProductService.Create()` để trim tên sản phẩm trước khi lưu.
- Cập nhật `ProductService.GetLowStockProducts()` để xử lý threshold không hợp lệ.
- Build project thành công sau khi cải thiện service.

Checklist:

- [x] Review kiến trúc tổng thể mini project.
- [x] `GetAll()` không trả thẳng danh sách nội bộ.
- [x] `SearchByName()` xử lý keyword rỗng hoặc toàn khoảng trắng.
- [x] `Create()` validate dữ liệu ở tầng service.
- [x] `Create()` trim tên sản phẩm trước khi lưu.
- [x] `GetLowStockProducts()` xử lý threshold không hợp lệ.
- [x] Build pass sau cải thiện service.

---

## Git workflow

Branch đã thực hành:

```text
feature/week2-day01-tinvo
feature/week2-day02-tinvo
feature/week2-day03-tinvo
feature/week2-day04-tinvo
feature/week2-day05-tinvo
```

Một số commit tiêu biểu:

```text
chore: initialize console project
feat: add product model
feat: print sample products
feat: add student age calculation
ci: add dotnet build workflow
feat: add product stock methods
feat: add product validator
feat: add product search by name
feat: add product update and delete menu
feat: add product create menu
feat: add low stock product filter
docs: update day 3 readme
feat: add product service abstraction
refactor: use product service in console menu
docs: update day 4 readme
refactor: improve product service validation
```

Quy ước commit:

| Type | Ý nghĩa |
|---|---|
| `feat` | Thêm chức năng mới. |
| `fix` | Sửa lỗi. |
| `docs` | Cập nhật tài liệu. |
| `chore` | Setup hoặc cấu hình phụ trợ. |
| `ci` | Thay đổi liên quan CI. |
| `refactor` | Sửa cấu trúc code nhưng không đổi chức năng. |

---

## Ghi chú học tập

### OOP và model

- Class là bản thiết kế, object là dữ liệu cụ thể được tạo từ class.
- Model như `Product` nên tập trung mô tả dữ liệu và hành vi sát với object đó.
- `Quantity` dùng `private set` giúp bên ngoài không sửa tồn kho trực tiếp.
- Các thay đổi tồn kho nên đi qua method như `IncreaseStock()` và `DecreaseStock()` để kiểm soát rule.
- `ToString()` giúp object in ra màn hình dễ đọc hơn khi debug hoặc hiển thị Console.

### Validate và encapsulation

- Validate giúp chặn dữ liệu sai sớm, ví dụ tên rỗng, giá nhỏ hơn hoặc bằng 0, số lượng âm.
- Encapsulation giúp dữ liệu không bị sửa tùy tiện từ bên ngoài class.
- Service cũng nên tự validate dữ liệu, không nên phụ thuộc hoàn toàn vào `Program.cs` hoặc UI.
- Input từ người dùng nên được xử lý an toàn bằng `TryParse` thay vì parse trực tiếp.
- Chuỗi nhập từ người dùng nên được `Trim()` để tránh lỗi do khoảng trắng thừa.

### List, CRUD và LINQ

- `List<Product>` phù hợp để thực hành CRUD in-memory.
- CRUD gồm Create, Read, Update, Delete.
- `FirstOrDefault()` phù hợp khi tìm một object và chấp nhận trường hợp không tìm thấy.
- `Where()` phù hợp khi lọc nhiều object theo điều kiện.
- `ToList()` có thể dùng để chuyển kết quả LINQ thành danh sách hoặc tạo bản copy danh sách.
- Khi trả danh sách từ service, nên cân nhắc trả bản copy để tránh code bên ngoài sửa trực tiếp dữ liệu nội bộ.

### Service và interface

- `Program.cs` nên tập trung vào menu, nhập input và in output.
- `ProductService` nên chứa logic nghiệp vụ như thêm, sửa, xóa, tìm kiếm, lọc sản phẩm.
- `IProductService` đóng vai trò hợp đồng, giúp mô tả service cần có những hành động nào.
- Tách service giúp code dễ đọc hơn, dễ test hơn và dễ mở rộng hơn.
- Khi logic bắt đầu dài trong `Program.cs`, đó là dấu hiệu nên tách sang class/service riêng.

### Review và refactor

- Refactor là cải thiện cấu trúc code mà không thay đổi chức năng chính.
- Sau khi refactor phải build và test lại để chắc chắn không làm hỏng hành vi cũ.
- Nên review trách nhiệm của từng file: model làm gì, service làm gì, program làm gì.
- Nên sửa bug nhỏ phát hiện trong lúc test, ví dụ tìm kiếm `lap ` không ra `Laptop`.
- Không nên refactor quá nhiều một lúc; nên chia commit nhỏ để dễ review.

### Git và quy trình làm việc

- Trước khi commit nên chạy `git status` để xem file nào đang thay đổi.
- Nên dùng `git diff` để xem nội dung thay đổi trước khi commit.
- Nên dùng `git diff --staged` để kiểm tra nội dung đã add trước khi commit.
- Không nên dùng `git add .` khi chưa chắc muốn commit toàn bộ file.
- File tài liệu khóa học và file local nên được đưa vào `.gitignore`.
- Sau mỗi ngày nên tạo branch riêng và Pull Request riêng.
- Nếu GitHub báo hai branch có lịch sử khác nhau, có thể cần merge với `--allow-unrelated-histories`.
- Khi gặp conflict, phải mở file bị conflict, giữ nội dung đúng, xóa conflict marker rồi commit merge.
