using api_asmontech.Models;
using Microsoft.EntityFrameworkCore;

public class MeuContexto : DbContext
{
    // Construtor que aceita DbContextOptions
    public MeuContexto(DbContextOptions<MeuContexto> options) : base(options)
    {
    }
    public DbSet<PedidoModel> PedidoModel { get; set; }
    public DbSet<ItensPedidoModel> ItensPedidoModel { get; set; }
    public DbSet<StatusPedidosModel> StatusPedidosModel { get; set; }
    public DbSet<HorarioFuncionamentoModel> HorarioFuncionamentoModel { get; set; }
    public DbSet<ProdutosModel> ProdutosModel { get; set; }
    public DbSet<TiposProdutoModel> TiposProdutoModel { get; set; }


}