namespace backend.DTOs;
using System.ComponentModel.DataAnnotations;
using backend.Models;
using System.Text.Json.Serialization;


public class UsuarioResponseDTO
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string CPF { get; set; } = string.Empty;
    public DateTime DataCadastro {get; set; }
    public UsuarioResponseDTO(Usuarios u) {
      Id = u.Id;
      Nome = u.Nome;
      Email = u.Email;
      CPF = u.CPF;
      DataCadastro = u.DataCadastro;
    }
}

public class CriarUsuarioDTO
{
  [Required(ErrorMessage = "Nome do Usuario Necessario")]
  public string Nome { get; set; } = string.Empty;

  [Required(ErrorMessage = "Email do Usuario Necessario")]
  public string Email { get; set; } = string.Empty;

  [Required(ErrorMessage = "Senha do Usuario Necessario")]
  public string Senha { get; set; } = string.Empty;

  [Required(ErrorMessage = "CPF do Usuario Necessario")]
  public string CPF { get; set; } = string.Empty;
}

public class AtualizarUsuarioDTO
{
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Nome { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? Email { get; set; }

    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string? CPF { get; set; }
}