using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_CAI
{
    class Cliente
    {
        public string NumeroCliente { get;  }
        public string NombreCliente { get;  }
        public string TipoPersona { get;  }
        public string RazonSocial { get;  }
        public string CUIT { get;  }
        public string NombreClAut { get; }
        public string dniClAut { get;  }
        const string maestroCliente = "maestroCliente.txt";
        static List<Cliente> clientes = new List<Cliente>();
        public Cliente() { }
        public Cliente(string linea)      
        {
            var partes = linea.Split('|');
            NumeroCliente = partes[0];
            TipoPersona = partes[1];
            RazonSocial = partes[2];
            CUIT = partes[3];
            dniClAut = partes[4];
            NombreClAut = partes[5];
            
        }


        public void LeerMaestroCliente(string numeroCliente, string dni)
        {

            if (File.Exists(maestroCliente))
            {
                using (var reader = new StreamReader(maestroCliente))
                {
                    var clEncontrado = false;
                    var dniEncontrado = false;

                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        var unCliente = new Cliente(linea);

                        clEncontrado = unCliente.NumeroCliente == numeroCliente;
                        dniEncontrado = unCliente.dniClAut == dni;

                        if (clEncontrado && dniEncontrado)
                        {
                            clientes.Add(unCliente);
                            break;

                        }

                    }
                    if (clEncontrado == false || dniEncontrado == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("El cliente o dni ingresado no se encuentra en nuestra registrado en nuestra base de datos");
                        Console.ResetColor();
                        Console.ReadKey();
                        System.Environment.Exit(0);
                    }
                }
            }
        }

        public void MostrarClientesEncontrados()
        {
            foreach (var cliente in clientes)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("¡Bienvenido!");
                Console.ResetColor();
                Console.WriteLine($"Cliente: {cliente.RazonSocial}");
                Console.WriteLine($"CUIT {cliente.CUIT}");
                Console.WriteLine("----------------------------");
                Console.WriteLine("Usuarios Autorizados:");
                Console.WriteLine($"Nombre {cliente.NombreClAut}");
                Console.WriteLine($"DNI {cliente.dniClAut}");
                Console.WriteLine("----------------------------");
            }
        }
        public string DevolverClienteActivo() 
        {
            string clienteActivo = "";
            foreach (var cliente in clientes)
            {
                clienteActivo = cliente.NumeroCliente;
            }
            return clienteActivo;
        }
        public void MostrarClienteActivo() 
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente N°: {cliente.NumeroCliente}\t\t\t{cliente.RazonSocial}\n");
            }
            
        }

        public void EscribirClienteActivo(StreamWriter writer) 
        {
            foreach (var cliente in clientes)
            {
                writer.WriteLine($"Cliente N°: {cliente.NumeroCliente}\t\t\t{cliente.RazonSocial}\n");
            }
        }
    }
}
