using NominaEmpleados.Models;
using System.Threading;

namespace NominaEmpleados.Servicios
{
    public class NominaSrv
    {
        public Nomina CalcularNomina(Nomina oNomina)
        {
            const decimal minIncentivo = 15000;
            const decimal avances = 5000;

            // 1. El Monto Ganado = al precio de las horas por el total de las horas trabajadas.
            oNomina.MontoGanado = oNomina.PrecioHoras * oNomina.CantidadHoras;

            // 2. Calculo de Incentivos = si el monto ganado es menor de 15000 se le aplicara
            // un incentivo de 5 %, y si es mayor o igual se le aplicara el 15 %.
            if (oNomina.MontoGanado < minIncentivo)
            {
                oNomina.Incentivos = oNomina.MontoGanado * Convert.ToDecimal(0.05);

            }
            else if (oNomina.MontoGanado >= minIncentivo)
            {
                oNomina.Incentivos = oNomina.MontoGanado * Convert.ToDecimal(0.15);
            }

            // 3. Total, Ganado será igual al Monto más los Incentivos(sumarlos).
            oNomina.TotalGanado = oNomina.MontoGanado + oNomina.Incentivos;

            //4.Calculo de ISR, si el monto ganado es menor o igual a 10000, el ISR es 0, si
            //    el monto ganado es mayor de 10000, y menor o igual de 15000, ISR es 0.4 %, 
            //    si el monto ganado es mayor de 15000, el ISR es de 1.5 %.
            if (oNomina.TotalGanado > 10000 && oNomina.TotalGanado <= 15000)
            {
                oNomina.ISR = 0;
            }
            else if (oNomina.TotalGanado > 10000 && oNomina.TotalGanado <= 15000)
            {
                oNomina.ISR = oNomina.TotalGanado * Convert.ToDecimal(0.4 / 100);
            }
            else if (oNomina.TotalGanado > 15000)
            {
                oNomina.ISR = oNomina.TotalGanado * Convert.ToDecimal(1.5 / 100);
            }

            //5.Calculo de la columna AVANCES, Los profesores con el código 1,2 y 7
            //    tomaron 5000 pesos de avance darle el valor fijo.
            if (oNomina.Codigo == 1 || oNomina.Codigo == 2 || oNomina.Codigo == 7)
            {
                oNomina.Avances = avances;
            }

            //6.Calculo del total DEDUCIONES, se tomará sumando el avance más el ISR.
            oNomina.TotalDeducciones = oNomina.ISR + oNomina.Avances;            //7.Total, a recibir se calculará Total ganado menos Total Deducciones.
            oNomina.TotalRecibir = oNomina.TotalGanado - oNomina.TotalDeducciones;            oNomina.TotalRecibir = Math.Round(oNomina.TotalRecibir);
            return oNomina;
        }

        public bool CheckIfNull(Nomina oNomina)
        {
            if (oNomina == null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public NominaVM LimpiarObjetoNomina(NominaVM Nomina)
        {
            if (Nomina.oNomina != null)
            {
                Nomina.oNomina.Codigo = 0;
                Nomina.oNomina.Nombre = string.Empty;
                Nomina.oNomina.Apellido = string.Empty;
                Nomina.oNomina.PrecioHoras = 0;
                Nomina.oNomina.CantidadHoras = 0;
                Nomina.oNomina.MontoGanado = 0;
                Nomina.oNomina.Incentivos = 0;
                Nomina.oNomina.TotalGanado = 0;
                Nomina.oNomina.ISR = 0;
                Nomina.oNomina.Avances = 0;
                Nomina.oNomina.TotalDeducciones = 0;
                Nomina.oNomina.TotalRecibir = 0;
            }

            Nomina.Error = false;
            Nomina.ErrorMessage = string.Empty;

            return Nomina;
        }
    }
}
