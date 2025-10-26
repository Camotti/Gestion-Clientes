using GestionClientes.Models;

namespace GestionClientes.Data
{
    public static class Database
    {
        public static List<Cliente> clientes = new List<Cliente>
        {
            new Cliente {Id = 1 , Nombre = "Ricardo ", Apellido= "Gomez", Edad= 60, Correo= "Ricardo@gmail.com", Telefono= "3114456070" },
            new Cliente {Id = 2 , Nombre = "Nicolas ", Apellido= "Arrieta", Edad= 45, Correo= "Nicolas@gmail.com", Telefono= "300400678"},
            new Cliente {Id= 3 , Nombre = "Alejandra", Apellido= "Ortiz", Edad= 27, Correo= "Alejandra@gmail.com", Telefono="204300678"},
            new Cliente {Id= 4, Nombre="Cristina", Apellido= "Sarri", Edad= 30, Correo= "Cristina@gmail.com", Telefono="3175670907"},
            new Cliente {Id= 5, Nombre= "Isabella", Apellido="Serrano", Edad=28, Correo= "Serrano@gmail.com", Telefono="200300567"}
        };

        private static int _nextId = clientes.Max(c => c.Id) + 3; //Variable generar nuevo id

        public static int GetNextId() //obtener el siguiente nuevo Id 
        {
            return _nextId++;
        }
    }
}