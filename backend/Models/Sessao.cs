namespace backend.Models {
  public class Sessao {
    public int Id { get; set; }
    public int FilmeId { get; set; }
    public int SalaId { get; set; }
    public DateTime Data { get; set; } 
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFim { get; set; }
    public string Formato { get; set; } = string.Empty;
    public string AudioTipo { get; set; } = string.Empty;
    public decimal PrecoBase { get; set; }
  }
}