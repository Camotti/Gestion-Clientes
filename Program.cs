using GestionClientes.Models;
using GestionClientes.Data;
using GestionClientes.Interfaces;
using GestionClientes.Repositories;
using GestionClientes.Services;

namespace GestionClientes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repositorio = new ClienteRepositorio();
            var servicio = new ClienteServicio(repositorio);

            int opcion = -1;

            while (opcion != 0)
            {
                Console.WriteLine("\n--- GESTIÓN DE CLIENTES ---");
                Console.WriteLine("1. Listar Clientes");
                Console.WriteLine("2. Crear Cliente");
                Console.WriteLine("3. Actualizar Cliente");
                Console.WriteLine("4. Eliminar Cliente");
                Console.WriteLine("5. Buscar Cliente por ID");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción inválida. Inténtelo de nuevo.");
                    continue;
                }

                switch (opcion)
                {
                    case 1:
                        ListarClientes(servicio);
                        break;
                    case 2:
                        CrearCliente(servicio);
                        break;
                    case 3:
                        ActualizarCliente(servicio);
                        break;
                    case 4:
                        EliminarCliente(servicio);
                        break;
                    case 5:
                        BuscarClientePorId(servicio);
                        break;
                    case 0:
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        //  MÉTODOS ESTÁTICOS AUXILIARES 

        static void ListarClientes(ClienteServicio servicio)
        {
            var clientes = servicio.ListarClientes();

            if (clientes.Count == 0)
            {
                Console.WriteLine(" No hay clientes registrados.");
                return;
            }

            Console.WriteLine("\n=== LISTA DE CLIENTES ===");
            foreach (var c in clientes)
            {
                Console.WriteLine($"ID: {c.Id} | {c.Nombre} {c.Apellido} | Edad: {c.Edad} | Correo: {c.Correo} | Tel: {c.Telefono}");
            }
        }

        static void CrearCliente(ClienteServicio servicio)
        {
            Console.Write("Ingrese nombre: ");
            string nombre = Console.ReadLine()!;
            Console.Write("Ingrese apellido: ");
            string apellido = Console.ReadLine()!;
            Console.Write("Ingrese edad: ");
            int.TryParse(Console.ReadLine(), out int edad);
            Console.Write("Ingrese correo: ");
            string correo = Console.ReadLine()!;
            Console.Write("Ingrese teléfono: ");
            string telefono = Console.ReadLine()!;

            servicio.CrearCliente(nombre, apellido, edad, correo, telefono);
        }

        static void ActualizarCliente(ClienteServicio servicio)
        {
            Console.Write("Ingrese ID del cliente a actualizar: ");
            int.TryParse(Console.ReadLine(), out int id);
            Console.Write("Nuevo nombre (o Enter para mantener): ");
            string nombre = Console.ReadLine()!;
            Console.Write("Nuevo apellido (o Enter para mantener): ");
            string apellido = Console.ReadLine()!;
            Console.Write("Nueva edad (o 0 para mantener): ");
            int.TryParse(Console.ReadLine(), out int edad);
            Console.Write("Nuevo correo (o Enter para mantener): ");
            string correo = Console.ReadLine()!;
            Console.Write("Nuevo teléfono (o Enter para mantener): ");
            string telefono = Console.ReadLine()!;

            servicio.ActualizarCliente(id, nombre, apellido, edad, correo, telefono);
        }

        static void EliminarCliente(ClienteServicio servicio)
        {
            Console.Write("Ingrese ID del cliente a eliminar: ");
            int.TryParse(Console.ReadLine(), out int id);
            servicio.EliminarCliente(id);
        }

        static void BuscarClientePorId(ClienteServicio servicio)
        {
            Console.Write("Ingrese ID del cliente: ");
            int.TryParse(Console.ReadLine(), out int id);

            var cliente = servicio.ObtenerClientePorId(id);
            if (cliente == null)
            {
                Console.WriteLine("No se encontró el cliente.");
                return;
            }

            Console.WriteLine($"\nCliente encontrado:");
            Console.WriteLine($"ID: {cliente.Id}");
            Console.WriteLine($"Nombre: {cliente.Nombre} {cliente.Apellido}");
            Console.WriteLine($"Edad: {cliente.Edad}");
            Console.WriteLine($"Correo: {cliente.Correo}");
            Console.WriteLine($"Teléfono: {cliente.Telefono}");
        }
    }
}
