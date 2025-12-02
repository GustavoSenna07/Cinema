namespace backend.Models
{
  public class Usuarios
  {
      public int Id { get; private set; }
      public required string Nome { get; set; } = string.Empty;
      public required string Email { get; set; } = string.Empty;
      public required string Senha { get; set; } = string.Empty;
      public required string CPF { get; set; } = string.Empty;
      public DateTime DataCadastro { get; set; } 
  }
}
