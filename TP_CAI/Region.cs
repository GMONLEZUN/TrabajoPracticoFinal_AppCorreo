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


        public int CodigoRegion { get; }
        public string NombreRegion { get; }
        public int CodigoProvincia { get; }
        public string NombreProvincia { get; }
        public int CodigoLocalidad { get; }
        public string NombreLocalidad { get; }
        public int CodigoSucursal { get; }
        public string NombreSucursal { get; }
        public string TitularSucursal { get; }
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
            //List<int> listaAuxiliar2 = new List<int>();
            for (int i = 0; i < regiones.Count; i++)
            {
                Console.WriteLine("CodigoProvincia \tNombre Provincia");
                if (codigoregion == regiones[i].CodigoRegion)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine($"{regiones[i].CodigoProvincia} \t\t\t{regiones[i].NombreProvincia}");
                    //Console.ResetColor();
                    //listaAuxiliar2.Add(regiones[i].CodigoProvincia);
                }
            }
        }

        public void VerLocalidadPorProvincia(int codigoProvincia)
        {
            //List<int> listaAuxiliar2 = new List<int>();
            for (int i = 0; i < regiones.Count; i++)
            {
                if (codigoProvincia == regiones[i].CodigoProvincia)
                {
                    //Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("CodigoLocalidad \tNombre Localidad");
                    Console.WriteLine($"{regiones[i].CodigoLocalidad} \t\t\t{regiones[i].NombreLocalidad}");
                    Console.ResetColor();
                    //listaAuxiliar2.Add(regiones[i].CodigoProvincia);
                }
            }
        }
    }
}






















//        public void LeerMaestroProvincia()
//        {
//            if (File.Exists(maestroRegiones))
//            {
//                using (var reader = new StreamReader(maestroProvincias))
//                {
   
//                    while (!reader.EndOfStream)
//                    {
//                        var linea = reader.ReadLine();
//                        var unaProvincia = new Provincia(linea);
//                        provincias.Add(unaProvincia);
//                        break;
                        
//                    }
//                }
//            }
//        }
//        public void MostrarProvincias()
//        {
//            foreach (var provincia in provincias)
//            {
//                Console.WriteLine($"{CodProvincia}\t{NombreProvincia}");
//            }
//        }
        
        
        
//        public void MostrarLocalidadesPorProvincia()
//        {
//            Console.WriteLine($"Localidades encontradas para {NombreProvincia}");
//            foreach (var provincia in provincias)
//            {
//                Console.WriteLine($"{CodLocalidad}\t{NombreLocalidad}");
//            }
        
//        }
//    }
//}
