namespace GestionClientes.Models
{
    public abstract class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int Edad { get; set; }


         public Persona() { }

        public Persona(int id, string nombre, string apellido, int edad)
        {
            Id = id;
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;

        }

        public override string ToString()
        {
            return $"El {Id} , el nombre completo {Nombre} {Apellido} , la edad {Edad} ";
        }




    }
    

    
}