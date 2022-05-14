using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PcAccessories.EFCore.Migrations
{
    public partial class addcartentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", unicode: false, fixedLength: true, maxLength: 36, nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CartId = table.Column<Guid>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    UserId = table.Column<Guid>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    CreatetionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatetionBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdateBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductInCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductInCartId = table.Column<Guid>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    ProductId = table.Column<Guid>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    CartId = table.Column<Guid>(type: "char(36)", unicode: false, fixedLength: true, maxLength: 36, nullable: false, collation: "ascii_general_ci"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "double", nullable: false),
                    CreatetionTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatetionBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    UpdateBy = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInCarts", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "40724755-834a-4639-8430-383fab8c52fd");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a7eb4b0d-2dc0-43fd-bb2f-11957d448e18", "AQAAAAEAACcQAAAAEBoWu2MYMt56dGFN3NU+R9gvCkStT+eIyudD3gJIlBBNY1FGeV8BZhn/tEiT30rOAw==" });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_CartId",
                table: "Carts",
                column: "CartId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCarts_ProductInCartId",
                table: "ProductInCarts",
                column: "ProductInCartId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "ProductInCarts");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "129e87d0-a63a-46ec-a43a-41927e48065b");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47e858a6-5887-4d0d-b706-f04f834266d3", "AQAAAAEAACcQAAAAEKc8a+HsoZhDNSKeu48P/HwKMAKCtneCvCl8Nbq25JQgW7CjEn2Ojms58i+H9DXfUw==" });
        }
    }
}
