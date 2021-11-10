using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CAI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            string numeroCliente = Validaciones.ValidarCliente("Ingrese el número de cliente");
            Console.ResetColor();
            Cliente clienteActivo = new Cliente();

            //Console.WriteLine("Ingrese el número de documento");
            //Validar
            //Validar combinación cliente + DNI

            clienteActivo.LeerMaestroCliente(numeroCliente);
            clienteActivo.MostrarClientesEncontrados();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Presione Enter para continuar");
            Console.ResetColor();
            Console.ReadLine();
            Console.Clear();

            //---------Nueva Pantalla-----------------------------------------------------------------------------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Ingrese lo que desea realizar: ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1. Nueva solicitud de envío Nacional \n2. Envíos Internacionales \n3. Consultar Estado de envío \n4. Consultar Estado de cuenta corriente");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0. Salir");
            Console.ResetColor();
            var ingreso = Console.ReadLine();
            //Crear validación para opciones 1 a 4*************************************
            int opcionSelec = Validaciones.ValidarOpcion(ingreso); //cambiar
            switch (opcionSelec)
            {
                case 1:
                    {
                        var nuevoEnvioNacional =  EnvioNacional.Ingresar();
                        break;
                    }
                case 2:
                    {
                        //caso envíos internacionales -- parecido a Nacional
                        break;
                    }
                case 3:
                    {
                        //caso de Consulta de Estado de envío
                        break;
                    }
                case 4:
                    {
                        //caso consulta Estado de Cuenta ------ Lo está viendo Noelia 
                        break;
                    }
                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Gracias por utilizar nuestros servicios");
                        Console.ResetColor();
                        Console.ReadLine();
                        System.Environment.Exit(0);
                        break;

                    }
            }
            
            
        }
    }
}
