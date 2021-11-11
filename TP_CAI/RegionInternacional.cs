using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class RegionInternacional
    {


        //public int CodigoRegion { get; private set; }
        //public string NombreRegion { get; private set; }
        //public int CodigoProvincia { get; private set; }
        //public string NombreProvincia { get; private set; }
        //public int CodigoLocalidad { get; private set; }
        //public string NombreLocalidad { get; private set; }
        //public int CodigoSucursal { get; private set; }
        //public string NombreSucursal { get; private set; }
        //public string TitularSucursal { get; private set; }
        //public string TipoRecepcion { get; private set; }
        //public string RetiroDireccion { get; private set; }
        //public int RetiroCodigoPostal { get; private set; }
        //-----------------------------------------------------------------------------------------------------
        public string NombreRegionEntregaInt { get; private set; }
        public int CodigoPais { get; private set; }
        public string NombrePais { get; private set; }
        public string NombreEstadoEntregaInt { get; private set; }
        public string NombreLocalidadEntregaInt { get; private set; }
        public string TipoEntregaInt { get; private set; }
        public string DireccionEntregaInt { get; private set; }
        public int CodigoPostalEntregaInt { get; private set; }

        //const string maestroRegiones = "maestroRegiones.txt";
        const string maestroPaises = "maestroPaises.txt";

        public List<RegionInternacional> paises = new List<RegionInternacional>();

        //public RegionInternacional(string linea)
        //{
        //    var datos = linea.Split('|');
        //    CodigoRegion = int.Parse(datos[0]);
        //    NombreRegion = datos[1];
        //    CodigoProvincia = int.Parse(datos[2]);
        //    NombreProvincia = datos[3];
        //    CodigoLocalidad = int.Parse(datos[4]);
        //    NombreLocalidad = datos[5];
        //    CodigoSucursal = int.Parse(datos[6]);
        //    NombreSucursal = datos[7];
        //    TitularSucursal = datos[8];
        //}
        public RegionInternacional(string linea)
        {
            var datos = linea.Split('|');
            CodigoPais = int.Parse(datos[0]);
            NombrePais = datos[1];
            NombreRegionEntregaInt = datos[2];
        }
        public RegionInternacional()
        {

        }

        //----------------------------------------RECEPCION--------------------------------------------------------------------------------------------------------
        //public static Region SeleccionRecepcion()
        //{
        //    var nuevaSeleccionRecepcionInt = new RegionInternacional();


        //    while (true)
        //    {

        //        string provSelecc = "";
        //        string locSelecc = "";
        //        string sucSelecc = "";
        //        //----------------------------------Pedimos el tipo de retiro del envío---------------------------------
        //        int opcionSelec = Validaciones.ValidarOpcion("-", "1-Retiro en puerta\n2-Presentación en sucursal", 1, 2);
        //        if (opcionSelec == 1)
        //        {
        //            nuevaSeleccionRecepcionInt.TipoRecepcion = "Retiro en puerta";
        //            //----------------------------------Pedimos la región de retiro del envío---------------------------------
        //            int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

        //            nuevaSeleccionRecepcion.LeerMaestroRegiones();
        //            //----------------------------------Pedimos la provincia de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Seleccione la provincia donde se realizará el retiro del envío");
        //            Console.ResetColor();

        //            //nuevaSeleccionRecepcion.VerProvinciaPorRegion(opcionRegion);
        //            int codProvincia = nuevaSeleccionRecepcion.VerProvinciaPorRegion(opcionRegion);
        //            provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
        //            nuevaSeleccionRecepcion.NombreProvincia = provSelecc;

        //            //----------------------------------Pedimos la localidad de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Seleccione la localidad donde se realizará el retiro del envío");
        //            Console.ResetColor();
        //            int codLocalidad = nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
        //            locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
        //            nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;
        //            //----------------------------------Pedimos la dirección exacta de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Ingrese la dirección exacta donde se realizara el retiro del envío");
        //            Console.ResetColor();
        //            var direccion = Console.ReadLine();
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Ingrese el código postal de la dirección ingresada");
        //            Console.ResetColor();
        //            var ingresoCodPostal = Console.ReadLine();
        //            bool ingresoCorr4 = int.TryParse(ingresoCodPostal, out int CodPostal);
        //            nuevaSeleccionRecepcion.RetiroDireccion = direccion;
        //            nuevaSeleccionRecepcion.RetiroCodigoPostal = CodPostal;

        //        }
        //        if (opcionSelec == 2)
        //        {
        //            nuevaSeleccionRecepcion.TipoRecepcion = "Presentacion en sucursal";
        //            //----------------------------------Pedimos la región de retiro del envío---------------------------------
        //            int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

        //            nuevaSeleccionRecepcion.LeerMaestroRegiones();
        //            //----------------------------------Pedimos la provincia de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Seleccione la provincia donde se realizará la presentación del envío");
        //            Console.ResetColor();
        //            int codProvincia = nuevaSeleccionRecepcion.VerProvinciaPorRegion(opcionRegion);
        //            provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
        //            nuevaSeleccionRecepcion.NombreProvincia = provSelecc;
        //            //----------------------------------Pedimos la localidad de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Seleccione la localidad donde se realizará la presentación del envío");
        //            Console.ResetColor();
        //            int codLocalidad = nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
        //            locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
        //            nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;
        //            //----------------------------------Pedimos la sucursal de retiro del envío---------------------------------
        //            Console.ForegroundColor = ConsoleColor.Cyan;
        //            Console.WriteLine("Seleccione la sucursal donde se realizará la presentación del envío");
        //            Console.ResetColor();
        //            int codSucursal = nuevaSeleccionRecepcion.VerSucursalPorLocalidad(codLocalidad);
        //            sucSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionSucursal(codSucursal);
        //            nuevaSeleccionRecepcion.NombreSucursal = sucSelecc;
        //        }
        //        break;
        //    }

        //    return nuevaSeleccionRecepcion;
        //}
        //----------------------------------------ENTREGA-----------------------------------------------------------------------------------------------------------------
        public static RegionInternacional SeleccionEntregaInt()
        {
            var nuevaSeleccionEntregaInt = new RegionInternacional();


            while (true)
            {

                string paisSelecc = "";

                //----------------------------------Pedimos el tipo de entrega del envío---------------------------------

                nuevaSeleccionEntregaInt.TipoEntregaInt = "Entrega en puerta";
                ////----------------------------------Pedimos la región de entrega del envío---------------------------------
                //int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");
                //nuevaSeleccionEntrega.LeerMaestroRegiones();

                //VER REGION
                //----------------------------------Pedimos el país de retiro del envío---------------------------------
                nuevaSeleccionEntregaInt.LeerMaestroPaises();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Seleccione el país donde se realizará el retiro del envío");
                Console.ResetColor();
                int codPais = nuevaSeleccionEntregaInt.VerPaises();
                paisSelecc = nuevaSeleccionEntregaInt.DevuelveSeleccionPais(codPais);
                nuevaSeleccionEntregaInt.NombrePais = paisSelecc;

                //----------------------------------Pedimos la provincia de entrega del envío---------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese la provincia o el estado donde se realizará la entrega del envío");
                Console.ResetColor();
                string estadoProvincia = Console.ReadLine();
                nuevaSeleccionEntregaInt.NombreEstadoEntregaInt = estadoProvincia;

                //----------------------------------Pedimos la localidad de entrega del envío---------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese la localidad donde se realizará la entrega del envío");
                Console.ResetColor();
                string localidad = Console.ReadLine();
                nuevaSeleccionEntregaInt.NombreLocalidadEntregaInt = localidad;
                //----------------------------------Pedimos la dirección exacta de entrega del envío---------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese la dirección exacta donde se realizara la entrega del envío");
                Console.ResetColor();
                var direccion = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Ingrese el código postal de la dirección ingresada");
                Console.ResetColor();
                var ingresoCodPostal = Console.ReadLine();
                bool ingresoCorr4 = int.TryParse(ingresoCodPostal, out int CodPostal);
                nuevaSeleccionEntregaInt.DireccionEntregaInt = direccion;
                nuevaSeleccionEntregaInt.CodigoPostalEntregaInt = CodPostal;

                break;
            }
            return nuevaSeleccionEntregaInt;
        }

        //----------------------------------Lectura de archivo maestroPaises.txt------------------------------------------------------
        public void LeerMaestroPaises()
        {
            if (File.Exists(maestroPaises))
            {
                using (var reader = new StreamReader(maestroPaises))
                {
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();

                        var unPais = new RegionInternacional(linea);
                        paises.Add(unPais);
                    }
                }
            }
        }
        //----------------------------------Nos devuelve los países para seleccionar------------------------
        public int VerPaises()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("CodigoPaís \tNombre País");
            Console.ResetColor();
            Dictionary<int, string> auxiliarPais = new Dictionary<int, string>();

            foreach (var pais in paises)
            {

                auxiliarPais.Add(pais.CodigoPais, pais.NombrePais);

            }
            foreach (var pais in auxiliarPais)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{pais.Key} \t\t\t{pais.Value}");
                Console.ResetColor();
            }
            // validamos que el ingreso del usuario corresponda a lo que se muestra
            int opcion;
            do
            {
                var ingreso = Console.ReadLine();
                bool ingresoOpcionValida = false;
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                foreach (var item in auxiliarPais)
                {
                    if (item.Key == opcion)
                    {
                        ingresoOpcionValida = true;
                    }
                }
                if (!ingresoOpcionValida || !ingresoCorrecto)
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


        ////----------------------------------Dado un código de provincia nos devuelve las localidades para seleccionar------------------------
        //public int VerLocalidadPorProvincia(int codigoProvincia)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("CodigoLocalidad \tNombre Localidad");
        //    Console.ResetColor();
        //    Dictionary<int, string> auxiliarProvincia = new Dictionary<int, string>();
        //    bool encontrado = false;
        //    foreach (var region in regiones)
        //    {

        //        if (region.CodigoProvincia == codigoProvincia)
        //        {
        //            encontrado = auxiliarProvincia.ContainsKey(region.CodigoLocalidad);
        //            if (!encontrado)
        //            {
        //                auxiliarProvincia.Add(region.CodigoLocalidad, region.NombreLocalidad);
        //            }
        //        }
        //    }
        //    foreach (var item in auxiliarProvincia)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
        //        Console.ResetColor();
        //    }
        //    // validamos que el ingreso del usuario corresponda a lo que se muestra
        //    int opcion;
        //    do
        //    {
        //        var ingreso = Console.ReadLine();
        //        bool ingresoOpcionValida = false;
        //        bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
        //        foreach (var item in auxiliarProvincia)
        //        {
        //            if (item.Key == opcion)
        //            {
        //                ingresoOpcionValida = true;
        //            }
        //        }
        //        if (!ingresoOpcionValida || !ingresoCorrecto)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("La opción ingresada no es correcta, intente nuevamente");
        //            Console.ResetColor();
        //            continue;
        //        }
        //        break;
        //    } while (true);
        //    return opcion;
        //}
        ////----------------------------------Dado un código de localidad nos devuelve las sucursales para seleccionar------------------------
        //public int VerSucursalPorLocalidad(int codigoLocalidad)
        //{
        //    Console.ForegroundColor = ConsoleColor.Yellow;
        //    Console.WriteLine("CodigoSucursal \t\t\tNombre Sucursal");
        //    Console.ResetColor();
        //    Dictionary<int, string> auxiliarLocalidad = new Dictionary<int, string>();
        //    bool encontrado = false;
        //    foreach (var region in regiones)
        //    {
        //        if (region.CodigoLocalidad == codigoLocalidad)
        //        {
        //            encontrado = auxiliarLocalidad.ContainsKey(region.CodigoLocalidad);
        //            if (!encontrado)
        //            {
        //                auxiliarLocalidad.Add(region.CodigoSucursal, region.NombreSucursal);
        //            }
        //        }
        //    }
        //    foreach (var item in auxiliarLocalidad)
        //    {
        //        Console.ForegroundColor = ConsoleColor.Green;
        //        Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
        //        Console.ResetColor();
        //    }
        //    // validamos que el ingreso del usuario corresponda a lo que se muestra
        //    int opcion;
        //    do
        //    {
        //        var ingreso = Console.ReadLine();
        //        bool ingresoOpcionValida = false;
        //        bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
        //        foreach (var item in auxiliarLocalidad)
        //        {
        //            if (item.Key == opcion)
        //            {
        //                ingresoOpcionValida = true;
        //            }
        //        }
        //        if (!ingresoOpcionValida || !ingresoCorrecto)
        //        {
        //            Console.ForegroundColor = ConsoleColor.Red;
        //            Console.WriteLine("La opción ingresada no es correcta, intente nuevamente");
        //            Console.ResetColor();
        //            continue;
        //        }
        //        break;
        //    } while (true);
        //    return opcion;
        //}
        //----------------------------------Dado un código de provincia nos devuelve la provincia elegida---------------------------------
        public string DevuelveSeleccionPais(int codigoPais)
        {
            Dictionary<int, string> auxiliarDPais = new Dictionary<int, string>();
            bool encontrado = false;
            foreach (var pais in paises)
            {
                if (pais.CodigoPais == codigoPais)
                {
                    encontrado = auxiliarDPais.ContainsKey(pais.CodigoPais);
                    if (!encontrado)
                    {
                        auxiliarDPais.Add(pais.CodigoPais, pais.NombrePais);
                    }
                }

            }
            string guardarPais = "";
            foreach (var item in auxiliarDPais)
            {
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                guardarPais = item.Value;
            }
            return guardarPais;
        }
        //----------------------------------Dado un código de localidad nos devuelve la localidad elegida---------------------------------
        //public string DevuelveSeleccionLocalidad(int codigoLocalidad)
        //{
        //    Dictionary<int, string> auxiliarDLocalidad = new Dictionary<int, string>();
        //    bool encontrado = false;
        //    foreach (var region in regiones)
        //    {
        //        if (region.CodigoLocalidad == codigoLocalidad)
        //        {
        //            encontrado = auxiliarDLocalidad.ContainsKey(region.CodigoLocalidad);
        //            if (!encontrado)
        //            {
        //                auxiliarDLocalidad.Add(region.CodigoLocalidad, region.NombreLocalidad);
        //            }
        //        }
        //    }
        //    string guardarLocalidad = "";
        //    foreach (var item in auxiliarDLocalidad)
        //    {
        //        Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
        //        guardarLocalidad = item.Value;
        //    }
        //    return guardarLocalidad;
        //}
        ////----------------------------------Dado un código de sucursal nos devuelve la sucursal elegida---------------------------------
        //public string DevuelveSeleccionSucursal(int codigoSucursal)
        //{
        //    Dictionary<int, string> auxiliarDSucursal = new Dictionary<int, string>();
        //    bool encontrado = false;
        //    foreach (var region in regiones)
        //    {
        //        if (region.CodigoSucursal == codigoSucursal)
        //        {
        //            encontrado = auxiliarDSucursal.ContainsKey(region.CodigoSucursal);
        //            if (!encontrado)
        //            {
        //                auxiliarDSucursal.Add(region.CodigoSucursal, region.NombreSucursal);
        //            }
        //        }

        //    }
        //    string guardarSucursal = "";
        //    foreach (var item in auxiliarDSucursal)
        //    {
        //        Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
        //        guardarSucursal = item.Value;
        //    }
        //    return guardarSucursal;
        //}
        //----------------------------------Muestra todos los datos de la recepción dependiendo de lo seleccionado---------------------------------

        public void MostrarNuevaEntregaInternacional()
        {
            Console.WriteLine("Datos de Entrega");
            Console.WriteLine("----------------");
            Console.WriteLine($"Tipo de recepcion: {TipoEntregaInt}");
            Console.WriteLine($"Provincia: {NombreEstadoEntregaInt}");
            Console.WriteLine($"Localidad: {NombreLocalidadEntregaInt}");
            Console.WriteLine($"Dirección: {DireccionEntregaInt}\t Código Postal: {CodigoPostalEntregaInt}");

        }
    }
}
