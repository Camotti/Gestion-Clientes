using GestionClientes.Data;
using GestionClientes.Models;
using GestionClientes.Interfaces;


namespace GestionClientes.Repositories
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public List<Cliente> ObtenerTodos()
        {
            return Database.clientes;
        }


        public Cliente? ObtenerPorId(int id)
        {
            return Database.clientes.FirstOrDefault(c => c.Id == id);
        }

        public void Añadir(Cliente cliente)
        {
            cliente.Id = Database.GetNextId();
            Database.clientes.Add(cliente);
        }

        public void Actualizar(Cliente cliente)
        {
            var ClienteCreado = ObtenerPorId(cliente.Id);
            if (ClienteCreado == null) return;

            ClienteCreado.Nombre = cliente.Nombre;
            ClienteCreado.Apellido = cliente.Apellido;
            ClienteCreado.Edad = cliente.Edad;
            ClienteCreado.Correo = cliente.Correo;
            ClienteCreado.Telefono = cliente.Telefono;
        }
        
        public void Eliminar(int id)
        {
            var cliente = ObtenerPorId(id);
            if (cliente != null)
            {
                Database.clientes.Remove(cliente);
            }
        }
    }
}