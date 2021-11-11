﻿using System;
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
        public string TiempoEnvio { get; private set; }

        List<Region> ListaSeleccionRetiro = new List<Region>();
        List<Region> ListaSeleccionEntrega = new List<Region>();

        public static EnvioNacional Ingresar() 
        {
            var nuevoEnvioNacional = new EnvioNacional();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Nueva Orden de Servicio - Envío Nacional");
            Console.ResetColor();
            while (true)
            {
                
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione el tipo de paquete que desea enviar: ", "1 - Correspondencia \n2 - Encomienda", 1, 2);
                string tipoPaquete = "";
                if (opcionSelec == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (opcionSelec == 2)
                {
                    tipoPaquete = "Encomienda";
                }
                nuevoEnvioNacional.TipoPaquete = tipoPaquete; 
                break;
            }
            if (nuevoEnvioNacional.TipoPaquete == "Encomienda")
            {
                string pesoEncomienda;
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione el peso de la encomienda que desea enviar:", "1- Bultos hasta 10Kg. \n2- Bultos hasta 20Kg.\n3- Bultos hasta 30Kg.", 1, 3);
                
                switch (opcionSelec)
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

            do
            {
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione el tiempo de envío:", "1- Envío urgente. \n2- Envío normal.", 1, 2);
                string tiempoEnvio = "";
                if (opcionSelec == 1)
                {
                    tiempoEnvio = "Envío urgente";
                }
                if (opcionSelec == 2)
                {
                    tiempoEnvio = "Envío normal";
                }
                nuevoEnvioNacional.TiempoEnvio = tiempoEnvio;
                break;
            } while (true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el tipo de recepción:");
            Console.ResetColor();
            var nuevaSeleccionRetiro = Region.SeleccionRecepcion();
            nuevoEnvioNacional.ListaSeleccionRetiro.Add(nuevaSeleccionRetiro);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el tipo de entrega:");
            Console.ResetColor();
            var nuevaSeleccionEntrega = Region.SeleccionEntrega();
            nuevoEnvioNacional.ListaSeleccionEntrega.Add(nuevaSeleccionEntrega);

            nuevoEnvioNacional.MostrarResumenEnvioNacional();
            //----------------------------------------------CONFIRMACION----------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Desea confirmar el servicio? [S/N]");
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Orden de servicio confirmada");
                Console.WriteLine("Gracias por utilizar nuestros servicios");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operación cancelada");
                System.Environment.Exit(0);
            }
            Console.ResetColor();
            Console.ReadLine();
            
            return nuevoEnvioNacional;
        }
        public void MostrarResumenEnvioNacional()
         {
            Console.WriteLine("***********************");
            Console.WriteLine("Resumen de la operación");//agregamos número?
            Console.WriteLine("***********************");
            Console.WriteLine("Tipo de servicio: Envío Nacional");
            Console.WriteLine($"Tipo de paquete: {TipoPaquete}");
            Console.WriteLine($"Peso del paquete: {PesoPaquete}");
            Console.WriteLine($"Tiempo de envío: {TiempoEnvio}");
            foreach (var seleccionRetiro in ListaSeleccionRetiro)
            {
                seleccionRetiro.MostrarNuevaRecepcion();
            }
            foreach (var seleccionEntrega in ListaSeleccionEntrega)
            {
                seleccionEntrega.MostrarNuevaEntrega();
            }
        }
        
    }
}
