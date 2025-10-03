# ITShop Backend API

RESTful API for IT Shop E-commerce platform built with .NET Core 6.0 and Entity Framework Core.

## 🚀 Features

- **Product Management** - CRUD operations for products
- **Customer Management** - Customer registration and management
- **Order Processing** - Order creation with payment confirmation
- **Stock Management** - Automatic stock reduction on payment confirmation
- **Transaction Safety** - Rollback support for failed operations

## 🛠️ Tech Stack

- **.NET Core 6.0** - Web API framework
- **Entity Framework Core 6.0** - ORM for database operations
- **SQLite** - Lightweight database
- **Swagger/OpenAPI** - API documentation
- **xUnit** - Unit testing framework
- **Moq** - Mocking framework for tests
- **FluentAssertions** - Fluent test assertions

## 🏗️ Architecture

- **Repository Pattern** - Data access abstraction
- **Service Layer** - Business logic separation
- **DTOs** - Data transfer objects for API responses
- **Dependency Injection** - Built-in .NET Core DI

## 📋 Prerequisites

- .NET 6.0 SDK or later

## 🔧 Installation

```bash
# Restore dependencies
dotnet restore

# Apply database migrations
dotnet ef database update

# Run the application
dotnet run
```

The API will be available at:
- HTTPS: `https://localhost:7171`
- HTTP: `http://localhost:5287`
- Swagger UI: `http://localhost:5287/swagger`

## 📦 Project Structure

```
ITShopAPI/
├── Controllers/          # API endpoints
│   ├── ProductsController.cs
│   ├── CustomersController.cs
│   └── OrdersController.cs
├── Services/             # Business logic layer
│   ├── ProductService.cs
│   ├── CustomerService.cs
│   └── OrderService.cs
├── Repositories/         # Data access layer
│   ├── IRepository.cs
│   └── Repository.cs
├── Models/               # Database entities
│   ├── Product.cs
│   ├── Customer.cs
│   ├── Order.cs
│   └── OrderItem.cs
├── DTOs/                 # Data transfer objects
│   ├── ProductDto.cs
│   ├── CustomerDto.cs
│   └── OrderDto.cs
├── Data/                 # Database context
│   └── ApplicationDbContext.cs
└── Migrations/           # EF Core migrations

ITShopAPI.Tests/
└── Services/             # Unit tests
    ├── ProductServiceTests.cs
    └── OrderServiceTests.cs
```

## 🔌 API Endpoints

### Products
- `GET /api/products` - Get all products
- `GET /api/products/{id}` - Get product by ID
- `POST /api/products` - Create new product
- `PUT /api/products/{id}` - Update product
- `DELETE /api/products/{id}` - Delete product

### Customers
- `GET /api/customers` - Get all customers
- `GET /api/customers/{id}` - Get customer by ID
- `POST /api/customers` - Create new customer
- `PUT /api/customers/{id}` - Update customer
- `DELETE /api/customers/{id}` - Delete customer

### Orders
- `GET /api/orders/{id}` - Get order by ID
- `GET /api/orders/customer/{customerId}` - Get orders by customer
- `POST /api/orders` - Create new order
- `POST /api/orders/{id}/confirm-payment` - Confirm payment and reduce stock
- `POST /api/orders/{id}/cancel` - Cancel order

## 🔄 Stock Management Flow

1. **Create Order** (`POST /api/orders`)
   - Validates product availability
   - Creates order with "Pending" status
   - Does NOT reduce stock yet

2. **Confirm Payment** (`POST /api/orders/{id}/confirm-payment`)
   - Updates order status to "Confirmed"
   - Updates payment status to "Paid"
   - **Reduces product stock** (with transaction support)
   - Rolls back if stock reduction fails

3. **Cancel Order** (`POST /api/orders/{id}/cancel`)
   - Updates order status to "Cancelled"
   - Does not affect stock (since it wasn't reduced yet)

## ⚡ Performance Optimizations

- Response caching (60 seconds)
- Database indexing on frequently queried columns
- `AsNoTracking()` for read-only queries
- Efficient relationship loading with `.Include()`

## 🧪 Running Tests

```bash
# Run all tests
dotnet test

# Run tests with detailed output
dotnet test --logger "console;verbosity=detailed"

# Run specific test class
dotnet test --filter ProductServiceTests
```

**Test Coverage:**
- 23 total tests
- 12 ProductService tests
- 11 OrderService tests

## 🗄️ Database

The project uses SQLite with Entity Framework Core migrations:

```bash
# Create a new migration
dotnet ef migrations add MigrationName

# Apply migrations
dotnet ef database update

# Remove last migration
dotnet ef migrations remove
```

## 📊 Sample Data

The database is seeded with 20 sample products on first run. Check `ApplicationDbContext.cs` for seed data implementation.

## 🔒 CORS Configuration

CORS is enabled for `http://localhost:5173` (Vite dev server). Update `Program.cs` to allow other origins:

```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowViteApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
```

## 🔗 Related Repository

- **Frontend Application**: [itshop-Frontend](https://github.com/YOUR_USERNAME/itshop-Frontend)

## 📝 Development Notes

### Technical Decisions
1. **Stock Management** - Stock is reduced only on payment confirmation to handle payment failures gracefully
2. **Transaction Support** - Database transactions ensure data consistency
3. **Repository Pattern** - Provides abstraction and testability
4. **DTOs** - Separates API contracts from database models

### Future Enhancements
- JWT Authentication
- Payment gateway integration
- Email notifications
- Order tracking system
- Advanced search and filtering

## � ข้อ 4: ความคิดเห็นสำหรับโปรแกรมเมอร์ที่ใช้ AI ในการพัฒนาโปรแกรม

การใช้ AI ในการพัฒนาโปรแกรมเปรียบเสมือนการมี **"ผู้ช่วยอัจฉริยะ"** อยู่ข้างๆ มันไม่ใช่การมาแทนที่นักพัฒนา แต่เป็นการ **"เพิ่มขีดความสามารถ" (Augmentation)** ของนักพัฒนา

นักพัฒนาที่เก่งจะใช้ AI เพื่อทำงานที่น่าเบื่อและซ้ำซากให้เสร็จเร็วขึ้น แล้วนำเวลาที่เหลือไปใช้กับการออกแบบสถาปัตยกรรม, การคิดแก้ปัญหาที่ซับซ้อน, และการสร้างสรรค์นวัตกรรมใหม่ๆ ซึ่งเป็นสิ่งที่ AI ยังทำได้ไม่ดีเท่ามนุษย์ครับ

## �📄 License

MIT License

## 👨‍💻 Author

Developed as an IT Shop E-commerce project
