using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Cliente
    {
        public int ClienteID { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string CPF { get; set; }
        virtual public ICollection<Compra>? Compras { get; set; }
    }
}
