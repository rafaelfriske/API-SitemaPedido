using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_asmontech.Models
{

    public class PedidoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPedido { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("StatusPedidosModel")]
        public Int16 IdStatus { get; set; } // "Café da manhã" ou "Almoço"
        public required string DtRegister { get; set; }
      
        public required ICollection<ItensPedidoModel> Itens { get; set; }
    }
}
