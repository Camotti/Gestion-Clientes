using GestionClientes.Models;

namespace GestionClientes.Interfaces
{
    public interface IClienteRepositorio
    {
        List<Cliente> ObtenerTodos();
        Cliente? ObtenerPorId(int id);
        void Añadir(Cliente cliente);
        void Actualizar(Cliente cliente);
        void Eliminar(int id);
    }
}

