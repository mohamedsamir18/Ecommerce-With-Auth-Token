using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceAuthToken.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "oreders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProdId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oreders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "stores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StoreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StoreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ID);
                    table.ForeignKey(
                        name: "FK_products_stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrederModelProductModel",
                columns: table => new
                {
                    oredersId = table.Column<int>(type: "int", nullable: false),
                    productsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrederModelProductModel", x => new { x.oredersId, x.productsID });
                    table.ForeignKey(
                        name: "FK_OrederModelProductModel_oreders_oredersId",
                        column: x => x.oredersId,
                        principalTable: "oreders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrederModelProductModel_products_productsID",
                        column: x => x.productsID,
                        principalTable: "products",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrederModelProductModel_productsID",
                table: "OrederModelProductModel",
                column: "productsID");

            migrationBuilder.CreateIndex(
                name: "IX_products_StoreId",
                table: "products",
                column: "StoreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrederModelProductModel");

            migrationBuilder.DropTable(
                name: "oreders");

            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.DropTable(
                name: "stores");
        }
    }
}
