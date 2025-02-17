using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_asmontech.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTabelaTiposProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TipoProduto",
                table: "TiposProdutoModel",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TipoProduto",
                table: "TiposProdutoModel",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }
    }
}
