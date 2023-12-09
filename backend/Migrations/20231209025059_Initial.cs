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
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    PostId = table.Column<int>(type: "int", nullable: false),
                    TagId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2641), "Books", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2671) },
                    { 2L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2673), "Movies", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2674) },
                    { 3L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2676), "Music", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2677) },
                    { 4L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2678), "Games", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2679) },
                    { 5L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2680), "Electronics", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2681) },
                    { 6L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2683), "Computers", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2684) },
                    { 7L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2685), "Home", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2686) },
                    { 8L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2687), "Garden", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2688) },
                    { 9L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2689), "Tools", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2690) },
                    { 10L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2691), "Grocery", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2692) },
                    { 11L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2693), "Health", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2694) },
                    { 12L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2695), "Beauty", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2696) },
                    { 13L, new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2697), "Toys", new DateTime(2023, 12, 8, 21, 50, 59, 140, DateTimeKind.Local).AddTicks(2699) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagId",
                table: "PostTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_CategoryId",
                table: "Product",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
