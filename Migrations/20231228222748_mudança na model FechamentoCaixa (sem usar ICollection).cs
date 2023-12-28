using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFinal.Migrations
{
    public partial class mudançanamodelFechamentoCaixasemusarICollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Caixas_FechamentoCaixaFechamentoID",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_FechamentoCaixaFechamentoID",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "FechamentoCaixaFechamentoID",
                table: "Compras");

            migrationBuilder.AddColumn<int>(
                name: "CompraID",
                table: "Caixas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Caixas_CompraID",
                table: "Caixas",
                column: "CompraID");

            migrationBuilder.AddForeignKey(
                name: "FK_Caixas_Compras_CompraID",
                table: "Caixas",
                column: "CompraID",
                principalTable: "Compras",
                principalColumn: "CompraID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Caixas_Compras_CompraID",
                table: "Caixas");

            migrationBuilder.DropIndex(
                name: "IX_Caixas_CompraID",
                table: "Caixas");

            migrationBuilder.DropColumn(
                name: "CompraID",
                table: "Caixas");

            migrationBuilder.AddColumn<int>(
                name: "FechamentoCaixaFechamentoID",
                table: "Compras",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_FechamentoCaixaFechamentoID",
                table: "Compras",
                column: "FechamentoCaixaFechamentoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Caixas_FechamentoCaixaFechamentoID",
                table: "Compras",
                column: "FechamentoCaixaFechamentoID",
                principalTable: "Caixas",
                principalColumn: "FechamentoID");
        }
    }
}
