using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deneme1.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Adi",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DogumTarihi",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "KimlikNo",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Soyadi",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adi",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "DogumTarihi",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "KimlikNo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Soyadi",
                table: "Persons");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
