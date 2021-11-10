using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CAI
{
    class Validaciones
    {
        
        static public string ValidarCliente(string mensaje)
        {
            string numeroCliente;
            do
            {
                Console.WriteLine(mensaje);
                numeroCliente = Console.ReadLine();
                if (numeroCliente.Length > 3)
                {
                    Console.WriteLine("El número de cliente no puede poseer más de 3 dígitos");
                    continue;
                }
                if (numeroCliente.Length < 3)
                {
                    Console.WriteLine("El número de cliente no puede poseer menos de 3 dígitos");
                    continue;
                }
                break;
            } while (true);

            return numeroCliente;
        }
        //Rehacer validar opción que permita el ingreso de diferentes tipos de opciones con min y max**************
        static public int ValidarOpcion(string ingreso)
        {
            bool ingresoCorrecto = int.TryParse(ingreso, out int opcion);
            do
            {
                if (!ingresoCorrecto)
                {
                    Console.WriteLine("Ingreso inválido, intente nuevamente");
                    continue;
                }
                if (opcion < 0)
                {
                    Console.WriteLine("Ingreso inválido, la opción no puede ser menor a 0");
                    continue;
                }
                if (opcion > 4)
                {
                    Console.WriteLine("Ingreso inválido, la opción no puede ser mayor a 4");
                    continue;
                }
                break;
            } while (true);
            return opcion;
        }
    }
}
