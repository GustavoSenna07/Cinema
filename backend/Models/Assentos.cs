namespace backend.Models
{
    public class Assentos
    {
        public int Id { get; set; }
        public int SalaId { get; set; }
        public string Fileira { get; set; } = string.Empty;
        public string Coluna { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
    }
}
