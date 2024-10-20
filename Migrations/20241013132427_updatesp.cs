using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContactMAnager.Migrations
{
    /// <inheritdoc />
    public partial class updatesp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "phonenumber",
                table: "contactitems",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "lastname",
                table: "contactitems",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "imagepath",
                table: "contactitems",
                newName: "ImagePath");

            migrationBuilder.RenameColumn(
                name: "firstname",
                table: "contactitems",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "NickName",
                table: "contactitems",
                newName: "Nickname");

            migrationBuilder.RenameColumn(
                name: "BirhthDay",
                table: "contactitems",
                newName: "BirthDay");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "contactitems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "contactitems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "contactitems");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "contactitems",
                newName: "phonenumber");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "contactitems",
                newName: "NickName");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "contactitems",
                newName: "lastname");

            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "contactitems",
                newName: "imagepath");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "contactitems",
                newName: "firstname");

            migrationBuilder.RenameColumn(
                name: "BirthDay",
                table: "contactitems",
                newName: "BirhthDay");

            migrationBuilder.AlterColumn<string>(
                name: "lastname",
                table: "contactitems",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);
        }
    }
}
