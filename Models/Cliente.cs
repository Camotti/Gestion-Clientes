using GestionClientes.Interfaces;

namespace GestionClientes.Models
{
    public class Cliente : Persona
    {
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;


        public Cliente() : base() { }

        public Cliente(int id, string nombre, string apellido, int edad, string correo, string telefono) : base(id, nombre, apellido, edad)
        {
            Correo = correo;
            Telefono = telefono;
        }


        public override string ToString()
        {
            return base.ToString() + $"El Correo : {Correo}";
        }






    }
}
