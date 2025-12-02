namespace backend.Models
{
    public class Ingressos
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public int SessaoId { get; set; }
        public int AssentoId { get; set; }
        public string TipoIngresso { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DataCompra {get; set; }
        public decimal ValorTotal { get; set; }
    } 
}
