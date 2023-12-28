using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int ProdutoID { get; set; }
        public string Nome { get; set; }
        [Column(TypeName = "decimal(18,2)"), Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Preço")]
        public decimal PrecoUnit { get; set; }
    }
}
