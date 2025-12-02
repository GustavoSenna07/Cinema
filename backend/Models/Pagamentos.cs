namespace backend.Models
{
    public enum metodosPagamento {Pix, Debito, Credito, Dinheiro}
    public class Pagamentos
    {
        public int Id { get; private set; }
        public required int ReferenciaId { get; set; }
        public required int UsuarioId { get; set; }
        public metodosPagamento Metodo { get; set; } = metodosPagamento.Debito;
        public DateTime DataPagamento { get; set; } = DateTime.UtcNow;
        public decimal ValorTotal { get; private set; }
        public string ReferenciaTipo { get; set; } = string.Empty;
        public string CodigoTransacao { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
