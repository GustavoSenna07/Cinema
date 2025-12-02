namespace backend.Models
{
    public class Pagamentos
    {
        public int Id { get; set; }
        public int ReferenciaId { get; set; }
        public int UsuarioId { get; set; }
        public string Metodo { get; set; } = string.Empty;
        public DateTime DataPagamento { get; set; } 
        public decimal ValorTotal { get; set; }
        public string ReferenciaTipo { get; set; } = string.Empty;
        public string CodigoTransacao { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
