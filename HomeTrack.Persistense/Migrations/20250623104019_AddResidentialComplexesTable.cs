using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTrack.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class AddResidentialComplexesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ResidentialСomplexId",
                table: "Houses",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateTable(
                name: "ResidentialComplexes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentialComplexes", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Houses_ResidentialСomplexId",
                table: "Houses",
                column: "ResidentialСomplexId");

            migrationBuilder.CreateIndex(
                name: "IX_ResidentialComplexes_Id",
                table: "ResidentialComplexes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses",
                column: "ResidentialСomplexId",
                principalTable: "ResidentialComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses");

            migrationBuilder.DropTable(
                name: "ResidentialComplexes");

            migrationBuilder.DropIndex(
                name: "IX_Houses_ResidentialСomplexId",
                table: "Houses");

            migrationBuilder.DropColumn(
                name: "ResidentialСomplexId",
                table: "Houses");
        }
    }
}
