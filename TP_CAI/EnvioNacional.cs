using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CAI
{
    class EnvioNacional
    {
        public string TipoPaquete { get; private set; }
        public string PesoPaquete { get; private set; }
        public string TipoEnvio { get; private set; }

        List<Region> ListaSeleccionRetiro = new List<Region>();

        public static EnvioNacional Ingresar() 
        {
            var nuevoEnvioNacional = new EnvioNacional();
            
            Console.WriteLine("Nueva Orden de Servicio - Envío Nacional");
            while (true)
            {
                Console.WriteLine("Seleccione el tipo de paquete que desea enviar \n1- Correspondencia \n2- Encomienda ");
                string tipoPaquete = "";
                var ingreso = Console.ReadLine();
                var ingresoCorrecto = int.TryParse(ingreso, out int opcion);
                if (!ingresoCorrecto)
                {
                    Console.WriteLine("Ingrese una opción válida");
                    continue;
                }
                if (opcion < 1)
                {
                    Console.WriteLine("Ingrese una opción válida");
                    continue;
                }
                if (opcion > 2)
                {
                    Console.WriteLine("Ingrese una opción válida");
                    continue;
                }
                if (opcion == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (opcion == 2)
                {
                    tipoPaquete = "Encomienda";
                }
                nuevoEnvioNacional.TipoPaquete = tipoPaquete; 
                break;
            }
            if (nuevoEnvioNacional.TipoPaquete == "Encomienda")
            {
                Console.WriteLine("Seleccione el peso de la encomienda que desea enviar");
                Console.WriteLine("1- Bultos hasta 10Kg. \n2- Bultos hasta 20Kg.\n3- Bultos hasta 30Kg.");
                string pesoEncomienda;
                var ingreso = Console.ReadLine();
                bool ingresoCorrecto = int.TryParse(ingreso, out int opcion);
                switch (opcion)
                {
                    case 1:
                        {
                            pesoEncomienda = "Bultos hasta 10Kg.";
                            break;
                        }
                    case 2:
                        {
                            pesoEncomienda = "Bultos hasta 20Kg.";
                            break;
                        }
                    case 3:
                        {
                            pesoEncomienda = "Bultos hasta 30Kg.";
                            break;
                        }
                    default:
                        {
                            pesoEncomienda = "Correspondencia hasta 500g";
                            break;
                        }
                }
                nuevoEnvioNacional.PesoPaquete = pesoEncomienda;
            }
            if (nuevoEnvioNacional.TipoPaquete == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                nuevoEnvioNacional.PesoPaquete = pesoEncomienda;
            }
            Console.WriteLine("Seleccione el tipo de recepción:");
            var nuevaSeleccionRetiro = Region.SeleccionRecepcion();
            nuevoEnvioNacional.ListaSeleccionRetiro.Add(nuevaSeleccionRetiro);

            nuevoEnvioNacional.MostrarResumenEnvioNacional();

            return nuevoEnvioNacional;

        }
        public void MostrarResumenEnvioNacional()
         {
            Console.WriteLine("********************");
            Console.WriteLine("Resumen de la operación");//agregamos número?
            Console.WriteLine("********************");
            Console.WriteLine("Tipo de servicio: Envío Nacional");
            Console.WriteLine($"Tipo de paquete: {TipoPaquete}");
            Console.WriteLine($"Peso del paquete: {PesoPaquete}");
            foreach (var seleccionRetiro in ListaSeleccionRetiro)
            {
                seleccionRetiro.MostrarNuevaRecepcion();
            }
            
            
        }
        
    }
}
