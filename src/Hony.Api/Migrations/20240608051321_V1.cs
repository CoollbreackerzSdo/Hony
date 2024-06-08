using System;

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hony.Api.Migrations;

/// <inheritdoc />
public partial class V1 : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Accounts",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                user_name = table.Column<string>(type: "text", nullable: false),
                email = table.Column<string>(type: "text", nullable: false),
                password = table.Column<string>(type: "text", nullable: false),
                register_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                register_date = table.Column<DateOnly>(type: "date", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false),
                Detail = table.Column<string>(type: "jsonb", nullable: true)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Accounts", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "Categories",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                Name = table.Column<string>(type: "text", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Categories", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "Tags",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Tags", x => x.id);
            });

        migrationBuilder.CreateTable(
            name: "Blogs",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                name = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                content = table.Column<string>(type: "character varying(10000)", maxLength: 10000, nullable: false),
                re_twits = table.Column<int>(type: "integer", nullable: true, defaultValue: 0),
                register_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                register_date = table.Column<DateOnly>(type: "date", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Blogs", x => x.id);
                table.ForeignKey(
                    name: "FK_Blogs_Accounts_CreatorId",
                    column: x => x.CreatorId,
                    principalTable: "Accounts",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "CategoryAndBlogs",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_CategoryAndBlogs", x => x.id);
                table.ForeignKey(
                    name: "FK_CategoryAndBlogs_Blogs_BlogId",
                    column: x => x.BlogId,
                    principalTable: "Blogs",
                    principalColumn: "id");
                table.ForeignKey(
                    name: "FK_CategoryAndBlogs_Categories_CategoryId",
                    column: x => x.CategoryId,
                    principalTable: "Categories",
                    principalColumn: "id");
            });

        migrationBuilder.CreateTable(
            name: "Comments",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                Message = table.Column<string>(type: "character varying(5000)", maxLength: 5000, nullable: false),
                register_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                register_date = table.Column<DateOnly>(type: "date", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Comments", x => x.id);
                table.ForeignKey(
                    name: "FK_Comments_Accounts_CreatorId",
                    column: x => x.CreatorId,
                    principalTable: "Accounts",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_Comments_Blogs_BlogId",
                    column: x => x.BlogId,
                    principalTable: "Blogs",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            name: "TagAndBlogs",
            columns: table => new
            {
                id = table.Column<Guid>(type: "uuid", nullable: false),
                TagId = table.Column<Guid>(type: "uuid", nullable: false),
                BlogId = table.Column<Guid>(type: "uuid", nullable: false),
                is_active = table.Column<bool>(type: "boolean", nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_TagAndBlogs", x => x.id);
                table.ForeignKey(
                    name: "FK_TagAndBlogs_Blogs_BlogId",
                    column: x => x.BlogId,
                    principalTable: "Blogs",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
                table.ForeignKey(
                    name: "FK_TagAndBlogs_Tags_TagId",
                    column: x => x.TagId,
                    principalTable: "Tags",
                    principalColumn: "id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_id",
            table: "Accounts",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_Accounts_user_name",
            table: "Accounts",
            column: "user_name");

        migrationBuilder.CreateIndex(
            name: "IX_Blogs_CreatorId",
            table: "Blogs",
            column: "CreatorId");

        migrationBuilder.CreateIndex(
            name: "IX_Blogs_id",
            table: "Blogs",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_Categories_id",
            table: "Categories",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_CategoryAndBlogs_BlogId",
            table: "CategoryAndBlogs",
            column: "BlogId");

        migrationBuilder.CreateIndex(
            name: "IX_CategoryAndBlogs_CategoryId",
            table: "CategoryAndBlogs",
            column: "CategoryId");

        migrationBuilder.CreateIndex(
            name: "IX_CategoryAndBlogs_id",
            table: "CategoryAndBlogs",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_Comments_BlogId",
            table: "Comments",
            column: "BlogId");

        migrationBuilder.CreateIndex(
            name: "IX_Comments_CreatorId",
            table: "Comments",
            column: "CreatorId");

        migrationBuilder.CreateIndex(
            name: "IX_Comments_id",
            table: "Comments",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_TagAndBlogs_BlogId",
            table: "TagAndBlogs",
            column: "BlogId");

        migrationBuilder.CreateIndex(
            name: "IX_TagAndBlogs_id",
            table: "TagAndBlogs",
            column: "id");

        migrationBuilder.CreateIndex(
            name: "IX_TagAndBlogs_TagId",
            table: "TagAndBlogs",
            column: "TagId");

        migrationBuilder.CreateIndex(
            name: "IX_Tags_id",
            table: "Tags",
            column: "id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            name: "CategoryAndBlogs");

        migrationBuilder.DropTable(
            name: "Comments");

        migrationBuilder.DropTable(
            name: "TagAndBlogs");

        migrationBuilder.DropTable(
            name: "Categories");

        migrationBuilder.DropTable(
            name: "Blogs");

        migrationBuilder.DropTable(
            name: "Tags");

        migrationBuilder.DropTable(
            name: "Accounts");
    }
}