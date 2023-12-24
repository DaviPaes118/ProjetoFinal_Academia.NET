namespace ProjetoFinal.Models
{
    public class FechamentoCaixa
    {
        public int FechamentoID { get; set; }
        public DateTime Data { get; set; }
        public int CompraID { get; set; }
        virtual public Compra Compra { get; set; }
    }
}
