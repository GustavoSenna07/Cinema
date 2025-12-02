namespace backend.Models
{
    public class Filme
    {
        public int Id { get; private set; }
        public required string Titulo { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public string Diretor { get; set; } = string.Empty;
        public string Estudio { get; set; } = string.Empty;
        public DateTime DataLancamento {get; set; }
        public int DuracaoMinutos { get; set; }
        public string Classificacao { get; set; }
        public string Sinopse { get; set; } = string.Empty;
        public string ImagemURL { get; set; } = string.Empty;
        public string Elenco { get; set; } = string.Empty;
    }
}
