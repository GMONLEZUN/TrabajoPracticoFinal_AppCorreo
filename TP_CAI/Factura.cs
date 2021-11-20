using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class Factura
    {

        public string NumeroCliente { get; }
        public string NumeroFactura { get; }
        public string Estado { get; }
        public decimal Monto { get; }
        public string FechaFactura { get; }

        const string maestroFacturas = "MaestroFacturas.txt";

        public List<Factura> facturas = new List<Factura>();

        public Factura(string linea)
        {
            var datos = linea.Split('|');
            NumeroCliente = datos[0];
            NumeroFactura = datos[1];
            Estado = datos[2];
            Monto = decimal.Parse(datos[3]);
            FechaFactura = datos[4];
        }
        public Factura()
        {

        }

        public void LeerMaestroFacturas()
        {
            if (File.Exists(maestroFacturas))
            {
                using (var reader = new StreamReader(maestroFacturas))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unaFactura = new Factura(linea);
                        facturas.Add(unaFactura);
                    }
                }
            }
        }

        public void ListarFacturas(string codigoCliente)
        {
            string Msj = "";

            Console.WriteLine("Numero Factura \tFecha \t\tMonto \tEstado");
            for (int i = 0; i < facturas.Count; i++)
            {
                if (codigoCliente == facturas[i].NumeroCliente)
                {
                    Msj = $"{facturas[i].NumeroFactura} \t{facturas[i].FechaFactura} \t{facturas[i].Monto.ToString("n2")} \t{facturas[i].Estado}";
                    Console.WriteLine(Msj);
                }
            }
            if (string.IsNullOrEmpty(Msj))
            {
                Console.WriteLine("No se emitieron facturas");
            }
        }
        public void ListarSaldo(string codigoCliente)
        {

            decimal acumulador = 0;

            for (int i = 0; i < facturas.Count; i++)
            {
                if (codigoCliente == facturas[i].NumeroCliente && "Impaga" == facturas[i].Estado)
                {
                    acumulador += facturas[i].Monto;
                }
            }
            Console.WriteLine("------------------------------------------------------");
            Console.WriteLine("Posee un saldo deudor de: $" + acumulador.ToString("n2"));
            if (acumulador == 0)
            {
                Console.WriteLine("No se registra deuda.");
            }
        }
    }
}

