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

        public string NombreRegionEntregaInt { get; private set; }
        public int CodigoPais { get; private set; }
        public string NombrePais { get; private set; }
        public string NombreEstadoEntregaInt { get; private set; }
        public string NombreLocalidadEntregaInt { get; private set; }
        public string TipoEntregaInt { get; private set; }
        public string DireccionEntregaInt { get; private set; }
        public int CodigoPostalEntregaInt { get; private set; }

        const string maestroPaises = "maestroPaises.txt";

        public List<RegionInternacional> paises = new List<RegionInternacional>();


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


        //----------------------------------------ENTREGA-----------------------------------------------------------------------------------------------------------------
        public static RegionInternacional SeleccionEntregaInt()
        {
            var nuevaSeleccionEntregaInt = new RegionInternacional();


            while (true)
            {

                string paisSelecc = "";

                //----------------------------------Pedimos el tipo de entrega del envío---------------------------------

                nuevaSeleccionEntregaInt.TipoEntregaInt = "Entrega en puerta";

                //VER de asignar REGION*****************
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
