using Microsoft.EntityFrameworkCore.Migrations;

namespace TestBeTech.Migrations
{
    public partial class prodstor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorage_Products_ProductId",
                table: "ProductStorage");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductStorage_Storages_StorageId",
                table: "ProductStorage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductStorage",
                table: "ProductStorage");

            migrationBuilder.RenameTable(
                name: "ProductStorage",
                newName: "productStorages");

            migrationBuilder.RenameIndex(
                name: "IX_ProductStorage_StorageId",
                table: "productStorages",
                newName: "IX_productStorages_StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productStorages",
                table: "productStorages",
                columns: new[] { "ProductId", "StorageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_productStorages_Products_ProductId",
                table: "productStorages",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productStorages_Storages_StorageId",
                table: "productStorages",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productStorages_Products_ProductId",
                table: "productStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_productStorages_Storages_StorageId",
                table: "productStorages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productStorages",
                table: "productStorages");

            migrationBuilder.RenameTable(
                name: "productStorages",
                newName: "ProductStorage");

            migrationBuilder.RenameIndex(
                name: "IX_productStorages_StorageId",
                table: "ProductStorage",
                newName: "IX_ProductStorage_StorageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductStorage",
                table: "ProductStorage",
                columns: new[] { "ProductId", "StorageId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorage_Products_ProductId",
                table: "ProductStorage",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductStorage_Storages_StorageId",
                table: "ProductStorage",
                column: "StorageId",
                principalTable: "Storages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
