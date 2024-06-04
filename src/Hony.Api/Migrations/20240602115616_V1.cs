using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hony.Api.Migrations
{
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
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    register_time = table.Column<TimeOnly>(type: "time without time zone", nullable: false),
                    register_date = table.Column<DateOnly>(type: "date", nullable: false),
                    Detail = table.Column<string>(type: "jsonb", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_id",
                table: "Accounts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_user_name",
                table: "Accounts",
                column: "user_name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accounts");
        }
    }
}
