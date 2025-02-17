using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_asmontech.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabelaTiposProdutos1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "IdTipoProduto",
                table: "ProdutosModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.CreateTable(
                name: "CardapioProdutos",
                columns: table => new
                {
                    IdCardapioProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    IdHorarioFuncionamento = table.Column<int>(type: "INTEGER", nullable: false),
                    ProdutoidProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    HorarioFuncionamentoidHorarioFuncionamento = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardapioProdutos", x => x.IdCardapioProduto);
                    table.ForeignKey(
                        name: "FK_CardapioProdutos_HorarioFuncionamentoModel_HorarioFuncionamentoidHorarioFuncionamento",
                        column: x => x.HorarioFuncionamentoidHorarioFuncionamento,
                        principalTable: "HorarioFuncionamentoModel",
                        principalColumn: "idHorarioFuncionamento",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CardapioProdutos_ProdutosModel_ProdutoidProduto",
                        column: x => x.ProdutoidProduto,
                        principalTable: "ProdutosModel",
                        principalColumn: "idProduto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CardapioProdutos_HorarioFuncionamentoidHorarioFuncionamento",
                table: "CardapioProdutos",
                column: "HorarioFuncionamentoidHorarioFuncionamento");

            migrationBuilder.CreateIndex(
                name: "IX_CardapioProdutos_ProdutoidProduto",
                table: "CardapioProdutos",
                column: "ProdutoidProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CardapioProdutos");

            migrationBuilder.AlterColumn<string>(
                name: "IdTipoProduto",
                table: "ProdutosModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }
    }
}
