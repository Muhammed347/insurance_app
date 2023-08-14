using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace deneme1.Migrations
{
    /// <inheritdoc />
    public partial class sixth : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dasks_Persons_PersonId",
                table: "Dasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Dasks_Product_ProductId",
                table: "Dasks");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffics_Persons_PersonId",
                table: "Traffics");

            migrationBuilder.DropForeignKey(
                name: "FK_Traffics_Product_ProductId",
                table: "Traffics");

            migrationBuilder.DropTable(
                name: "Healths");

            migrationBuilder.DropIndex(
                name: "IX_Traffics_PersonId",
                table: "Traffics");

            migrationBuilder.DropIndex(
                name: "IX_Traffics_ProductId",
                table: "Traffics");

            migrationBuilder.DropIndex(
                name: "IX_Dasks_PersonId",
                table: "Dasks");

            migrationBuilder.DropIndex(
                name: "IX_Dasks_ProductId",
                table: "Dasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Traffics");

            migrationBuilder.DropColumn(
                name: "TanzimTarihi",
                table: "Traffics");

            migrationBuilder.DropColumn(
                name: "KimlikNo",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "PolicyId",
                table: "Dasks");

            migrationBuilder.DropColumn(
                name: "TanzimTarihi",
                table: "Dasks");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameColumn(
                name: "VadeBitis",
                table: "Traffics",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "VadeBaslangic",
                table: "Traffics",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "PlakaKodu",
                table: "Traffics",
                newName: "PlateCode");

            migrationBuilder.RenameColumn(
                name: "PlakaIlKodu",
                table: "Traffics",
                newName: "PlateCityCode");

            migrationBuilder.RenameColumn(
                name: "DogumTarihi",
                table: "Persons",
                newName: "BirthDate");

            migrationBuilder.RenameColumn(
                name: "VadeBitis",
                table: "Dasks",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "VadeBaslangic",
                table: "Dasks",
                newName: "ExpiryDate");

            migrationBuilder.RenameColumn(
                name: "Ilce",
                table: "Dasks",
                newName: "District");

            migrationBuilder.RenameColumn(
                name: "Il",
                table: "Dasks",
                newName: "City");

            migrationBuilder.AddColumn<string>(
                name: "IdentificationNo",
                table: "Persons",
                type: "nvarchar(11)",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "Kaskos",
                columns: table => new
                {
                    KaskoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VehicleBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Prim = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kaskos", x => x.KaskoId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kaskos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IdentificationNo",
                table: "Persons");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Traffics",
                newName: "VadeBitis");

            migrationBuilder.RenameColumn(
                name: "PlateCode",
                table: "Traffics",
                newName: "PlakaKodu");

            migrationBuilder.RenameColumn(
                name: "PlateCityCode",
                table: "Traffics",
                newName: "PlakaIlKodu");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Traffics",
                newName: "VadeBaslangic");

            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Persons",
                newName: "DogumTarihi");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Dasks",
                newName: "VadeBitis");

            migrationBuilder.RenameColumn(
                name: "ExpiryDate",
                table: "Dasks",
                newName: "VadeBaslangic");

            migrationBuilder.RenameColumn(
                name: "District",
                table: "Dasks",
                newName: "Ilce");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Dasks",
                newName: "Il");

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Traffics",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanzimTarihi",
                table: "Traffics",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KimlikNo",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PolicyId",
                table: "Dasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "TanzimTarihi",
                table: "Dasks",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "ProductId");

            migrationBuilder.CreateTable(
                name: "Healths",
                columns: table => new
                {
                    HealthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    PolicyId = table.Column<int>(type: "int", nullable: false),
                    Prim = table.Column<double>(type: "float", nullable: true),
                    TanzimTarihi = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBaslangic = table.Column<DateTime>(type: "datetime2", nullable: true),
                    VadeBitis = table.Column<DateTime>(type: "datetime2", nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_Traffics_PersonId",
                table: "Traffics",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Traffics_ProductId",
                table: "Traffics",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Dasks_PersonId",
                table: "Dasks",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Dasks_ProductId",
                table: "Dasks",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Healths_PersonId",
                table: "Healths",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Healths_ProductId",
                table: "Healths",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dasks_Persons_PersonId",
                table: "Dasks",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Dasks_Product_ProductId",
                table: "Dasks",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traffics_Persons_PersonId",
                table: "Traffics",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Traffics_Product_ProductId",
                table: "Traffics",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
