using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace api_asmontech.Models
{
    public class StatusPedidosModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int16 IdStatus { get; set; }
        public required string Status { get; set; }
    }
}
