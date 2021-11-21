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
        //-----------------------------------------------------------------------------------------------------
        public int CodigoRegionEntrega { get; private set; }
        public string NombreRegionEntrega { get; private set; }
        public int CodigoProvinciaEntrega { get; private set; }
        public string NombreProvinciaEntrega { get; private set; }
        public int CodigoLocalidadEntrega { get; private set; }
        public string NombreLocalidadEntrega { get; private set; }
        public int CodigoSucursalEntrega { get; private set; }
        public string NombreSucursalEntrega { get; private set; }
        public string TitularSucursalEntrega { get; private set; }
        public string TipoEntrega { get; private set; }
        public string DireccionEntrega { get; private set; }
        public int CodigoPostalEntrega { get; private set; }
        public string NombreDestinatario { get; private set; }
        public string NumeroDNIdestinatario { get; private set; }
        public string SucursalDireccion { get; private set; }
        public string SucursalCodigoPostal { get; private set; }
        public string SucursalDireccionEntrega { get; private set; }
        public string SucursalCodigoPostalEntrega { get; private set; }

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
            SucursalDireccion = datos[8];
            SucursalCodigoPostal = datos[9];
            TitularSucursal = datos[10];
        }

        public Region()
        {

        }

        //----------------------------------------RECEPCION--------------------------------------------------------------------------------------------------------
        public static Region SeleccionRecepcion()
        {
            var nuevaSeleccionRecepcion = new Region();

            while (true)
            {
                string provSelecc = "";
                string locSelecc = "";
                string sucSelecc = "";

                //----------------------------------Pedimos el tipo de retiro del envío---------------------------------
                int opcionSelec = Validaciones.ValidarOpcion("-", "1-Retiro en puerta\n2-Presentación en sucursal", 1, 2);
                if (opcionSelec == 1)
                {
                    nuevaSeleccionRecepcion.TipoRecepcion = "Retiro en puerta";

                    //----------------------------------Pedimos la región de retiro del envío---------------------------------
                    int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

                    nuevaSeleccionRecepcion.LeerMaestroRegiones();

                    if (opcionRegion == 10)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región Pampeana";
                    }
                    if (opcionRegion == 20)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región NOA";
                    }
                    if (opcionRegion == 30)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región NEA";
                    }
                    if (opcionRegion == 40)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región Patagónica";
                    }
                    nuevaSeleccionRecepcion.CodigoRegion = opcionRegion;

                    //----------------------------------Pedimos la provincia de retiro del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la provincia donde se realizará el retiro del envío");
                    Console.ResetColor();
                    
                    int codProvincia = nuevaSeleccionRecepcion.VerProvinciaPorRegion(opcionRegion);
                    provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionRecepcion.NombreProvincia = provSelecc;
                    nuevaSeleccionRecepcion.CodigoProvincia = codProvincia;

                    //----------------------------------Pedimos la localidad de retiro del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la localidad donde se realizará el retiro del envío");
                    Console.ResetColor();

                    int codLocalidad = nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
                    locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;
                    nuevaSeleccionRecepcion.CodigoLocalidad = codLocalidad;

                    //----------------------------------Pedimos la dirección exacta de retiro del envío---------------------------------
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("Ingrese la dirección exacta donde se realizara el retiro del envío");
                    //Console.ResetColor();
                    var direccion = Validaciones.ValidarBarraEnString("Ingrese la dirección exacta donde se realizara el retiro del envío");
                    //var direccion = Console.ReadLine();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("Ingrese el código postal de la dirección ingresada");
                    //Console.ResetColor();
                    var CodPostal = Validaciones.ValidarBarraEnInt("Ingrese el código postal de la dirección ingresada", "el código postal", 4, 8);
                    //var ingresoCodPostal = Console.ReadLine();

                    //bool ingresoCorr4 = int.TryParse(ingresoCodPostal, out int CodPostal);
                    nuevaSeleccionRecepcion.RetiroDireccion = direccion;
                    nuevaSeleccionRecepcion.RetiroCodigoPostal = CodPostal;
                }
                if (opcionSelec == 2)
                {
                    nuevaSeleccionRecepcion.TipoRecepcion = "Presentacion en sucursal";

                    //----------------------------------Pedimos la región de retiro del envío---------------------------------
                    int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

                    nuevaSeleccionRecepcion.LeerMaestroRegiones();

                    if (opcionRegion == 10)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región Pampeana";
                    }
                    if (opcionRegion == 20)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región NOA";
                    }
                    if (opcionRegion == 30)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región NEA";
                    }
                    if (opcionRegion == 40)
                    {
                        nuevaSeleccionRecepcion.NombreRegion = "Región Patagónica";
                    }
                    nuevaSeleccionRecepcion.CodigoRegion = opcionRegion;

                    //----------------------------------Pedimos la provincia de retiro del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la provincia donde se realizará la presentación del envío");
                    Console.ResetColor();

                    int codProvincia = nuevaSeleccionRecepcion.VerProvinciaPorRegion(opcionRegion);
                    provSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionRecepcion.NombreProvincia = provSelecc;
                    nuevaSeleccionRecepcion.CodigoProvincia = codProvincia;

                    //----------------------------------Pedimos la localidad de retiro del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la localidad donde se realizará la presentación del envío");
                    Console.ResetColor();

                    int codLocalidad = nuevaSeleccionRecepcion.VerLocalidadPorProvincia(codProvincia);
                    locSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionRecepcion.NombreLocalidad = locSelecc;
                    nuevaSeleccionRecepcion.CodigoLocalidad = codLocalidad;

                    //----------------------------------Pedimos la sucursal de retiro del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la sucursal donde se realizará la presentación del envío");
                    Console.ResetColor();

                    int codSucursal = nuevaSeleccionRecepcion.VerSucursalPorLocalidad(codLocalidad);
                    sucSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionSucursal(codSucursal);
                    nuevaSeleccionRecepcion.NombreSucursal = sucSelecc;
                    nuevaSeleccionRecepcion.CodigoSucursal = codSucursal;
                    string sucDirSelecc = nuevaSeleccionRecepcion.DevuelveSeleccionSucursalDireccion(codSucursal);
                    nuevaSeleccionRecepcion.SucursalDireccion = sucDirSelecc;
                }
                break;
            }

            return nuevaSeleccionRecepcion;
        }


        //----------------------------------------ENTREGA-----------------------------------------------------------------------------------------------------------------
        public static Region SeleccionEntrega()
        {
            var nuevaSeleccionEntrega = new Region();

            while (true)
            {
                string provSelecc = "";
                string locSelecc = "";
                string sucSelecc = "";

                //----------------------------------Pedimos el tipo de entrega del envío---------------------------------
                int opcionSelec = Validaciones.ValidarOpcion("-", "1-Entrega en puerta\n2-Entrega en sucursal", 1, 2);
                if (opcionSelec == 1)
                {
                    nuevaSeleccionEntrega.TipoEntrega = "Entrega en puerta";

                    //----------------------------------Pedimos la región de entrega del envío---------------------------------
                    int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará la entrega del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");
                    nuevaSeleccionEntrega.LeerMaestroRegiones();

                    if (opcionRegion == 10)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región Pampeana";
                    }
                    if (opcionRegion == 20)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región NOA";
                    }
                    if (opcionRegion == 30)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región NEA";
                    }
                    if (opcionRegion == 40)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región Patagónica";
                    }
                    nuevaSeleccionEntrega.CodigoRegionEntrega = opcionRegion;

                    //----------------------------------Pedimos la provincia de entrega del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la provincia donde se realizará la entrega del envío");
                    Console.ResetColor();

                    int codProvincia = nuevaSeleccionEntrega.VerProvinciaPorRegion(opcionRegion);
                    provSelecc = nuevaSeleccionEntrega.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionEntrega.NombreProvinciaEntrega = provSelecc;
                    nuevaSeleccionEntrega.CodigoProvinciaEntrega = codProvincia;

                    //----------------------------------Pedimos la localidad de entrega del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la localidad donde se realizará la entrega del envío");
                    Console.ResetColor();

                    int codLocalidad = nuevaSeleccionEntrega.VerLocalidadPorProvincia(codProvincia);
                    locSelecc = nuevaSeleccionEntrega.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionEntrega.NombreLocalidadEntrega = locSelecc;
                    nuevaSeleccionEntrega.CodigoLocalidadEntrega = codLocalidad;

                    //----------------------------------Pedimos la dirección exacta de entrega del envío---------------------------------
                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("Ingrese la dirección exacta donde se realizará la entrega del envío");
                    //Console.ResetColor();
                    var direccion = Validaciones.ValidarBarraEnString("Ingrese la dirección exacta donde se realizará la entrega del envío");
                    //var direccion = Console.ReadLine();

                    //Console.ForegroundColor = ConsoleColor.Cyan;
                    //Console.WriteLine("Ingrese el código postal de la dirección ingresada");
                    //Console.ResetColor();

                    //var ingresoCodPostal = Console.ReadLine();
                    //bool ingresoCorr4 = int.TryParse(ingresoCodPostal, out int CodPostal);
                    var CodPostal = Validaciones.ValidarBarraEnInt("Ingrese el código postal de la dirección ingresada", "el código postal", 4, 8);
                    nuevaSeleccionEntrega.DireccionEntrega = direccion;
                    nuevaSeleccionEntrega.CodigoPostalEntrega = CodPostal;

                }
                if (opcionSelec == 2)
                {
                    nuevaSeleccionEntrega.TipoEntrega = "Entrega en sucursal";

                    //----------------------------------Pedimos la región de entrega del envío---------------------------------
                    int opcionRegion = Validaciones.ValidarRegion("Seleccione la región donde se realizará el retiro del envío: ", "10-Región Pampeana\n20-Región NOA\n30-Región NEA\n40-Región Patagónica\n");

                    nuevaSeleccionEntrega.LeerMaestroRegiones();

                    if (opcionRegion == 10)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región Pampeana";
                    }
                    if (opcionRegion == 20)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región NOA";
                    }
                    if (opcionRegion == 30)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región NEA";
                    }
                    if (opcionRegion == 40)
                    {
                        nuevaSeleccionEntrega.NombreRegionEntrega = "Región Patagónica";
                    }
                    nuevaSeleccionEntrega.CodigoRegionEntrega = opcionRegion;

                    //----------------------------------Pedimos la provincia de entrega del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la provincia donde se realizará la entrega del envío");
                    Console.ResetColor();

                    int codProvincia = nuevaSeleccionEntrega.VerProvinciaPorRegion(opcionRegion);
                    provSelecc = nuevaSeleccionEntrega.DevuelveSeleccionProvincia(codProvincia);
                    nuevaSeleccionEntrega.NombreProvinciaEntrega = provSelecc;
                    nuevaSeleccionEntrega.CodigoProvinciaEntrega = codProvincia;

                    //----------------------------------Pedimos la localidad de entrega del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la localidad donde se realizará la entrega del envío");
                    Console.ResetColor();

                    int codLocalidad = nuevaSeleccionEntrega.VerLocalidadPorProvincia(codProvincia);
                    locSelecc = nuevaSeleccionEntrega.DevuelveSeleccionLocalidad(codLocalidad);
                    nuevaSeleccionEntrega.NombreLocalidadEntrega = locSelecc;
                    nuevaSeleccionEntrega.CodigoLocalidadEntrega = codLocalidad;

                    //----------------------------------Pedimos la sucursal de entrega del envío---------------------------------
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Seleccione la sucursal donde se realizará la entrega del envío");
                    Console.ResetColor();

                    int codSucursal = nuevaSeleccionEntrega.VerSucursalPorLocalidad(codLocalidad);
                    sucSelecc = nuevaSeleccionEntrega.DevuelveSeleccionSucursal(codSucursal);
                    nuevaSeleccionEntrega.NombreSucursalEntrega = sucSelecc;
                    nuevaSeleccionEntrega.CodigoSucursalEntrega = codSucursal;
                    string sucDirSelecc = nuevaSeleccionEntrega.DevuelveSeleccionSucursalDireccion(codSucursal);
                    nuevaSeleccionEntrega.SucursalDireccionEntrega = sucDirSelecc;
                }
                break;
            }

            while (true)
            {
                //-------------------------------------Pedimos datos del destinatario del envío-----------------------------------
                //Console.ForegroundColor = ConsoleColor.Cyan;
                //Console.WriteLine("Ingrese nombre y apellido del destinatario");
                //Console.ResetColor();
                var nombreDestinatario = Validaciones.ValidarBarraEnString("Ingrese nombre y apellido del destinatario");
                //var nombreDestinatario = Console.ReadLine();
                nuevaSeleccionEntrega.NombreDestinatario = nombreDestinatario;
                var dniDestinatario = Validaciones.ValidarDNI("Ingrese el DNI del destinatario");
                nuevaSeleccionEntrega.NumeroDNIdestinatario = dniDestinatario;
                break;
            }
            return nuevaSeleccionEntrega;
        }

        //----------------------------------Lectura de archivo maestroRegiones.txt------------------------------------------------------
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
        //----------------------------------Dado un código de región nos devuelve las provincias para seleccionar------------------------
        public int VerProvinciaPorRegion(int codigoregion)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Código Provincia \tNombre Provincia");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                Console.ResetColor();
            }
            // validamos que el ingreso del usuario corresponda a lo que se muestra
            int opcion;
            do
            {
                var ingreso = Console.ReadLine();
                bool ingresoOpcionValida = false;
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                foreach (var item in auxiliarRegion)
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
    

        //----------------------------------Dado un código de provincia nos devuelve las localidades para seleccionar------------------------
        public int VerLocalidadPorProvincia(int codigoProvincia)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Código Localidad \tNombre Localidad");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                Console.ResetColor();
            }
            // validamos que el ingreso del usuario corresponda a lo que se muestra
            int opcion;
            do
            {
                var ingreso = Console.ReadLine();
                bool ingresoOpcionValida = false;
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                foreach (var item in auxiliarProvincia)
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


        //----------------------------------Dado un código de localidad nos devuelve las sucursales para seleccionar------------------------
        public int VerSucursalPorLocalidad(int codigoLocalidad)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Código Sucursal \t\t\tNombre Sucursal");
            Console.ResetColor();
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
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{item.Key} \t\t\t{item.Value}");
                Console.ResetColor();
            }
            // validamos que el ingreso del usuario corresponda a lo que se muestra
            int opcion;
            do
            {
                var ingreso = Console.ReadLine();
                bool ingresoOpcionValida = false;
                bool ingresoCorrecto = int.TryParse(ingreso, out opcion);
                foreach (var item in auxiliarLocalidad)
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


        //----------------------------------Dado un código de provincia nos devuelve la provincia elegida---------------------------------
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


        //----------------------------------Dado un código de localidad nos devuelve la localidad elegida---------------------------------
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


        //----------------------------------Dado un código de sucursal nos devuelve la sucursal elegida---------------------------------
        public string DevuelveSeleccionSucursal(int codigoSucursal)
        {
            Dictionary<int, string> auxiliarDSucursal = new Dictionary<int, string>();
            bool encontrado = false;
            string guardarSucursal = "";
            foreach (var region in regiones)
            {
                if (region.CodigoSucursal == codigoSucursal)
                {
                    encontrado = auxiliarDSucursal.ContainsKey(region.CodigoSucursal);
                    if (!encontrado)
                    {
                        auxiliarDSucursal.Add(region.CodigoSucursal, region.NombreSucursal);
                        guardarSucursal = $"[{region.CodigoSucursal}]  {region.NombreSucursal}\tDirección: {region.SucursalDireccion}";
                    }
                }
            }

            return guardarSucursal;
        }

        public string DevuelveSeleccionSucursalDireccion(int codigoSucursal)
        {
            Dictionary<int, string> auxiliarDSucursal = new Dictionary<int, string>();
            bool encontrado = false;
            string guardarDirSucursal = "";
            foreach (var region in regiones)
            {
                if (region.CodigoSucursal == codigoSucursal)
                {
                    encontrado = auxiliarDSucursal.ContainsKey(region.CodigoSucursal);
                    if (!encontrado)
                    {
                        auxiliarDSucursal.Add(region.CodigoSucursal, region.NombreSucursal);
                        guardarDirSucursal = region.SucursalDireccion;
                    }
                }
            }

            return guardarDirSucursal;
        }


        //----------------------------------Muestra todos los datos de la recepción dependiendo de lo seleccionado---------------------------------
        public void MostrarNuevaRecepcion()
        {
            Console.WriteLine("");
            Console.WriteLine("Origen");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Tipo de recepción: {TipoRecepcion}");
            if (TipoRecepcion == "Retiro en puerta")
            {
                Console.WriteLine($"Provincia: {NombreProvincia}\t\t\tLocalidad: {NombreLocalidad}");
                //Console.WriteLine($"Localidad: {NombreLocalidad}");
                Console.WriteLine($"Dirección: {RetiroDireccion}\t\tCódigo Postal: {RetiroCodigoPostal}");
            }
            if (TipoRecepcion == "Presentacion en sucursal")
            {
                Console.WriteLine($"Provincia: {NombreProvincia}\t\t\tLocalidad: {NombreLocalidad}");
                Console.WriteLine("");
                Console.WriteLine($"Sucursal: {NombreSucursal}");
                
            }

        }

        //----------------------------------Muestra todos los datos de la entrega dependiendo de lo seleccionado---------------------------------
        public void MostrarNuevaEntrega()
        {
            Console.WriteLine("");
            Console.WriteLine("Datos de Entrega");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine($"Destinatario: {NombreDestinatario}\t\t\tDNI: {NumeroDNIdestinatario}");
            Console.WriteLine("");
            Console.WriteLine($"Tipo de entrega: {TipoEntrega}");
            if (TipoEntrega == "Entrega en puerta")
            {
                Console.WriteLine($"Provincia: {NombreProvinciaEntrega}\t\t\tLocalidad: {NombreLocalidadEntrega}");
                Console.WriteLine($"Dirección: {DireccionEntrega}\t\tCódigo Postal: {CodigoPostalEntrega}");
            }
            if (TipoEntrega == "Entrega en sucursal")
            {
                Console.WriteLine($"Provincia: {NombreProvinciaEntrega}\t\t\tLocalidad: {NombreLocalidadEntrega}");
                Console.WriteLine("");
                Console.WriteLine($"Sucursal: {NombreSucursalEntrega}");
            }
        }

        public void EscribirNuevaRecepcion(StreamWriter writer) 
        {
            writer.WriteLine("");
            writer.WriteLine("Origen");
            writer.WriteLine("-----------------------------------------------------------------------");
            writer.WriteLine($"Tipo de recepcion: {TipoRecepcion}");
            if (TipoRecepcion == "Retiro en puerta")
            {
                writer.WriteLine($"Provincia: {NombreProvincia}\t\t\tLocalidad: {NombreLocalidad}");
                writer.WriteLine($"Dirección: {RetiroDireccion}\t\t\tCódigo Postal: {RetiroCodigoPostal}");
            }
            if (TipoRecepcion == "Presentacion en sucursal")
            {
                writer.WriteLine($"Provincia: {NombreProvincia}\t\t\tLocalidad: {NombreLocalidad}");
                writer.WriteLine("");
                writer.WriteLine($"Sucursal: {NombreSucursal}");
            }
        }

        public void EscribirNuevaEntrega(StreamWriter writer)
        {
            writer.WriteLine("");
            writer.WriteLine("Datos de Entrega");
            writer.WriteLine("-----------------------------------------------------------------------");
            writer.WriteLine($"Destinatario: {NombreDestinatario}\t\t\tDNI: {NumeroDNIdestinatario}");
            writer.WriteLine("");
            writer.WriteLine($"Tipo de entrega: {TipoEntrega}");
            if (TipoEntrega == "Entrega en puerta")
            {
                writer.WriteLine($"Provincia: {NombreProvinciaEntrega}\t\t\tLocalidad: {NombreLocalidadEntrega}");
                writer.WriteLine($"Dirección: {DireccionEntrega}\t\t\tCódigo Postal: {CodigoPostalEntrega}");
            }
            if (TipoEntrega == "Entrega en sucursal")
            {
                writer.WriteLine($"Provincia: {NombreProvinciaEntrega}\t\t\tLocalidad: {NombreLocalidadEntrega}");
                writer.WriteLine("");
                writer.WriteLine($"Sucursal: {NombreSucursalEntrega}");
            }
        }
    }
}








