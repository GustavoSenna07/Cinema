namespace backend.Models
{
    public class Salas
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public string TipoSala { get; set; } = string.Empty;
    }
}
