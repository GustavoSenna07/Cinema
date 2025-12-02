using System.Runtime.Serialization;

namespace backend.Models {
  public enum formatoFilme {DoisD, TresD};
  public enum tipoAudio {Dublado, Legendado};
  public class Sessao {
    public int Id { get; private set; }
    public required int FilmeId { get; set; }
    public required int SalaId { get; set; }
    public DateTime Data { get; set; } 
    public TimeSpan HorarioInicio { get; set; }
    public TimeSpan HorarioFim { get; set; }
    public formatoFilme Formato { get; set; } = formatoFilme.DoisD;
    public tipoAudio AudioTipo { get; set; } = tipoAudio.Dublado;
    public decimal PrecoBase { get; private set; } = 40;
  }
}