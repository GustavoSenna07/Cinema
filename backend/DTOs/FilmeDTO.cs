namespace backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Models;

public class FilmeResponseDTO
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Diretor { get; set; } = string.Empty;
    public string Estudio { get; set; } = string.Empty;
    public DateTime DataLancamento {get; set; }
    public int DuracaoMinutos { get; set; }
    public string Classificacao { get; set; }
    public string Sinopse { get; set; }
    public string ImagemURL { get; set; }
    public string Elenco { get; set; }
    public FilmeResponseDTO(Filme p) {
      Id = p.Id;
      Titulo = p.Titulo;
      Genero = p.Genero;
      Diretor = p.Diretor;
      Estudio = p.Estudio;
      DataLancamento = p.DataLancamento;
      DuracaoMinutos = p.DuracaoMinutos;
      Classificacao = p.Classificacao;
      Sinopse = p.Sinopse;
      ImagemURL = p.ImagemURL;
      Elenco = p.Elenco;
    }
}

public class CriarFilmeDTO
{
  [Required(ErrorMessage = "Titulo do Filme Necessario")]
  public required string Titulo { get; set; } = string.Empty;

  [Required(ErrorMessage = "Duracao do Filme Necassario")]
  public required int DuracaoMinutos { get; set; }
  public string Genero { get; set; } = string.Empty;
  public string Diretor { get; set; } = string.Empty;
  public string Estudio { get; set; } = string.Empty;
  public DateTime DataLancamento {get; set; }
  public string Classificacao { get; set; }
  public string Sinopse { get; set; }
  public string Elenco { get; set; }
  public IFormFile? Imagem { get; set; }
}

public class AtualizarFilmeDTO
{
    public string Titulo { get; set; } = string.Empty;
    public string Genero { get; set; } = string.Empty;
    public string Diretor { get; set; } = string.Empty;
    public string Estudio { get; set; } = string.Empty;
    public DateTime DataLancamento {get; set; }
    public int DuracaoMinutos { get; set; }
    public string Classificacao { get; set; }
    public string Sinopse { get; set; }
    public string Elenco { get; set; }
    public IFormFile Imagem { get; set; }
}