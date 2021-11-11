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
        public int CodigoLocalidad { get; set; }
        public int CodigoSucursal { get; set; }
        public string DomicilioDestinatario { get; set; }
        public string NombreDestinatario { get; set; }
        public DateTime FechaOrden { get; set; }
        public float Importe { get; set; }
        public string EstadoOrden { get; set; }
        public int CodigoProvinciaEntrega { get; set; }
        public int CodigoLocalidadEntrega { get; set; }
        public int CodigoSucursalEntrega { get; set; }
        public string PesoEncomienda { get; set; }
        public string TipoEnvio { get; set; }
        public int CodigoRegion { get; set; }
        public int CodigoRegionEntrega { get; set; }
        public string Recepcion { get; set; }
        public string Entrega { get; set; }
        public string NumeroCliente { get; set; }

        const string maestroOrdenDeServicio = "maestroOrdenDeServicio.txt";

        public List<OrdenDeServicio> ordenes = new List<OrdenDeServicio>();

        public OrdenDeServicio(string linea)
        {
            var datos = linea.Split('|');
            NumeroSeguimiento = datos[0];
            CodigoRegionEntrega = int.Parse(datos[1]);
            CodigoProvinciaEntrega = int.Parse(datos[2]);
            CodigoLocalidadEntrega = int.Parse(datos[3]);
            CodigoSucursalEntrega = int.Parse(datos[4]);
            DomicilioDestinatario = datos[5];
            NombreDestinatario = datos[6];
            FechaOrden = DateTime.Parse(datos[7]);
            Importe = float.Parse(datos[8]);
            EstadoOrden = datos[9];
            CodigoRegion = int.Parse(datos[10]);
            CodigoProvincia = int.Parse(datos[11]);
            CodigoLocalidad = int.Parse(datos[12]);
            CodigoSucursal = int.Parse(datos[13]);
            Recepcion = datos[14];
            Entrega = datos[15];
            PesoEncomienda = datos[16];
            TipoEnvio = datos[17];
            NumeroCliente = datos[18];
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

            foreach (var item in auxiliarOrden)
            {

                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");

            }
        }
        public void AgregarOrdendeServicio(int codRegEnt, int codProvEnt, int codLocEnt, int codSucEnt, string domDest, string nomDest,
            int codReg, int codProv, int codLoc, int codSuc, string recepcion, string entrega, string pesoEnc, string tipoEnv)

        {
            //var unaorden = new OrdenDeServicio();
            string numeroSeguimiento = Convert.ToString(4448800000000 + AutoEnumerar());
            float salidaMonto = 0;
            string Errores = "";

            if (!string.IsNullOrEmpty(Errores))
            {
                Console.WriteLine(Errores, "Error");
            }
            else
            {
                OrdenDeServicio O = new OrdenDeServicio();
                O.NumeroSeguimiento = numeroSeguimiento;
                O.CodigoProvincia = codProv;
                O.CodigoLocalidad = codLoc;
                O.CodigoSucursal = codSuc;
                O.CodigoProvinciaEntrega = codProvEnt;
                O.CodigoLocalidadEntrega = codLocEnt;
                O.CodigoSucursalEntrega = codSucEnt;
                O.DomicilioDestinatario = domDest;
                O.NombreDestinatario = nomDest;
                O.PesoEncomienda = pesoEnc;
                O.TipoEnvio = tipoEnv;
                O.CodigoRegion = codReg;
                O.CodigoRegionEntrega = codRegEnt;
                O.Recepcion = recepcion;
                O.Entrega = entrega;

                salidaMonto = O.CalcularTarifa(O.CodigoLocalidadEntrega, O.CodigoProvinciaEntrega, O.CodigoLocalidadEntrega, O.CodigoSucursalEntrega,
                    O.CodigoLocalidad, O.CodigoProvincia, O.CodigoLocalidad, O.CodigoSucursal,
                    O.Recepcion, O.Entrega, O.PesoEncomienda, O.TipoEnvio);

                O.Importe = salidaMonto;
                O.FechaOrden = DateTime.Now.Date; // -->> que no de la hora
                O.EstadoOrden = "Iniciada";

                ordenes.Add(O);

                Console.WriteLine("Se generó correctamente la Orden de Servicio.");
            }
        }

        private int AutoEnumerar()
        {
            Random R = new Random();
            return R.Next(500000, 999999);
        }

        private float CalcularTarifa(int codRegEnt, int codProvEnt, int codLocEnt, int codSucEnt,
            int codReg, int codProv, int codLoc, int codSuc, string recepcion, string entrega, string pesoEnc, string tipoEnv)
        {

            float acumulador = 0;

            if (pesoEnc == "Correspondencia hasta 500g")
            {
                if (codReg != codRegEnt)
                {
                    acumulador += 600; //El envío es interregional
                }
                if (codProv != codProvEnt)
                {
                    acumulador += 500; //El envío es regional
                }
                if (codLoc != codLocEnt)
                {
                    acumulador += 400; //El envío es provincial
                }
                else
                {
                    acumulador += 300; //El envío es local
                }
            }
            if (pesoEnc == "Bultos hasta 10Kg.")
            {
                if (codReg != codRegEnt)
                {
                    acumulador += 1200; //El envío es interregional
                }
                if (codProv != codProvEnt)
                {
                    acumulador += 1000; //El envío es regional
                }
                if (codLoc != codLocEnt)
                {
                    acumulador += 800; //El envío es provincial
                }
                else
                {
                    acumulador += 600; //El envío es local
                }
            }

            if (pesoEnc == "Bultos hasta 20Kg.")
            {
                if (codReg != codRegEnt)
                {
                    acumulador += 1800; //El envío es interregional
                }
                if (codProv != codProvEnt)
                {
                    acumulador += 1500; //El envío es regional
                }
                if (codLoc != codLocEnt)
                {
                    acumulador += 1200; //El envío es provincial
                }
                else
                {
                    acumulador += 900; //El envío es local
                }
            }
            if (pesoEnc == "Bultos hasta 30Kg.")
            {
                if (codReg != codRegEnt)
                {
                    acumulador += 2400; //El envío es interregional
                }
                if (codProv != codProvEnt)
                {
                    acumulador += 2000; //El envío es regional
                }
                if (codLoc != codLocEnt)
                {
                    acumulador += 1600; //El envío es provincial
                }
                else
                {
                    acumulador += 1200; //El envío es local
                }
            }
            if (tipoEnv == "Urgente")
            {
                acumulador += acumulador; // URGENTE
            }
            if (recepcion == "Retiro en puerta")
            {
                acumulador += 500; // Adicional en puerta
            }
            if (entrega == "Retiro en puerta")
            {
                acumulador += 500; // Adicional en puerta
            }

            return acumulador;


        }

        public void ListarOrdenesPendientesFacturacion(string codigoCliente)
        {
            string Msj = "";

            for (int i = 0; i < ordenes.Count; i++)
            {
                if (codigoCliente == ordenes[i].NumeroCliente && DateTime.Now.Month == ordenes[i].FechaOrden.Month)
                {
                    Console.WriteLine("Numero Factura \tFecha \t\tMonto \tEstado");
                    Msj = $"{ordenes[i].NumeroSeguimiento} \t{ordenes[i].FechaOrden} \t{ordenes[i].Importe} \t{ordenes[i].EstadoOrden}";
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
                SW.WriteLine(O.NumeroSeguimiento + "|" + O.CodigoRegionEntrega + "|" + O.CodigoProvinciaEntrega + "|" + O.CodigoLocalidadEntrega + "|" + O.CodigoSucursalEntrega + "|"
                    + O.DomicilioDestinatario + "|" + O.NombreDestinatario + "|" + O.FechaOrden + "|" + O.Importe + "|" + O.EstadoOrden + "|"
                    + O.CodigoRegion + "|" + O.CodigoProvincia + "|" + O.CodigoLocalidad + "|" + O.CodigoSucursal + "|"
                    + O.Recepcion + "|" + O.Entrega + "|" + O.PesoEncomienda + "|" + O.TipoEnvio);
            }

            SW.Close();
            Console.WriteLine("Se guardo correctamente la Orden de Servicio.");
        }

    }
}
