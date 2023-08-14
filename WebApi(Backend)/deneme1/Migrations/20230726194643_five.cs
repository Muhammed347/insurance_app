using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deneme1.Migrations
{
    /// <inheritdoc />
    public partial class five : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Polices");

            migrationBuilder.RenameColumn(
                name: "Soyadi",
                table: "Persons",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Adi",
                table: "Persons",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Persons",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VadeBitis",
                table: "Dasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VadeBaslangic",
                table: "Dasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanzimTarihi",
                table: "Dasks",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<double>(
                name: "Prim",
                table: "Dasks",
                type: "float",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Ilce",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Il",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "Healths",
                columns: table => new
                {
                    HealthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TanzimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBitis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Healths", x => x.HealthId);
                    table.ForeignKey(
                        name: "FK_Healths_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Healths_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Traffics",
                columns: table => new
                {
                    TrafficId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlakaIlKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlakaKodu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    TanzimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBitis = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Traffics", x => x.TrafficId);
                    table.ForeignKey(
                        name: "FK_Traffics_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Traffics_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Healths_PersonId",
                table: "Healths",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Healths_ProductId",
                table: "Healths",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Traffics_PersonId",
                table: "Traffics",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Traffics_ProductId",
                table: "Traffics",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Healths");

            migrationBuilder.DropTable(
                name: "Traffics");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Persons",
                newName: "Soyadi");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Persons",
                newName: "Adi");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DogumTarihi",
                table: "Persons",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VadeBitis",
                table: "Dasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "VadeBaslangic",
                table: "Dasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "TanzimTarihi",
                table: "Dasks",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Prim",
                table: "Dasks",
                type: "float",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Ilce",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Il",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adress",
                table: "Dasks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Polices",
                columns: table => new
                {
                    PoliceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PoliceNum = table.Column<int>(type: "int", nullable: false),
                    PoliceType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Polices", x => x.PoliceId);
                });
        }
    }
}
