using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5833), "Books", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5861) },
                    { 2L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5863), "Movies", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5864) },
                    { 3L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5865), "Music", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5866) },
                    { 4L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5868), "Games", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5869) },
                    { 5L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5870), "Electronics", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5871) },
                    { 6L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5872), "Computers", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5873) },
                    { 7L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5874), "Home", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5875) },
                    { 8L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5876), "Garden", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5877) },
                    { 9L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5879), "Tools", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5879) },
                    { 10L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5902), "Grocery", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5904) },
                    { 11L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5905), "Health", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5907) },
                    { 12L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5908), "Beauty", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5909) },
                    { 13L, new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5910), "Toys", new DateTime(2023, 11, 29, 18, 54, 56, 918, DateTimeKind.Local).AddTicks(5911) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
