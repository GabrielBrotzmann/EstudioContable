namespace EstudioContable.Entidades
{
    public class Persona
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _direccion;
        private long _telefono;
        private string _mail;

        public Persona(int id, string nombre, string apellido)
        {
            _id = id;
            _nombre = nombre;
            _apellido = apellido;
          
        }

        public int Id { get { return _id; } set { _id = value; } }
        public string Nombre { get { return _nombre; } set { _nombre = value; } }
        public string Apellido { get { return _apellido; } set { _apellido = value; } }
        public string Direccion { get { return _direccion; } set { _direccion = value; } }
        public long Telefono { get { return _telefono; } set { _telefono = value; } }
        public string Mail { get { return _mail; } set { _mail = value; } }
    }
}
