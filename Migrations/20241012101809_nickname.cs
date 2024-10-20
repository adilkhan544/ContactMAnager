using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMAnager.Migrations
{
    /// <inheritdoc />
    public partial class nickname : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "contactitems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NickName",
                table: "contactitems");
        }
    }
}
