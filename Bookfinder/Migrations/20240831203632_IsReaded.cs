using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bookfinder.Migrations
{
    /// <inheritdoc />
    public partial class IsReaded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsReaded",
                table: "Books",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsReaded",
                table: "Books");
        }
    }
}
