﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTrack.Persistense.Migrations
{
    /// <inheritdoc />
    public partial class Check : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialСomplexId",
                table: "Houses",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseId",
                table: "Apartments",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses",
                column: "ResidentialСomplexId",
                principalTable: "ResidentialComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments");

            migrationBuilder.DropForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses");

            migrationBuilder.AlterColumn<Guid>(
                name: "ResidentialСomplexId",
                table: "Houses",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AlterColumn<Guid>(
                name: "HouseId",
                table: "Apartments",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_Apartments_Houses_HouseId",
                table: "Apartments",
                column: "HouseId",
                principalTable: "Houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Houses_ResidentialComplexes_ResidentialСomplexId",
                table: "Houses",
                column: "ResidentialСomplexId",
                principalTable: "ResidentialComplexes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
