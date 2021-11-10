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
            NombreCliente = partes[1];
            TipoPersona = partes[2];
            RazonSocial = partes[3];
            CUIT = partes[4];
            NombreClAut = partes[5];
            dniClAut = partes[6];
        }
        public void LeerMaestroCliente(string numeroCliente)
        {
            if (File.Exists(maestroCliente))
            {
                using (var reader = new StreamReader(maestroCliente))
                {
                    var clEncontrado = false;
                    while (!reader.EndOfStream)
                    {
                        var linea = reader.ReadLine();
                        clEncontrado = false;
                        if (linea.IndexOf(numeroCliente, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            var unCliente = new Cliente(linea);
                            clientes.Add(unCliente);
                            clEncontrado = true;
                            break;
                        }
                    }
                    if (clEncontrado == false)
                    {
                        Console.WriteLine("El cliente ingresado no se encuentra en nuestra base de datos");
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
    }
}
