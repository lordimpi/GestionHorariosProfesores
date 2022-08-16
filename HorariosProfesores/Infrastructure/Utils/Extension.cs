using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Utils
{
    public static class Extension
    {
        public static bool ValidarMesesPeriodo(DateTime fechaInicio, DateTime fechaFin)
        {

            if ((fechaFin.Year - fechaInicio.Year) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
