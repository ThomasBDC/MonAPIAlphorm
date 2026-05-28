using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MonAPIAlphorm.Migrations
{
    /// <inheritdoc />
    public partial class AddCompanyLinkedToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "Propects",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Propects_CompanyId",
                table: "Propects",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Propects_Companies_CompanyId",
                table: "Propects",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Propects_Companies_CompanyId",
                table: "Propects");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropIndex(
                name: "IX_Propects_CompanyId",
                table: "Propects");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Propects");
        }
    }
}
