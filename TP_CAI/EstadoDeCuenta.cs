using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CAI
{
    class EstadoDeCuenta
    {
        public string TipoConsulta { get; set; }
        public string NumeroCliente { get; set; }
        public static EstadoDeCuenta ConsultarEstado(string numerocliente)
        {
            var nuevoEstadoDeCuenta = new EstadoDeCuenta();
            nuevoEstadoDeCuenta.NumeroCliente = numerocliente;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Consulta de estado de cuenta corriente.");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione la opción que desea realizar", "1. Consultar facturas \n2. Consultar órdenes pendientes de facturación", 1, 2);
                Console.WriteLine("Seleccione la opción que desea realiar \n1- Consultar facturas \n2- Consultar órdenes pendientes de facturación ");
                Console.ResetColor();

                string tipoConsulta = "";

                if (opcionSelec == 1)
                {
                    tipoConsulta = "Consultar facturas";
                }
                if (opcionSelec == 2)
                {
                    tipoConsulta = "Consultar órdenes pendientes de facturación";
                }
                nuevoEstadoDeCuenta.TipoConsulta = tipoConsulta;
                break;
            }

            //------------------Consultar facturas--------------------------------------------------------------
            if (nuevoEstadoDeCuenta.TipoConsulta == "Consultar facturas")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Factura F = new Factura();
                F.LeerMaestroFacturas();
                F.ListarFacturas(nuevoEstadoDeCuenta.NumeroCliente);
                F.ListarSaldo(nuevoEstadoDeCuenta.NumeroCliente);
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.ResetColor();
                Console.ReadLine();
            }

            //------------------Consultar ordenes sin facturas ( del mes en curso) --------------------------------------------------------------
            if (nuevoEstadoDeCuenta.TipoConsulta == "Consultar órdenes pendientes de facturación")
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                OrdenDeServicio O = new OrdenDeServicio();
                O.LeerMaestroOrdenes();
                O.ListarOrdenesPendientesFacturacion(nuevoEstadoDeCuenta.NumeroCliente);
                Console.ResetColor();
                Console.WriteLine("Gracias por utilizar nuestros servicios.");
                Console.ReadLine();
            }

            return nuevoEstadoDeCuenta;
        }
    }

}

