using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Operaciones" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Operaciones.svc or Operaciones.svc.cs at the Solution Explorer and start debugging.
    public class Operaciones : IOperaciones
    {

        public int Suma(int numero1, int numero2)
        {
            int resultadoSuma = numero1 + numero2;

            return resultadoSuma ;
        } 

        public int Resta(int numero1,int numero2)
        {
            int ResultadoResta = numero1 - numero2;

            return ResultadoResta;
        }
        public int Multiplicacion(int numero1, int numero2)
        {
            int ResultadoMultiplicacion = numero1*numero2;

            return ResultadoMultiplicacion;
        }
        public double Division(double numero1, double numero2)
        {

            double ResultadoDivision = numero1 / numero2;

            return ResultadoDivision;
        }

    }
}
