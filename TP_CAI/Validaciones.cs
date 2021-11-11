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
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ResetColor();
                numeroCliente = Console.ReadLine();
                char[] numeroClienteaArray = numeroCliente.ToArray();
                bool encontroNoDigito = false;
                foreach (var item in numeroClienteaArray)
                {
                    if (!char.IsDigit(item) && !encontroNoDigito)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("El número de cliente no acepta otro caracter que no sea número");
                        Console.ResetColor();
                        encontroNoDigito = true;
                    }

                }
                if (numeroCliente.Length > 6 && !encontroNoDigito)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número de cliente no puede poseer más de 6 dígitos");
                    Console.ResetColor();
                    continue;
                }
                if (numeroCliente.Length < 6 && !encontroNoDigito)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número de cliente no puede poseer menos de 6 dígitos");
                    Console.ResetColor();
                    continue;
                }
                if (encontroNoDigito)
                {
                    continue;
                }
                break;
            } while (true);

            return numeroCliente;
        }

        static public int ValidarOpcion(string mensaje, string mensajeOpciones, int OpcMin, int OpcMax)
        {
            int opcion;
            do
            {

                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mensajeOpciones);
                Console.ResetColor();
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                if (!ingresoCorrecto)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingreso inválido, intente nuevamente");
                    Console.ResetColor();
                    continue;
                }
                if (opcion < OpcMin)
                {
                    Console.WriteLine($"Ingreso inválido, la opción no puede ser menor a {OpcMin}");
                    continue;
                }
                if (opcion > OpcMax)
                {
                    Console.WriteLine($"Ingreso inválido, la opción no puede ser mayor a {OpcMax}");
                    continue;
                }
                break;
            } while (true);
            return opcion;
        }

        static public int ValidarRegion(string mensaje, string mensajeOpciones)
        {
            int opcion;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(mensajeOpciones);
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                if (!ingresoCorrecto)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingreso inválido, intente nuevamente");
                    Console.ResetColor();
                    continue;
                }
                if (!(opcion == 10 || opcion == 20 || opcion == 30 || opcion == 40))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("La opción ingresada no es correcta, intente nuevamente");
                    Console.ResetColor();
                    continue;
                }
                break;
            } while (true);
            return opcion;
        }
    }
}
