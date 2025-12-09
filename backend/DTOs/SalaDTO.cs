namespace backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Models;

public class SalaResponseDTO
{
    public int Id { get; set; }
    public int Numero { get; set; } = 1;
    public int Capacidade{ get; set; }
    public tipoSala TipoSala {get; set; } = tipoSala.Normal;
    public SalaResponseDTO(Salas s) {
      Numero = s.Numero;
      Capacidade = s.Capacidade;
      TipoSala = s.TipoSala;
    }
}

public class CriarSalaDTO
{
  [Required(ErrorMessage = "Numero da Sala Necessario")]
  public int Numero { get; set; }
  [Required(ErrorMessage = "Capacidade da Sala Necessaria")]
  public int Capacidade { get; set; } 
  [Required(ErrorMessage = "Tipo da Sala Necessaria")]
  public tipoSala TipoSala { get; set; } = tipoSala.Normal;
}

public class AtualizarSalaDTO
{
  public int Numero { get; set; }
  public int Capacidade { get; set; }
  public tipoSala TipoSala { get; set; } = tipoSala.Normal;
}