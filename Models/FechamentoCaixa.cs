using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class FechamentoCaixa
    {
        [Key]
        public int FechamentoID { get; set; }
        public DateTime DataFechamento { get; set; }
        public decimal ValorInicial { get; set; }
        public decimal ValorFinal { get; set; }
        public ICollection<Compra> Compras { get; set; }
    }
}
