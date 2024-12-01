namespace GestaoProduto.API.Models
{
    public class NovoProduto
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string CodigoBarra { get; set; }
        public decimal Valor { get; set; }
        public int Estoque { get; set; }
    }
}
