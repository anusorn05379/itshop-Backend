using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ITShopAPI.Migrations
{
    public partial class AddPerformanceIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(519), "https://placehold.co/300x200/1890ff/white?text=Dell+XPS+15", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(531) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(533), "https://placehold.co/300x200/52c41a/white?text=iPhone+15+Pro", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(534) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(535), "https://placehold.co/300x200/722ed1/white?text=Galaxy+S24", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(535) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(536), "https://placehold.co/300x200/fa8c16/white?text=MacBook+Air", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(537) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(538), "https://placehold.co/300x200/eb2f96/white?text=iPad+Pro", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(538) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(539), "https://placehold.co/300x200/13c2c2/white?text=ASUS+ROG", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(540) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(541), "https://placehold.co/300x200/2f54eb/white?text=Sony+WH-1000XM5", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(541) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(542), "https://placehold.co/300x200/a0d911/white?text=MX+Master+3S", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(543) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(543), "https://placehold.co/300x200/f5222d/white?text=Apple+Watch+9", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(544) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(545), "https://placehold.co/300x200/1890ff/white?text=Samsung+4K+32", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(545) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(546), "https://placehold.co/300x200/52c41a/white?text=Razer+BlackWidow", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(547) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(548), "https://placehold.co/300x200/722ed1/white?text=WD+Passport+2TB", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(548) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(549), "https://placehold.co/300x200/fa8c16/white?text=AirPods+Pro+2", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(549) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(550), "https://placehold.co/300x200/eb2f96/white?text=Mi+Band+8", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(551) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(552), "https://placehold.co/300x200/13c2c2/white?text=Canon+EOS+R6", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(552) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(585), "https://placehold.co/300x200/2f54eb/white?text=DJI+Mini+3", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(587), "https://placehold.co/300x200/a0d911/white?text=GoPro+Hero+12", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(588), "https://placehold.co/300x200/f5222d/white?text=Switch+OLED", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(589) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(590), "https://placehold.co/300x200/1890ff/white?text=PlayStation+5", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(590) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(591), "https://placehold.co/300x200/52c41a/white?text=Xbox+Series+X", new DateTime(2025, 10, 3, 15, 8, 46, 916, DateTimeKind.Local).AddTicks(591) });

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Price",
                table: "Products",
                column: "Price");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentStatus",
                table: "Orders",
                column: "PaymentStatus");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_Status",
                table: "Orders",
                column: "Status");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Price",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentStatus",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_Status",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1573), "https://via.placeholder.com/300x200?text=Dell+XPS+15", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1594) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1597), "https://via.placeholder.com/300x200?text=iPhone+15+Pro", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1598) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1600), "https://via.placeholder.com/300x200?text=Galaxy+S24", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1601) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1602), "https://via.placeholder.com/300x200?text=MacBook+Air", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1603) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1604), "https://via.placeholder.com/300x200?text=iPad+Pro", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1605) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1606), "https://via.placeholder.com/300x200?text=ASUS+ROG", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1607) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1608), "https://via.placeholder.com/300x200?text=Sony+WH-1000XM5", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1609) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1610), "https://via.placeholder.com/300x200?text=MX+Master+3S", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1611) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1612), "https://via.placeholder.com/300x200?text=Apple+Watch+9", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1613) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1615), "https://via.placeholder.com/300x200?text=Samsung+4K+32", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1616), "https://via.placeholder.com/300x200?text=Razer+BlackWidow", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1617) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1618), "https://via.placeholder.com/300x200?text=WD+Passport+2TB", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1619) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1620), "https://via.placeholder.com/300x200?text=AirPods+Pro+2", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1621) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1622), "https://via.placeholder.com/300x200?text=Mi+Band+8", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1622) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1624), "https://via.placeholder.com/300x200?text=Canon+EOS+R6", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1624) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1625), "https://via.placeholder.com/300x200?text=DJI+Mini+3", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1626) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1628), "https://via.placeholder.com/300x200?text=GoPro+Hero+12", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1628) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1630), "https://via.placeholder.com/300x200?text=Switch+OLED", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1631) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1632), "https://via.placeholder.com/300x200?text=PlayStation+5", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1633) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "ImageUrl", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1634), "https://via.placeholder.com/300x200?text=Xbox+Series+X", new DateTime(2025, 10, 3, 14, 40, 57, 655, DateTimeKind.Local).AddTicks(1635) });
        }
    }
}
