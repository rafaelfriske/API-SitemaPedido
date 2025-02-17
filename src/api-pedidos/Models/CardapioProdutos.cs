using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_asmontech.Models
{
    public class CardapioProdutos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdCardapioProduto { get; set; }
        [ForeignKey("ProdutosModel")]
        public int IdProduto { get; set; }
        [ForeignKey("HorariosFuncionamentoModel")]
        public int IdHorarioFuncionamento { get; set; }

        public ProdutosModel ?Produto { get; set; }
        public HorarioFuncionamentoModel ?HorarioFuncionamento { get; set; }

    }
}
