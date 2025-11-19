using System.Dynamic;

namespace backend.Models;

public class Filme
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Genero { get; set; }
    public string Diretor { get; set; }
    public string Estudio {get; set;}
    public DateTime Data_Lancamento {get; set; }
    public int DuracaoMin { get; set; }
    public string Classificacao { get; set; }
    public string Sinopse { get; set; }
    public string Capa_Filme { get; set; }
    public string Elenco { get; set; }
}
