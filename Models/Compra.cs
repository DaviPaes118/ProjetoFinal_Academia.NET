using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Compra
    {
        [Key]
        public int CompraID { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }

        public int ProdutoID { get; set; }
        public Produto Produto { get; set; }

        public DateTime? Data { get; set; }

        [Required]
        [Display(Name = "Forma de Pagamento")]
        public string? FormaPagamento { get; set; }
    }
}
