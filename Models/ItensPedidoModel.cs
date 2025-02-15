using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_asmontech.Models
{
    public class ItensPedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [ForeignKey("PedidoModel")]
        public int IdPedido { get; set; }
        public int idItemPedido { get; set; }
        public Int16 Qtd { get; set; }
        [ForeignKey("ProdutosModel")]
        public required int IdProduto { get; set; }
        public string? Notas { get; set; }
    }
}
