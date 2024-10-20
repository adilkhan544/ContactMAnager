using System;
using Microsoft.EntityFrameworkCore.Migrations;
using ContactMAnager.Data;
#nullable disable

namespace ContactMAnager.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contactitems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    contactname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phonenumber = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    imagepath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirhthDay = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contactitems", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "contactitems");
        }
    }
}
