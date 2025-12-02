namespace backend.Models
{
  public enum TipoIngresso {Normal, VIP, Meia, Estudante}
    public class Ingressos
    {
        public int Id { get; private set; }
        public required int UsuarioId { get; set; }
        public required int SessaoId { get; set; }
        public int AssentoId { get; set; }
        public string TipoIngresso { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime DataCompra {get; set; } = DateTime.UtcNow;
        public decimal ValorTotal { get; private set; }

        public void PrecoIngresso(string tipoIngresso, decimal valorTotal) {
          tipoIngresso = TipoIngresso.ToLower();
          valorTotal = ValorTotal;
          if(tipoIngresso.Equals("vip"))
          {
            valorTotal += 10;
          }
          else if(tipoIngresso.Equals("meia"))
          {
            valorTotal = valorTotal/2;
          }
          else if(tipoIngresso.Equals("estudante"))
          {
            valorTotal = valorTotal/2 + 5;
          }
        }
    } 
}
