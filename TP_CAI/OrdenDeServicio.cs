using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class OrdenDeServicio
    {
        public string NumeroSeguimiento { get; set; }
        public int CodigoProvincia { get; set; }
        public string Provincia { get; set; }
        public int CodigoLocalidad { get; set; }
        public string Localidad { get; set; }
        public int CodigoSucursal { get; set; }
        public string DireccionEntrega { get; set; }
        public string DireccionOrigen { get; set; }
        public string NombreDestinatario { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Importe { get; set; }
        public string EstadoOrden { get; set; }
        public int CodigoProvinciaEntrega { get; set; }
        public string ProvinciaEntrega { get; set; }
        public int CodigoLocalidadEntrega { get; set; }
        public string LocalidadEntrega { get; set; }
        public int CodigoSucursalEntrega { get; set; }
        public string PesoEncomienda { get; set; }
        public string TipoEnvio { get; set; }
        public int CodigoRegion { get; set; }
        public string Region { get; set; }
        public int CodigoRegionEntrega { get; set; }
        public string RegionEntrega { get; set; }
        public string Recepcion { get; set; }
        public string Entrega { get; set; }
        public string NumeroCliente { get; set; }
        public string PaisEntrega { get; set; }

        const string maestroOrdenDeServicio = "maestroOrdenDeServicio.txt";

        public List<OrdenDeServicio> ordenes = new List<OrdenDeServicio>();

        public OrdenDeServicio(string linea)
        {
            var datos = linea.Split('|');
            NumeroSeguimiento = datos[0];
            NumeroCliente = datos[1];
            PaisEntrega = datos[2];
            RegionEntrega = datos[3];
            ProvinciaEntrega = datos[4];
            LocalidadEntrega = datos[5];
            DireccionEntrega = datos[6];
            NombreDestinatario = datos[7];
            FechaOrden = DateTime.Parse(datos[8]);
            Importe = decimal.Parse(datos[9]);
            EstadoOrden = datos[10];
            Region = datos[11];
            Provincia = datos[12];
            Localidad = datos[13];
            DireccionOrigen = datos[14];
            Recepcion = datos[15];
            Entrega = datos[16];
            PesoEncomienda = datos[17];
            TipoEnvio = datos[18];
         }
        public OrdenDeServicio()
        {

        }

        public static OrdenDeServicio MostrarOrden()
        {
            var nuevaODSmostrar = new OrdenDeServicio();

            nuevaODSmostrar.LeerMaestroOrdenes();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Ingrese número de orden de seguimiento");
            Console.ResetColor();
            var numeroDeOrden = Console.ReadLine();
            nuevaODSmostrar.VerOrdenDeServicio(numeroDeOrden);
            Console.WriteLine("Gracias por utilizar nuestros servicios.");
            Console.ReadLine();
            return nuevaODSmostrar;
        }

        public void LeerMaestroOrdenes()
        {
            if (File.Exists(maestroOrdenDeServicio))
            {
                using (var reader = new StreamReader(maestroOrdenDeServicio))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unaOrden = new OrdenDeServicio(linea);
                        ordenes.Add(unaOrden);
                    }
                }
            }
        }

        public void VerOrdenDeServicio(string ordenDeServicio)
        {

            Dictionary<string, string> auxiliarOrden = new Dictionary<string, string>();
            bool encontrado = false;
            foreach (var orden in ordenes)
            {
                if (orden.NumeroSeguimiento == ordenDeServicio)
                {
                    encontrado = auxiliarOrden.ContainsKey(orden.NumeroSeguimiento);
                    if (!encontrado)
                    {
                        auxiliarOrden.Add(orden.NumeroSeguimiento, orden.EstadoOrden);
                    }
                }
            }
            if (!auxiliarOrden.ContainsKey(ordenDeServicio))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("El número ingresado no se encuentra en nuestra base de datos");
                Console.ResetColor();
                Console.ReadLine();
                System.Environment.Exit(0);
            }

            foreach (var item in auxiliarOrden)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                Console.ResetColor();
            }
        }

        public void AgregarOrdenDeServicio(OrdenDeServicio nuevaOrden)
        {
            ordenes.Add(nuevaOrden);
        }


        public void ListarOrdenesPendientesFacturacion(string codigoCliente)
        {
            string Msj = "";
            
            Console.WriteLine("Numero Factura \t\tFecha \t\tMonto \t\tEstado");
            for (int i = 0; i < ordenes.Count; i++)
            {
                if (codigoCliente == ordenes[i].NumeroCliente && DateTime.Now.Month == ordenes[i].FechaOrden.Month)
                {
                    
                    Msj = $"{ordenes[i].NumeroSeguimiento} \t{ordenes[i].FechaOrden.ToShortDateString()} \t{ordenes[i].Importe.ToString("n2")} \t{ordenes[i].EstadoOrden}";
                    Console.WriteLine(Msj);
                }
            }
            if (string.IsNullOrEmpty(Msj))
            {
                Console.WriteLine("No posee órdenes pendientes de facturación");
            }

        }

        public void GuardarOrdenDeServicio()
        {

            StreamWriter SW = new StreamWriter(maestroOrdenDeServicio);

            foreach (OrdenDeServicio O in ordenes)
            {
                SW.WriteLine(O.NumeroSeguimiento + "|" + O.NumeroCliente + "|" + O.PaisEntrega + "|" + O.RegionEntrega + "|" + O.ProvinciaEntrega + "|"
                    + O.LocalidadEntrega + "|" + O.DireccionEntrega + "|" + O.NombreDestinatario + "|" + O.FechaOrden + "|" + O.Importe + "|"
                    + O.EstadoOrden + "|" + O.Region + "|" + O.Provincia + "|" + O.Localidad + "|"
                    + O.DireccionOrigen + "|" + O.Recepcion + "|" + O.Entrega + "|" + O.PesoEncomienda + "|" + O.TipoEnvio);
            }

            SW.Close();
            Console.WriteLine("Se guardó correctamente la Orden de Servicio.");
        }

    }
}
