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

        
        public void CalcularPreco()
        {
          string tipo = TipoIngresso.ToLower();

          if (tipo == "vip")
              ValorTotal += 10;
          else if (tipo == "meia")
              ValorTotal /= 2;
          else if (tipo == "estudante")
              ValorTotal = (ValorTotal / 2) + 5;
        }

    } 
}
