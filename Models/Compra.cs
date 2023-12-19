using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Compra
    {
        public int CompraID { get; set; }
        [Required]
        public int ClienteID { get; set; }
        virtual public Cliente Cliente { get; set; }
        public DateTime Data { get; set; }
        [Required]
        public string FormaPagamento { get; set; }
        virtual public ICollection<ItemCompra> Itens { get; set; }
    }
}
