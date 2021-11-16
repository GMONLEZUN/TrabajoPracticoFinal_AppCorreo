﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace TP_CAI
{
    class EnvioNacional
    {
        public string TipoPaquete { get; private set; }
        public string PesoPaquete { get; private set; }
        public string TiempoEnvio { get; private set; }
        public string NumOdeServicio { get; private set; }
        public decimal TarifaServicioNacional { get; private set; }

        //------------------cambio las listas hechas por objetos
        Region NuevaSeleccionRetiro = new Region();
        Region NuevaSeleccionEntrega = new Region();
        Cliente ClienteActivo = new Cliente();
        //List<Region> ListaSeleccionRetiro = new List<Region>();
        //List<Region> ListaSeleccionEntrega = new List<Region>();

        public static EnvioNacional Ingresar() 
        {
            var nuevoEnvioNacional = new EnvioNacional();
            decimal tarifa = 400M;
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
                            tarifa = tarifa * 2.75M;
                            break;
                        }
                    case 2:
                        {
                            pesoEncomienda = "Bultos hasta 20Kg.";
                            tarifa = tarifa * 4.25M;
                            break;
                        }
                    case 3:
                        {
                            pesoEncomienda = "Bultos hasta 30Kg.";
                            tarifa = tarifa * 5.75M;
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
            nuevoEnvioNacional.NuevaSeleccionRetiro = nuevaSeleccionRetiro;
            

            //var nuevaSeleccionRetiro = Region.SeleccionRecepcion();
            //-----------------------------------no agrego elementos a la lista, no hace falta----------------
            //nuevoEnvioNacional.ListaSeleccionRetiro.Add(nuevaSeleccionRetiro);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el tipo de entrega:");
            Console.ResetColor();
            

            var nuevaSeleccionEntrega = Region.SeleccionEntrega();
            nuevoEnvioNacional.NuevaSeleccionEntrega = nuevaSeleccionEntrega;
            //-------------------------------------------------------------------------TARIFA---------------------------------------------------------
            if (nuevoEnvioNacional.NuevaSeleccionRetiro.TipoRecepcion == "Retiro en puerta")
            {
                tarifa += 160;
            }
            if (nuevoEnvioNacional.NuevaSeleccionRetiro.NombreRegion != nuevoEnvioNacional.NuevaSeleccionEntrega.NombreRegionEntrega)
            {
                tarifa *= 2M;
            }
            else
            {
                if (nuevoEnvioNacional.NuevaSeleccionRetiro.NombreProvincia != nuevoEnvioNacional.NuevaSeleccionEntrega.NombreProvinciaEntrega)
                {
                    tarifa *= 1.625M;
                }
                else
                {
                    if (nuevoEnvioNacional.NuevaSeleccionRetiro.NombreLocalidad != nuevoEnvioNacional.NuevaSeleccionEntrega.NombreLocalidadEntrega)
                    {
                        tarifa *= 1.25M;
                    }
                }
            }
            if (nuevoEnvioNacional.NuevaSeleccionEntrega.TipoEntrega == "Entrega en puerta")
            {
                tarifa += 200;
            }

            //var nuevaSeleccionEntrega = Region.SeleccionEntrega();
            //---------------------------no agrego elementos a la lista, no hace falta----------------
            //nuevoEnvioNacional.ListaSeleccionEntrega.Add(nuevaSeleccionEntrega);

            if (nuevoEnvioNacional.TiempoEnvio == "Envío urgente")
            {
                if (tarifa * 1.20M > 1600)
                {
                    tarifa += 1600;
                }
                else
                {
                    tarifa *= 2.20M ;
                }
            }
            nuevoEnvioNacional.TarifaServicioNacional = tarifa;

            //------------------------Generamos el número de orden de servicio [seguimiento]-------------------------------------
            Random r = new Random();
            int NumRandom = r.Next(0, 9);
            var clienteActivo = nuevoEnvioNacional.ClienteActivo.DevolverClienteActivo();
            string numOrdenDeServicio = ($"{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}{clienteActivo}{NumRandom}");
            nuevoEnvioNacional.NumOdeServicio = numOrdenDeServicio;

            nuevoEnvioNacional.MostrarResumenEnvioNacional();
            //----------------------------------------------CONFIRMACION----------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Desea confirmar el servicio? [S/N]");
            Console.ResetColor();
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Orden de servicio confirmada");
                Console.ResetColor();
                //---------------------------------------------------Imprimir comprobante------------------------------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("¿Desea imprimir el comprobante? [S/N]");
                if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    nuevoEnvioNacional.ImprimirComprobante();
                    System.Diagnostics.Process.Start($"{nuevoEnvioNacional.NumOdeServicio}{DateTime.Today.Hour}{DateTime.Today.Minute}{DateTime.Today.Second}.txt");
                }
                Console.WriteLine("Gracias por utilizar nuestros servicios");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Operación cancelada");
                Console.ResetColor();
                Console.ReadLine();
                System.Environment.Exit(0);
            }
            Console.ResetColor();
            Console.ReadLine();
            
            return nuevoEnvioNacional;
        }
        public void MostrarResumenEnvioNacional()
         {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine($"Resumen de la operación N° {NumOdeServicio}\t\tFecha: {DateTime.Today.ToShortDateString()}");
            Console.WriteLine("\n\n");
            ClienteActivo.MostrarClienteActivo();
            Console.WriteLine("Tipo de servicio: Envío Nacional\n");
            Console.WriteLine($"Tipo de paquete: {TipoPaquete}");
            Console.WriteLine($"Peso: {PesoPaquete}");
            Console.WriteLine($"Tiempo de envío: {TiempoEnvio}\n");
            
            //------------------Cambio los foreach por la referencia a un solo objeto
            NuevaSeleccionRetiro.MostrarNuevaRecepcion();
            NuevaSeleccionEntrega.MostrarNuevaEntrega();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\tImporte total del servicio: ${TarifaServicioNacional}");
            Console.ResetColor();
            Console.WriteLine("");
            //foreach (var seleccionRetiro in ListaSeleccionRetiro)
            //{
            //    seleccionRetiro.MostrarNuevaRecepcion();
            //}
            //foreach (var seleccionEntrega in ListaSeleccionEntrega)
            //{
            //    seleccionEntrega.MostrarNuevaEntrega();
            //}
        }

        public void ImprimirComprobante() 
        {
            FileStream archivo = File.OpenWrite($"{NumOdeServicio}{DateTime.Today.Hour}{DateTime.Today.Minute}{DateTime.Today.Second}.txt");
            using (var writer = new StreamWriter(archivo)) 
            {
                writer.WriteLine("***********************************************************************\n");
                writer.WriteLine($"Comprobante de la operacion N° {NumOdeServicio}\t\tFecha: {DateTime.Today.ToShortDateString()}");
                writer.WriteLine("\n\n");
                ClienteActivo.EscribirClienteActivo(writer);
                writer.WriteLine("Tipo de servicio: Envío Nacional\n");
                writer.WriteLine($"Tipo de paquete: {TipoPaquete}");
                writer.WriteLine($"Peso: {PesoPaquete}");
                writer.WriteLine($"Tiempo de envío: {TiempoEnvio}\n");
                NuevaSeleccionRetiro.EscribirNuevaRecepcion(writer);
                NuevaSeleccionEntrega.EscribirNuevaEntrega(writer);
                writer.WriteLine("");
                writer.WriteLine($"Número de seguimiento: [{NumOdeServicio}]\n");
                writer.WriteLine("[ ! ] Conservelo para consultar el estado del envío\n");
                writer.WriteLine($"\t\t\tImporte total del servicio: ${TarifaServicioNacional}");
                writer.WriteLine("***********************************************************************\n\n");
                writer.WriteLine("[ ! ] Presione Ctrl+P para imprimir este comprobante");
                writer.WriteLine("[ ! ] Presione Ctrl+Mayús+S para guardar este comprobante");
                writer.Close();
            }
            archivo.Close();
        }
    }
}
