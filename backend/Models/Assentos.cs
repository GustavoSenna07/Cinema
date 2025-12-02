namespace backend.Models
{
  public enum TipoAssento {Normal, VIP}

  public class Assentos
  {
    public int Id { get; private set; }
    public required int SalaId { get; set; }
    public string Fileira { get; set; } = string.Empty;
    public string Coluna { get; set; } = string.Empty;
    public TipoAssento Tipo { get; set; } = TipoAssento.Normal;
    public string Status { get; set; } = string.Empty;
  }
}
