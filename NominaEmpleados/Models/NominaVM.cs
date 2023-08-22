namespace NominaEmpleados.Models
{
    public class NominaVM
    {
        public Nomina? oNomina { get; set; }
        public List<Nomina>? Listado { get; set; } = new List<Nomina>();

        public bool Error { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
