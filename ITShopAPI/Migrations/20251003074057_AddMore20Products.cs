using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITShopAPI.Migrations
{
    public partial class AddMore20Products : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Phone = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Address = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    ImageUrl = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CustomerId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Status = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    PaymentStatus = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')"),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValueSql: "datetime('now')")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 1, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1573), "High-performance laptop for professionals", "https://via.placeholder.com/300x200?text=Dell+XPS+15", "Laptop Dell XPS 15", 45000m, 10, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1594) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 2, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1597), "Latest Apple smartphone with titanium design", "https://via.placeholder.com/300x200?text=iPhone+15+Pro", "iPhone 15 Pro", 42000m, 15, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1598) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 3, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1600), "Flagship Android smartphone with AI features", "https://via.placeholder.com/300x200?text=Galaxy+S24", "Samsung Galaxy S24", 35000m, 20, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1601) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 4, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1602), "Ultra-thin laptop with powerful M3 chip", "https://via.placeholder.com/300x200?text=MacBook+Air", "MacBook Air M3", 48000m, 8, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 5, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1604), "Professional tablet for creative work", "https://via.placeholder.com/300x200?text=iPad+Pro", "iPad Pro 12.9", 38000m, 12, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 6, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1606), "Ultimate gaming laptop with RTX 4090", "https://via.placeholder.com/300x200?text=ASUS+ROG", "ASUS ROG Strix Gaming Laptop", 75000m, 5, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1607) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 7, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1608), "Premium noise-cancelling wireless headphones", "https://via.placeholder.com/300x200?text=Sony+WH-1000XM5", "Sony WH-1000XM5 Headphones", 15000m, 25, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 8, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1610), "Advanced wireless mouse for professionals", "https://via.placeholder.com/300x200?text=MX+Master+3S", "Logitech MX Master 3S Mouse", 3500m, 30, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 9, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1612), "Latest smartwatch with advanced health features", "https://via.placeholder.com/300x200?text=Apple+Watch+9", "Apple Watch Series 9", 18000m, 18, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 10, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1615), "Ultra HD monitor for professional work", "https://via.placeholder.com/300x200?text=Samsung+4K+32", "Samsung 4K Monitor 32 inch", 22000m, 12, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1615) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 11, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1616), "Mechanical gaming keyboard with RGB", "https://via.placeholder.com/300x200?text=Razer+BlackWidow", "Razer BlackWidow V3 Keyboard", 5500m, 22, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 12, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1618), "Portable external hard drive", "https://via.placeholder.com/300x200?text=WD+Passport+2TB", "WD My Passport 2TB External HDD", 2800m, 40, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1619) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 13, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1620), "Active noise cancellation wireless earbuds", "https://via.placeholder.com/300x200?text=AirPods+Pro+2", "AirPods Pro 2nd Gen", 9500m, 28, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1621) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 14, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1622), "Affordable fitness tracker smartband", "https://via.placeholder.com/300x200?text=Mi+Band+8", "Xiaomi Mi Band 8", 1200m, 50, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 15, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1624), "Professional mirrorless camera", "https://via.placeholder.com/300x200?text=Canon+EOS+R6", "Canon EOS R6 Camera", 95000m, 6, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 16, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1625), "Compact drone with 4K camera", "https://via.placeholder.com/300x200?text=DJI+Mini+3", "DJI Mini 3 Pro Drone", 28000m, 10, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 17, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1628), "Action camera with 5.3K video", "https://via.placeholder.com/300x200?text=GoPro+Hero+12", "GoPro Hero 12", 18500m, 15, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 18, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1630), "Gaming console with vibrant OLED screen", "https://via.placeholder.com/300x200?text=Switch+OLED", "Nintendo Switch OLED", 12500m, 20, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1631) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 19, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1632), "Next-gen gaming console", "https://via.placeholder.com/300x200?text=PlayStation+5", "PlayStation 5", 19900m, 8, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedDate", "Description", "ImageUrl", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 20, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1634), "Powerful gaming console with 4K support", "https://via.placeholder.com/300x200?text=Xbox+Series+X", "Xbox Series X", 18500m, 12, new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1635) });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductId",
                table: "OrderItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
