namespace backend.Models
{
    public enum tipoSala {VIP, Normal, Mista};
    public class Salas
    {
        public int Id { get; private set; }
        public int Numero { get; set; }
        public int Capacidade { get; set; }
        public tipoSala TipoSala { get; set; } = tipoSala.Normal;
    }
}
