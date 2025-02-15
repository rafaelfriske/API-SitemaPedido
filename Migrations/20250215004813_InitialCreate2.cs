using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_asmontech.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HorarioFuncionamentoModel",
                columns: table => new
                {
                    idHorarioFuncionamento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descricao = table.Column<string>(type: "TEXT", nullable: false),
                    HorarioInicio = table.Column<DateTime>(type: "TEXT", nullable: false),
                    HorarioFim = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorarioFuncionamentoModel", x => x.idHorarioFuncionamento);
                });

            migrationBuilder.CreateTable(
                name: "PedidoModel",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdCliente = table.Column<int>(type: "INTEGER", nullable: false),
                    IdStatus = table.Column<short>(type: "INTEGER", nullable: false),
                    DtRegister = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoModel", x => x.IdPedido);
                });

            migrationBuilder.CreateTable(
                name: "ProdutosModel",
                columns: table => new
                {
                    idProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NomeProduto = table.Column<string>(type: "TEXT", nullable: false),
                    IdTipoProduto = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutosModel", x => x.idProduto);
                });

            migrationBuilder.CreateTable(
                name: "StatusPedidosModel",
                columns: table => new
                {
                    IdStatus = table.Column<short>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Status = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusPedidosModel", x => x.IdStatus);
                });

            migrationBuilder.CreateTable(
                name: "TiposProdutoModel",
                columns: table => new
                {
                    IdTipoProduto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoProduto = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposProdutoModel", x => x.IdTipoProduto);
                });

            migrationBuilder.CreateTable(
                name: "ItensPedidoModel",
                columns: table => new
                {
                    IdPedido = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    idItemPedido = table.Column<int>(type: "INTEGER", nullable: false),
                    Qtd = table.Column<short>(type: "INTEGER", nullable: false),
                    IdProduto = table.Column<int>(type: "INTEGER", nullable: false),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    PedidoModelIdPedido = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensPedidoModel", x => x.IdPedido);
                    table.ForeignKey(
                        name: "FK_ItensPedidoModel_PedidoModel_PedidoModelIdPedido",
                        column: x => x.PedidoModelIdPedido,
                        principalTable: "PedidoModel",
                        principalColumn: "IdPedido");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensPedidoModel_PedidoModelIdPedido",
                table: "ItensPedidoModel",
                column: "PedidoModelIdPedido");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorarioFuncionamentoModel");

            migrationBuilder.DropTable(
                name: "ItensPedidoModel");

            migrationBuilder.DropTable(
                name: "ProdutosModel");

            migrationBuilder.DropTable(
                name: "StatusPedidosModel");

            migrationBuilder.DropTable(
                name: "TiposProdutoModel");

            migrationBuilder.DropTable(
                name: "PedidoModel");
        }
    }
}
