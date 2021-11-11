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
            string numeroCliente = Validaciones.ValidarCliente("Ingrese el número de cliente");
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

            //------------------------------------Opciones Principales -------------------------------------------
            int opcionSelec = Validaciones.ValidarOpcion("Ingrese lo que desea realizar: ", "1. Nueva solicitud de envío Nacional \n2. Envíos Internacionales \n3. Consultar Estado de envío \n4. Consultar Estado de cuenta corriente\n0.Salir", 0, 4);
            Console.ResetColor();
            switch (opcionSelec)
            {
                case 1:
                    {
                        var nuevoEnvioNacional =  EnvioNacional.Ingresar();
                        break;
                    }
                case 2:
                    {
                        var nuevoEnvioInternacional = EnvioInternacional.Ingresar();
                        break;
                    }
                case 3:
                    {
                        var nuevaConsultaEnvio = OrdenDeServicio.MostrarOrden();
                        Console.ReadLine();
                        break;
                    }
                case 4:
                    {
                        var nuevoEstadoDeCuenta = EstadoDeCuenta.ConsultarEstado(numeroCliente);
                        break;
                    }
                case 0:
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Ha salido del programa");
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
