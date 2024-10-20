using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMAnager.Migrations
{
    /// <inheritdoc />
    public partial class setp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "contactname",
                table: "contactitems");

            migrationBuilder.AddColumn<string>(
                name: "firstname",
                table: "contactitems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "lastname",
                table: "contactitems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "firstname",
                table: "contactitems");

            migrationBuilder.DropColumn(
                name: "lastname",
                table: "contactitems");

            migrationBuilder.AddColumn<string>(
                name: "contactname",
                table: "contactitems",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}
