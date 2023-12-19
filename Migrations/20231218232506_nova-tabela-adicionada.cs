using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    public partial class novatabelaadicionada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_ClienteID",
                table: "Compras");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Compras_CompraID",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_CompraID",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CompraID",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "ProdutoID",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "Qtd",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Compras");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ItemCompras",
                columns: table => new
                {
                    ItemCompraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoID = table.Column<int>(type: "int", nullable: false),
                    Qtd = table.Column<int>(type: "int", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ValorUnit = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CompraID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemCompras", x => x.ItemCompraID);
                    table.ForeignKey(
                        name: "FK_ItemCompras_Compras_CompraID",
                        column: x => x.CompraID,
                        principalTable: "Compras",
                        principalColumn: "CompraID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemCompras_Produtos_ProdutoID",
                        column: x => x.ProdutoID,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_CompraID",
                table: "ItemCompras",
                column: "CompraID");

            migrationBuilder.CreateIndex(
                name: "IX_ItemCompras_ProdutoID",
                table: "ItemCompras",
                column: "ProdutoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_ClienteID",
                table: "Compras",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_ClienteID",
                table: "Compras");

            migrationBuilder.DropTable(
                name: "ItemCompras");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CPF",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "CompraID",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ClienteID",
                table: "Compras",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProdutoID",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Qtd",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorTotal",
                table: "Compras",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CompraID",
                table: "Produtos",
                column: "CompraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_ClienteID",
                table: "Compras",
                column: "ClienteID",
                principalTable: "Clientes",
                principalColumn: "ClienteID");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Compras_CompraID",
                table: "Produtos",
                column: "CompraID",
                principalTable: "Compras",
                principalColumn: "CompraID");
        }
    }
}
