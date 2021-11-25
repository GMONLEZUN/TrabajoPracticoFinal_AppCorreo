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
        static public string ValidarDNI(string mensaje)
        {
            int dniNumerico;
            string dni;

            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ResetColor();
                dni = Console.ReadLine();

                bool verificarQueSeaNumero = int.TryParse(dni, out dniNumerico);

                if (dni.Length > 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número de DNI no puede poseer más de 8 dígitos");
                    Console.ResetColor();
                    continue;
                }
                if (dni.Length < 8)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El número de DNI no puede poseer menos de 8 dígitos");
                    Console.ResetColor();
                    continue;
                }
                //validar que sea solo número
                if (!verificarQueSeaNumero)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Los carácteres ingresados no corresponden a carácteres numéricos.");
                    Console.ResetColor();

                    continue;
                }
                bool existeBarra = false;
                char[] ingresoArray = dni.ToArray();
                foreach (var item in ingresoArray)
                {
                    if (item == '|')
                    {
                        existeBarra = true;
                    }
                }
                if (existeBarra)
                {
                    Console.WriteLine("No se permite el ingreso del caracter |");
                    continue;
                }

                break;
            } while (true);

            return dni;
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ingreso inválido, la opción no puede ser menor a {OpcMin}");
                    Console.ResetColor();
                    continue;
                }
                if (opcion > OpcMax)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ingreso inválido, la opción no puede ser mayor a {OpcMax}");
                    Console.ResetColor();
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
        static public string ValidarBarraEnString(string mensaje)
        {

            string ingreso;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ResetColor();
                ingreso = Console.ReadLine();
                bool existeBarra = false;
                char[] ingresoArray = ingreso.ToArray();
                foreach (var item in ingresoArray)
                {
                    if (item == '|')
                    {
                        existeBarra = true;
                    }
                }
                if (existeBarra)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se permite el ingreso del caracter |");
                    Console.ResetColor();
                    continue;
                }
                if (ingreso.Length < 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El ingreso debe ser mayor a 4 caracteres");
                    Console.ResetColor();
                    continue;
                }
                if (int.TryParse(ingreso, out int ingresoInt))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El ingreso no puede ser únicamente numérico");
                    Console.ResetColor();
                    continue;
                }
                break;
            } while (true);
            return ingreso;
        }

        static public int ValidarBarraEnInt(string mensaje, string variable, int Min, int Max)
        {
            int salida;
            do
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(mensaje);
                Console.ResetColor();
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out salida);
                if (!ingresoCorrecto)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ingreso inválido, intente nuevamente");
                    Console.ResetColor();
                    continue;
                }
                if (salida.ToString().Length < Min)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ingreso inválido, {variable} no puede ser menor a {Min} caracteres");
                    Console.ResetColor();
                    continue;
                }
                if (salida.ToString().Length > Max)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Ingreso inválido, {variable} no puede ser menor a {Max} caracteres");
                    Console.ResetColor();
                    continue;
                }

                bool existeBarra = false;
                char[] ingresoArray = ingreso.ToArray();
                foreach (var item in ingresoArray)
                {
                    if (item == '|')
                    {
                        existeBarra = true;
                    }
                }
                if (existeBarra)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("No se permite el ingreso del caracter |");
                    Console.ResetColor();
                    continue;
                }
                break;
            } while (true);
            return salida;
        }
    }
}
