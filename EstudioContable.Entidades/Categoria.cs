namespace EstudioContable.Entidades
{
    public class Categoria
    {
        private int _id;
        private string _nombre;
        private string _convenio;
        private double _sueldoBasico;

        public Categoria( string nombre, string convenio, double sueldoBasico, int id)
        {
            
            _nombre = nombre;
            _convenio = convenio;
            _sueldoBasico = sueldoBasico;
            _id = id;
        }

        public int Id => _id;
        public string Nombre => _nombre;
        public string Convenio => _convenio;
        public double SueldoBasico => _sueldoBasico;

        public override string ToString()
        {
            return "ID: " + Id + "  " +
                   "NOMBRE: " + Nombre;
        }
    }
}
