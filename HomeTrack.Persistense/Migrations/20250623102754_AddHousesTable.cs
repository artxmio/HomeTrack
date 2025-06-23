using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTrack.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class AddHousesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "HouseId",
                table: "Apartments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "Houses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Street = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    City = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Number = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NumberOfFloors = table.Column<int>(type: "int", nullable: false),
                    NumberOfEntrances = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Houses", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_HouseId",
                table: "Apartments",
                column: "HouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_Id",
                table: "Apartments",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_Id",
                table: "Houses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropTable(
                name: "Houses");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_HouseId",
                table: "Apartments");

            migrationBuilder.DropIndex(
                name: "IX_Apartments_Id",
                table: "Apartments");

            migrationBuilder.DropColumn(
                name: "HouseId",
                table: "Apartments");
        }
    }
}
