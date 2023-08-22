using System.ComponentModel.DataAnnotations;

namespace NominaEmpleados.Models
{
    public class Nomina
    {
        [Key]
        public int Codigo  { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal PrecioHoras { get; set; }
        public int CantidadHoras { get; set; }
        public decimal MontoGanado { get; set; }
        public decimal Incentivos { get; set; }
        public decimal TotalGanado { get; set; }
        public decimal ISR { get; set; }
        public decimal Avances { get; set; }
        public decimal TotalDeducciones { get; set; }
        public decimal TotalRecibir { get; set; }
    }
}
