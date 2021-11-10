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
        public string NumeroSeguimiento { get; }
        public int CodigoProvincia { get; }
        public int CodigoLocalidad { get; }
        public int CodigoSucursal { get; }
        public string DomicilioDestinatario { get; }
        public string NombreDestinatario { get; }
        public string FechaOrden { get; }
        public int Importe { get; }
        public string EstadoOrden { get; }

        const string maestroOrdenDeServicio = "MaestroOrdenDeServicio.txt";

        public static List<OrdenDeServicio> ordenes = new List<OrdenDeServicio>();

        public OrdenDeServicio(string linea)
        {
            var datos = linea.Split('|');
            NumeroSeguimiento = datos[0];
            CodigoProvincia = int.Parse(datos[1]);
            CodigoLocalidad = int.Parse(datos[2]);
            CodigoSucursal = int.Parse(datos[3]);
            DomicilioDestinatario = datos[4];
            NombreDestinatario = datos[5];
            FechaOrden = datos[6];
            Importe = int.Parse(datos[7]);
            EstadoOrden = datos[8];

        }
        public OrdenDeServicio()
        {

        }

        public static OrdenDeServicio MostrarOrden()
        {
            var nuevaODSmostrar = new OrdenDeServicio();

            nuevaODSmostrar.LeerMaestroOrdenes();
            Console.WriteLine("Ingrese número de orden de seguimiento");
            var numeroDeOrden = Console.ReadLine();
            nuevaODSmostrar.VerOrdenDeServicio(numeroDeOrden);
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
            
            foreach (var item in auxiliarOrden)
            {
                
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                
            }
        }
    }
}
