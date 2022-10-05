using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class Conexion
    {

        public static String Get()
        {
            string conexion = ConfigurationManager.ConnectionStrings["KGarciaProgramacionNCapas"].ConnectionString;

            return conexion;

        }
    }
}
