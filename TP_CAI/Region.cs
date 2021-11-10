using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class Region
    {


        public int CodigoRegion { get; private set; }
        public string NombreRegion { get; private set; }
        public int CodigoProvincia { get; private set; }
        public string NombreProvincia { get; private set; }
        public int CodigoLocalidad { get; private set; }
        public string NombreLocalidad { get; private set; }
        public int CodigoSucursal { get; private set; }
        public string NombreSucursal { get; private set; }
        public string TitularSucursal { get; private set; }
        public string TipoRecepcion { get; private set; }
        public string RetiroDireccion { get; private set; }
        public int RetiroCodigoPostal { get; private set; }

        const string maestroRegiones = "MaestroRegiones.txt";

        public List<Region> regiones = new List<Region>();

        public Region(string linea)
        {
            var datos = linea.Split('|');
            CodigoRegion = int.Parse(datos[0]);
            NombreRegion = datos[1];
            CodigoProvincia = int.Parse(datos[2]);
            NombreProvincia = datos[3];
            CodigoLocalidad = int.Parse(datos[4]);
            NombreLocalidad = datos[5];
            CodigoSucursal = int.Parse(datos[6]);
            NombreSucursal = datos[7];
            TitularSucursal = datos[8];
        }
        public Region()
        {

        }


        public static Region SeleccionRecepcion()
        {
            var nuevaSeleccionRecepcion = new Region();


            while (true)
            {

                string provSelecc = "";
                string locSelecc = "";
                string sucSelecc = "";
                Console.WriteLine("1-Retiro en puerta\n2-Presentación en sucursal");
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out int opcion);
                if (opcion == 1)
                {
                    nuevaSeleccionRecepcion.TipoRecepcion = "Retiro en puerta";

                    Console.WriteLine("Seleccione la región donde se realizará el retiro del envío: ");
                    Console.WriteLine("10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

                    var ingresoCodRegion = Console.ReadLine();
                    var ingresoCorr = int.TryParse(ingresoCodRegion, out int codRegion);

                    nuevaSeleccionRecepcion.LeerMaestroRegiones();

                    Console.WriteLine("Seleccione la provincia donde se realizará el retiro del envío");

                    nuevaSeleccionRecepcion.VerProvinciaPorRegion(codRegion);
                    var ingresoCodProvincia = Console.ReadLine();
                    var ingresoCorr2 = int.TryParse(ingresoCodProvincia, out int codProvincia);
                    provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionRecepcion.NombreProvincia = provSelecc;
                    

                    Console.WriteLine("Seleccione la localidad donde se realizará el retiro del envío");
                    nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
                    var ingresoCodLocalidad = Console.ReadLine();
                    var ingresoCorr3 = int.TryParse(ingresoCodLocalidad, out int codLocalidad);
                    locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;

                    Console.WriteLine("Ingrese la dirección exacta donde se realizara el retiro del envío");
                    var direccion = Console.ReadLine();
                    Console.WriteLine("Ingrese el código postal de la dirección ingresada");
                    var ingresoCodPostal = Console.ReadLine();
                    bool ingresoCorr4 = int.TryParse(ingresoCodPostal, out int CodPostal);
                    nuevaSeleccionRecepcion.RetiroDireccion = direccion;
                    nuevaSeleccionRecepcion.RetiroCodigoPostal = CodPostal;

                }
                if (opcion == 2)
                {
                    nuevaSeleccionRecepcion.TipoRecepcion = "Presentacion en sucursal";
                    Console.WriteLine("Seleccione la región donde se realizará el retiro del envío: ");
                    Console.WriteLine("10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");
                    var ingresoCodRegion = Console.ReadLine();
                    var ingresoCorr = int.TryParse(ingresoCodRegion, out int codRegion);

                    nuevaSeleccionRecepcion.LeerMaestroRegiones();

                    Console.WriteLine("Seleccione la provincia donde se realizará la presentación del envío");

                    nuevaSeleccionRecepcion.VerProvinciaPorRegion(codRegion);
                    var ingresoCodProvincia = Console.ReadLine();
                    var ingresoCorr2 = int.TryParse(ingresoCodProvincia, out int codProvincia);
                    provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionRecepcion.NombreProvincia = provSelecc;

                    Console.WriteLine("Seleccione la localidad donde se realizará la presentación del envío");
                    nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
                    var ingresoCodLocalidad = Console.ReadLine();
                    var ingresoCorr3 = int.TryParse(ingresoCodLocalidad, out int codLocalidad);
                    locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;

                    Console.WriteLine("Seleccione la sucursal donde se realizará la presentación del envío");
                    nuevaSeleccionRecepcion.VerSucursalPorLocalidad(codLocalidad);
                    var ingresoCodSucursal = Console.ReadLine();
                    var ingresoCorr4 = int.TryParse(ingresoCodSucursal, out int codSucursal);
                    sucSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionSucursal(codSucursal);
                    nuevaSeleccionRecepcion.NombreSucursal = sucSelecc;
                }

                break;
            }




            return nuevaSeleccionRecepcion;
        }
        
        

        public void LeerMaestroRegiones()
        {
            if (File.Exists(maestroRegiones))
            {
                using (var reader = new StreamReader(maestroRegiones))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unaRegion = new Region(linea);
                        regiones.Add(unaRegion);
                    }
                }
            }
        }

        public void VerProvinciaPorRegion(int codigoregion)
        {
            Console.WriteLine("CodigoProvincia \tNombre Provincia");
            Dictionary<int, string> auxiliarRegion = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {
                
                if (region.CodigoRegion == codigoregion)
                {
                    encontrado = auxiliarRegion.ContainsKey(region.CodigoProvincia);
                    if (!encontrado)
                    {
                        auxiliarRegion.Add(region.CodigoProvincia,region.NombreProvincia);
                    }   
                }
            }
            foreach (var item in auxiliarRegion)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
            }
        }

        public void VerLocalidadPorProvincia(int codigoProvincia)
        {
            Console.WriteLine("CodigoLocalidad \tNombre Localidad");
            Dictionary<int, string> auxiliarProvincia = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {

                if (region.CodigoProvincia == codigoProvincia)
                {
                    encontrado = auxiliarProvincia.ContainsKey(region.CodigoLocalidad);
                    if (!encontrado)
                    {
                        auxiliarProvincia.Add(region.CodigoLocalidad, region.NombreLocalidad);
                    }
                }
            }
            foreach (var item in auxiliarProvincia)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
            }
        }

        public void VerSucursalPorLocalidad(int codigoLocalidad)
        {
            Console.WriteLine("CodigoSucursal \tNombre Sucursal");
            Dictionary<int, string> auxiliarLocalidad = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {
                if (region.CodigoLocalidad == codigoLocalidad)
                {
                    encontrado = auxiliarLocalidad.ContainsKey(region.CodigoLocalidad);
                    if (!encontrado)
                    {
                        auxiliarLocalidad.Add(region.CodigoSucursal, region.NombreSucursal);
                    }
                }

            }
            foreach (var item in auxiliarLocalidad)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
            }
        }

        public string DevuelveSeleccionProvincia(int codigoProvincia)
        {
            Dictionary<int, string> auxiliarDProvincia = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {
                if (region.CodigoProvincia == codigoProvincia)
                {
                    encontrado = auxiliarDProvincia.ContainsKey(region.CodigoProvincia);
                    if (!encontrado)
                    {
                        auxiliarDProvincia.Add(region.CodigoProvincia, region.NombreProvincia);
                    }
                }

            }
            string guardarProvincia = "";
            foreach (var item in auxiliarDProvincia)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                guardarProvincia = item.Value;
            }
            return guardarProvincia;
        }
        public string DevuelveSeleccionLocalidad(int codigoLocalidad)
        {
            Dictionary<int, string> auxiliarDLocalidad = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {
                if (region.CodigoLocalidad == codigoLocalidad)
                {
                    encontrado = auxiliarDLocalidad.ContainsKey(region.CodigoLocalidad);
                    if (!encontrado)
                    {
                        auxiliarDLocalidad.Add(region.CodigoLocalidad, region.NombreLocalidad);
                    }
                }

            }
            string guardarLocalidad = "";
            foreach (var item in auxiliarDLocalidad)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                guardarLocalidad = item.Value;
            }
            return guardarLocalidad;
        }
        public string DevuelveSeleccionSucursal(int codigoSucursal)
        {
            Dictionary<int, string> auxiliarDSucursal = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var region in regiones)
            {
                if (region.CodigoSucursal == codigoSucursal)
                {
                    encontrado = auxiliarDSucursal.ContainsKey(region.CodigoSucursal);
                    if (!encontrado)
                    {
                        auxiliarDSucursal.Add(region.CodigoSucursal, region.NombreSucursal);
                    }
                }

            }
            string guardarSucursal = "";
            foreach (var item in auxiliarDSucursal)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                guardarSucursal = item.Value;
            }
            return guardarSucursal;
        }
        public void MostrarNuevaRecepcion()
        {
            Console.WriteLine("*************************");
            Console.WriteLine("Datos de recepción");
            Console.WriteLine($"Tipo de recepcion: {TipoRecepcion}");
            if (TipoRecepcion == "Retiro en puerta")
            {
                Console.WriteLine($"Provincia: {NombreProvincia}");
                Console.WriteLine($"Localidad: {NombreLocalidad}");
                Console.WriteLine($"Dirección: {RetiroDireccion}\t Código Postal: {RetiroCodigoPostal}");
            }
            if (TipoRecepcion == "Presentacion en sucursal")
            {
                Console.WriteLine($"Provincia: {NombreProvincia}");
                Console.WriteLine($"Localidad: {NombreLocalidad}");
                Console.WriteLine($"Sucursal: {NombreSucursal}");
            }

        }
    }
}








