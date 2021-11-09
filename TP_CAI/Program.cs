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
            Cliente clienteActivo = new Cliente();
            string numeroCliente = Validaciones.ValidarCliente("Ingrese el número de cliente");
            

            //Console.WriteLine("Ingrese el número de documento");
            //Validar

            //Validar combinación cliente + DNI
            clienteActivo.LeerMaestroCliente(numeroCliente);
            clienteActivo.MostrarClientesEncontrados();

            Console.ReadLine();

            // Console.Clear();

            Console.WriteLine("Ingrese lo que desea realizar: ");
            
            Console.WriteLine("1. Nueva solicitud de envío Nacional \n2.Envíos Internacionales \n3. Consultar Estado de envío \n4. Consultar Estado de cuenta corriente \n0. Salir");
            var ingreso = Console.ReadLine();
            //validar ingreso
            int opcionSelec = Validaciones.ValidarOpcion(ingreso);
            switch (opcionSelec)
            {
                case 1:
                    {
                        var nuevoEnvioNacional =  EnvioNacional.Ingresar();
                        break;
                    }
                case 2:
                    {

                        break;
                    }
                case 3:
                    {

                        break;
                    }
                case 4:
                    {

                        break;
                    }
                case 0:
                    {
                        Console.WriteLine("Gracias por utilizar nuestros servicios");
                        System.Environment.Exit(0);
                        break;

                    }
            }
            

            Console.ReadLine();
        }
    }
}
