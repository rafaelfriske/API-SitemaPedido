using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_asmontech.Models
{
    public class ProdutosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int idProduto { get; set; }
        public required string NomeProduto { get; set; }
        [ForeignKey("TiposProdutoModel")]
        public required int IdTipoProduto { get; set; }

        public ICollection<CardapioProdutos> ?CardapioProdutos { get; set; }

    }
}
