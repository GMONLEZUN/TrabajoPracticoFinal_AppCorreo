using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class EnvioInternacional
    {
        public string TipoPaqueteInt { get; private set; }
        public string PesoPaqueteInt { get; private set; }
        public string TiempoEnvioInt { get; private set; }
        public string NumOdeServicio { get; private set; }
        public decimal TarifaServicioInternacional { get; private set; }

        Region NuevaSeleccionRetiro = new Region();
        RegionInternacional NuevaSeleccionEntregaInt = new RegionInternacional();
        Cliente ClienteActivo = new Cliente();

        public static EnvioInternacional Ingresar()
        {
            var nuevoEnvioInternacional = new EnvioInternacional();
            decimal tarifa = 400;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Nueva Orden de Servicio - Envío Internacional");
            Console.ResetColor();
            while (true)
            {
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione el tipo de paquete que desea enviar: ", "1 - Correspondencia (Hasta 500g) \n2 - Encomienda (Hasta 30kg)", 1, 2);
                string tipoPaquete = "";
                if (opcionSelec == 1)
                {
                    tipoPaquete = "Correspondencia";
                }
                if (opcionSelec == 2)
                {
                    tipoPaquete = "Encomienda";
                }
                nuevoEnvioInternacional.TipoPaqueteInt = tipoPaquete;
                break;
            }
            if (nuevoEnvioInternacional.TipoPaqueteInt == "Encomienda")
            {
                string pesoEncomienda;
                int opcionSelec = Validaciones.ValidarOpcion("Seleccione el peso de la encomienda que desea enviar:", "1- Bultos hasta 10Kg. \n2- Bultos hasta 20Kg.\n3- Bultos hasta 30Kg.", 1, 3);

                switch (opcionSelec)
                {
                    case 1:
                        {
                            pesoEncomienda = "Bultos hasta 10Kg.";
                            //tarifa = tarifa * 2.75M;
                            break;
                        }
                    case 2:
                        {
                            pesoEncomienda = "Bultos hasta 20Kg.";
                            //tarifa = tarifa * 4.25M;
                            break;
                        }
                    case 3:
                        {
                            pesoEncomienda = "Bultos hasta 30Kg.";
                            //tarifa = tarifa * 5.75M;
                            break;
                        }
                    default:
                        {
                            pesoEncomienda = "Correspondencia hasta 500g";
                            break;
                        }
                }
                nuevoEnvioInternacional.PesoPaqueteInt = pesoEncomienda;
            }
            if (nuevoEnvioInternacional.TipoPaqueteInt == "Correspondencia")
            {
                string pesoEncomienda = "Correspondencia hasta 500g";
                nuevoEnvioInternacional.PesoPaqueteInt = pesoEncomienda;
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
                nuevoEnvioInternacional.TiempoEnvioInt = tiempoEnvio;
                break;
            } while (true);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Seleccione el tipo de recepción:");
            Console.ResetColor();

            var nuevaSeleccionRetiro = Region.SeleccionRecepcion();
            nuevoEnvioInternacional.NuevaSeleccionRetiro = nuevaSeleccionRetiro;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Entrega");
            Console.ResetColor();

            var nuevaSeleccionEntregaInt = RegionInternacional.SeleccionEntregaInt();
            nuevoEnvioInternacional.NuevaSeleccionEntregaInt = nuevaSeleccionEntregaInt;
   
            //-------------------------------------------------------------------------TARIFA PRIMERO A CABA---------------------------------------------------------
            if (nuevoEnvioInternacional.NuevaSeleccionRetiro.TipoRecepcion == "Retiro en puerta")
            {
                tarifa += 160;
            }
            if (nuevoEnvioInternacional.PesoPaqueteInt == "Bultos hasta 10Kg.")
            {
                tarifa *= 2.75M;
            }
            if (nuevoEnvioInternacional.PesoPaqueteInt == "Bultos hasta 20Kg.")
            {
                tarifa *= 4.25M;
            }
            if (nuevoEnvioInternacional.PesoPaqueteInt == "Bultos hasta 30Kg.")
            {
                tarifa *= 5.75M;
            }
            if (nuevoEnvioInternacional.NuevaSeleccionRetiro.NombreRegion != "Región Pampeana")
            {
                tarifa *= 2M;
            }
            else
            {
                if (nuevoEnvioInternacional.NuevaSeleccionRetiro.NombreProvincia != "Capital Federal")
                {
                    tarifa *= 1.625M;
                }
            }
            //-------------------------------------------------------------------------TARIFA AL PAIS DESTINO---------------------------------------------------------
            if (nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt == "Países Limitrofes")
            {
                tarifa *= 1.25M;
            }
            if (nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt == "Lationamérica (no limítrofes)")
            {
                tarifa *= 1.65M;
            }
            if (nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt == "América del Norte")
            {
                tarifa *= 2M;
            }
            if (nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt == "Europa")
            {
                tarifa *= 2.5M;
            }
            if (nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt == "Asia")
            {
                tarifa *= 2.8M;
            }

            //-----------------------------------------------------------
            if (nuevoEnvioInternacional.TiempoEnvioInt == "Envío urgente")
            {
                if (tarifa * 1.20M > 5500)
                {
                    tarifa += 5500; 
                }
                else
                {
                    tarifa *= 2.20M;
                }
            }
            nuevoEnvioInternacional.TarifaServicioInternacional = tarifa;

            //------------------------Generamos el número de orden de servicio [seguimiento]-------------------------------------
            Random r = new Random();
            int NumRandom = r.Next(0, 9);
            var clienteActivo = nuevoEnvioInternacional.ClienteActivo.DevolverClienteActivo();
            string numOrdenDeServicio = ($"{DateTime.Today.Day}{DateTime.Today.Month}{DateTime.Today.Year}{clienteActivo}{NumRandom}");
            nuevoEnvioInternacional.NumOdeServicio = numOrdenDeServicio;

            nuevoEnvioInternacional.MostrarResumenEnvioInternacional();

            //----------------------------------------------CONFIRMACION----------------------------------------------------------------------------
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("¿Desea confirmar el servicio?\n\n *Presione S para confirmar \n *Presione cualquier otra tecla para cancelar");
            if (Console.ReadKey(true).Key == ConsoleKey.S)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Orden de servicio confirmada");
                Console.ResetColor();
                //---------------------------------------------------Creamos el objeto de la nueva orden de servicio
                OrdenDeServicio nuevaOrden = new OrdenDeServicio();
                nuevaOrden.NumeroSeguimiento = nuevoEnvioInternacional.NumOdeServicio;
                nuevaOrden.NumeroCliente = clienteActivo;
                nuevaOrden.PaisEntrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombrePais;
                nuevaOrden.RegionEntrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreRegionEntregaInt;
                nuevaOrden.ProvinciaEntrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreEstadoEntregaInt;
                nuevaOrden.LocalidadEntrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreLocalidadEntregaInt;
                nuevaOrden.DireccionEntrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.DireccionEntregaInt;
                nuevaOrden.NombreDestinatario = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.NombreDestinatario;
                nuevaOrden.FechaOrden = DateTime.Now.Date;
                nuevaOrden.Importe = nuevoEnvioInternacional.TarifaServicioInternacional;
                nuevaOrden.EstadoOrden = "Iniciada";
                nuevaOrden.Region = nuevoEnvioInternacional.NuevaSeleccionRetiro.NombreRegion;
                nuevaOrden.Provincia = nuevoEnvioInternacional.NuevaSeleccionRetiro.NombreProvincia;
                nuevaOrden.Localidad = nuevoEnvioInternacional.NuevaSeleccionRetiro.NombreLocalidad;
                if (nuevoEnvioInternacional.NuevaSeleccionRetiro.TipoRecepcion == "Retiro en puerta")
                {
                    nuevaOrden.DireccionOrigen = nuevoEnvioInternacional.NuevaSeleccionRetiro.RetiroDireccion;
                }
                else
                {
                    nuevaOrden.DireccionOrigen = nuevoEnvioInternacional.NuevaSeleccionRetiro.SucursalDireccion;
                }
                nuevaOrden.Recepcion = nuevoEnvioInternacional.NuevaSeleccionRetiro.TipoRecepcion;
                nuevaOrden.Entrega = nuevoEnvioInternacional.NuevaSeleccionEntregaInt.TipoEntregaInt;
                nuevaOrden.PesoEncomienda = nuevoEnvioInternacional.PesoPaqueteInt;
                nuevaOrden.TipoEnvio = nuevoEnvioInternacional.TiempoEnvioInt;

                nuevaOrden.LeerMaestroOrdenes();

                //-------------------------------------------------------agregamos la linea a la lista
                nuevaOrden.AgregarOrdenDeServicio(nuevaOrden);

                //---------------------------------------------------------grabamos todo en el txt de archivo maestro de ordenes de servicio
                nuevaOrden.GuardarOrdenDeServicio();

                //---------------------------------------------------Imprimir comprobante------------------------------------------------------------
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("¿Desea imprimir el comprobante?\n\n * Presione S para imprimir\n * Presione cualquier otra tecla para continuar");
                if (Console.ReadKey(true).Key == ConsoleKey.S)
                {
                    nuevoEnvioInternacional.ImprimirComprobante();
                    System.Diagnostics.Process.Start($"{nuevoEnvioInternacional.NumOdeServicio}{DateTime.Today.Hour}{DateTime.Today.Minute}{DateTime.Today.Second}.txt");
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

            return nuevoEnvioInternacional;
        }


        public void MostrarResumenEnvioInternacional()
        {
            Console.WriteLine("***********************************************************************");
            Console.WriteLine($"Resumen de la operación N° {NumOdeServicio}\t\tFecha: {DateTime.Today.ToShortDateString()}");
            Console.WriteLine("\n\n");
            ClienteActivo.MostrarClienteActivo();
            Console.WriteLine("Tipo de servicio: Envío Internacional\n");
            Console.WriteLine($"Tipo de paquete: {TipoPaqueteInt}");
            Console.WriteLine($"Peso: {PesoPaqueteInt}");
            Console.WriteLine($"Tiempo de envío: {TiempoEnvioInt}\n");

            NuevaSeleccionRetiro.MostrarNuevaRecepcion();
            NuevaSeleccionEntregaInt.MostrarNuevaEntregaInternacional();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\t\t\tImporte total del servicio: ${TarifaServicioInternacional.ToString("n2")}");
            Console.ResetColor();
            Console.WriteLine("");
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
                writer.WriteLine("Tipo de servicio: Envío Internacional\n");
                writer.WriteLine($"Tipo de paquete: {TipoPaqueteInt}");
                writer.WriteLine($"Peso: {PesoPaqueteInt}");
                writer.WriteLine($"Tiempo de envío: {TiempoEnvioInt}\n");
                NuevaSeleccionRetiro.EscribirNuevaRecepcion(writer);
                NuevaSeleccionEntregaInt.EscribirNuevaEntregaInternacional(writer);
                writer.WriteLine("");
                writer.WriteLine($"Número de seguimiento: [{NumOdeServicio}]\n");
                writer.WriteLine("[ ! ] Conservelo para consultar el estado del envío\n");
                writer.WriteLine($"\t\t\tImporte total del servicio: ${TarifaServicioInternacional.ToString("n2")}");
                writer.WriteLine("***********************************************************************\n\n");
                writer.WriteLine("[ ! ] Presione Ctrl+P para imprimir este comprobante");
                writer.WriteLine("[ ! ] Presione Ctrl+Mayús+S para guardar este comprobante");
                writer.Close();
            }
            archivo.Close();
        }
    }
}
