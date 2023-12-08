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
                    PostsId = table.Column<int>(type: "int", nullable: false),
                    TagsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => new { x.PostsId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_PostTag_Post_PostsId",
                        column: x => x.PostsId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTag_Tag_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7905), "Books", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7941) },
                    { 2L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7945), "Movies", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7947) },
                    { 3L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7950), "Music", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7951) },
                    { 4L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7953), "Games", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7955) },
                    { 5L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7956), "Electronics", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7958) },
                    { 6L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7959), "Computers", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7961) },
                    { 7L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7962), "Home", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7964) },
                    { 8L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7965), "Garden", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7967) },
                    { 9L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7968), "Tools", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7970) },
                    { 10L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7972), "Grocery", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7973) },
                    { 11L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7975), "Health", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7976) },
                    { 12L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7978), "Beauty", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7979) },
                    { 13L, new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7981), "Toys", new DateTime(2023, 12, 8, 12, 41, 10, 200, DateTimeKind.Local).AddTicks(7982) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostTag_TagsId",
                table: "PostTag",
                column: "TagsId");

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
