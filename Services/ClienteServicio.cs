using GestionClientes.Models;
using GestionClientes.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace GestionClientes.Services
{
    public class ClienteServicio
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServicio(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }


        public List<Cliente> ListarClientes()
        {
            return _repositorio.ObtenerTodos();
        }


        public Cliente? ObtenerClientePorId(int id)
        {
            if (id <= 0)
            {
                Console.WriteLine("el ID debe ser mayor que 0");
                return null;
            }
            return _repositorio.ObtenerPorId(id);
        }


        public void CrearCliente(string nombre, string apellido, int edad, string correo, string telefono)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
            {
                Console.WriteLine("Usuario le recuerdo que el NOMBRE y el APELLIDO son obligatorios,");
                return;
            }

            if (edad <= 0 || edad > 98)
            {
                Console.WriteLine("La edad debe estar entre 1 - 98.");
                return;
            }

            if (string.IsNullOrWhiteSpace(correo) || !correo.Contains("@"))
            {
                Console.WriteLine("El correo no es valido, vuelva a intentarlo,");
                return;
            }

            if (string.IsNullOrWhiteSpace(telefono))
            {
                Console.WriteLine("El telefono es obligatorio.");
                return;
            }

            var nuevoCliente = new Cliente
            {
                Nombre = nombre.Trim(),
                Apellido = apellido.Trim(),
                Edad = edad,
                Correo = correo.Trim(),
                Telefono = telefono.Trim()
            };

            _repositorio.Añadir(nuevoCliente);
            Console.WriteLine("Cliente añadido correctamente.");
        }


        public void ActualizarCliente(int id, string nombre, string apellido, int edad, string correo, string telefono)
        {
            var cliente = _repositorio.ObtenerPorId(id);

            if (cliente == null)
            {
                Console.WriteLine("No se encontro al cliente");
                return;
            }

            cliente.Nombre = string.IsNullOrWhiteSpace(nombre) ? cliente.Nombre : nombre.Trim();
            cliente.Apellido = string.IsNullOrWhiteSpace(apellido) ? cliente.Apellido : apellido.Trim();
            cliente.Edad = edad > 0 ? edad : cliente.Edad;
            cliente.Correo = string.IsNullOrWhiteSpace(correo) ? cliente.Correo : correo.Trim();
            cliente.Telefono = string.IsNullOrWhiteSpace(telefono) ? cliente.Telefono : telefono.Trim();

            _repositorio.Actualizar(cliente);
            Console.WriteLine("El cliente ha sido actualizado.");
        }
        
        public void EliminarCliente(int id)
        {
            var cliente = _repositorio.ObtenerPorId(id);

            if (cliente == null)
            {
                Console.WriteLine("No se encontro ningún cliente por ID.");
                return;
            }

            _repositorio.Eliminar(id);
            Console.WriteLine("El cliente ha sido eliminado correctamente");
        }
    }
}